NR_OF_BLOCKS = 6
NTAG2XX_BLOCKSIZE = 4
BYTE_ORDER = "little"  # little endian
ENCODING = "utf-8"
DATA_TYPE_INT = 1
DATA_TYPE_STR = "s"


def wait_for_tag(pn532):
    uid = None
    while uid is None:
        # Check if a card is available to read
        uid = pn532.read_passive_target(timeout=0.5)

    return uid


def read_tag(pn532, uid, data_type):
    res = {
        "uid": int.from_bytes(uid, BYTE_ORDER),
        "data": None
    }

    bytes_read = []

    for i in range(NR_OF_BLOCKS + 1):
        block = pn532.ntag2xx_read_block(i)
        print(i, [hex(i) for i in block])
        bytes_read.append(convert_from_bytes(block, data_type))
        

    res["data"] = bytes_read
    return res


def write_tag(pn532, data: list):

    byte_arr = bytearray(0)
    try:
        byte_arr = convert_to_bytes(data)
    except Exception:
        print("Not valid: ", data)
        return None

    for block in range(NR_OF_BLOCKS+1):

        current_index = block * NTAG2XX_BLOCKSIZE
        to_write_bytes = byte_arr[current_index:current_index+4]
        print(block, [hex(i) for i in to_write_bytes])

        bytelen = len(to_write_bytes)
        pad = NTAG2XX_BLOCKSIZE - bytelen
        padded = to_write_bytes + (pad * "0").encode("utf-8")

        print(block, padded)

        # Write 16 byte block.
        pn532.ntag2xx_write_block(block, padded)


def convert_to_bytes(data):
    print(data)
    values = []
    for d in data:
        if (type(d) is str):
            values.append(bytes(d, ENCODING))
        if (type(data) is int):
            values.append(d.to_bytes((d.bit_length()+7)//8, BYTE_ORDER))
    print(values)
    return values

def convert_from_bytes(byte_data, data_type):

    if (type(data_type) is str):
        print("String!")
        return byte_data.decode(ENCODING)
    if (type(data_type) is int):
        return int.from_bytes(byte_data, byteorder=BYTE_ORDER)

    raise Exception("Invalid type to convert to")
