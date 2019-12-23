#!/usr/bin/python3

# example from https://github.com/adafruit/Adafruit_CircuitPython_PN532/blob/master/examples/pn532_readwrite_ntag2xx.py
import board
import busio
import uuid
import json
from digitalio import DigitalInOut
from adafruit_pn532.spi import PN532_SPI
import connect_PN532
import nfc_helper

# connect to PN532
pn532 = connect_PN532.connect()

try:

    uid = nfc_helper.wait_for_tag(pn532)
    print('Found card with UID:', [hex(i) for i in uid])

    result = nfc_helper.read_tag(pn532, uid, nfc_helper.DATA_TYPE_INT)
    print(result["result"])
    t = [hex(d) for d in result["result"]]

    print(json.dumps(t))

except KeyboardInterrupt:
    connect_PN532.cleanup()



'''
# Set 4 bytes of block to 0xFEEDBEEF
data = bytearray(4)
data[0:4] = b'\xFE\xED\xBE\xEF'
# Write 4 byte block.
pn532.ntag2xx_write_block(6, data)
# Read block #6
print('Wrote to block 6, now trying to read that data:',
      [hex(x) for x in pn532.ntag2xx_read_block(6)])
'''