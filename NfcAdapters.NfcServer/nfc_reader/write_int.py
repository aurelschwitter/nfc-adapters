import connect_PN532
import sys
import nfc_helper

MIFARE_BLOCKSIZE = 16

if len(sys.argv) < 2:
    print ("Please supply value to write")
    exit()

# connect to PN532
pn532 = connect_PN532.connect()

print("Ready!")

uid = nfc_helper.wait_for_tag(pn532)


# found tag to write
print("Tag found!")

values = [(int)(value) for value in sys.argv[1:]]

nfc_helper.write_tag(pn532, values)

uid = nfc_helper.wait_for_tag(pn532)

print(nfc_helper.read_tag(pn532, uid, nfc_helper.DATA_TYPE_INT))



