# Example of detecting and reading a block from a MiFare NFC card.
# Author: Tony DiCola & Roberto Laricchia
# Copyright (c) 2015 Adafruit Industries
#
# Permission is hereby granted, free of charge, to any person obtaining a copy
# of this software and associated documentation files (the "Software"), to deal
# in the Software without restriction, including without limitation the rights
# to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
# copies of the Software, and to permit persons to whom the Software is
# furnished to do so, subject to the following conditions:
#
# The above copyright notice and this permission notice shall be included in all
# copies or substantial portions of the Software.
#
# THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
# IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
# FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
# AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
# LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
# OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
# SOFTWARE.

"""
This example shows connecting to the PN532 and writing & reading an ntag2xx
type RFID tag
"""

import board
import busio
from digitalio import DigitalInOut
import connect_PN532

pn532 = connect_PN532.connect()

print('Waiting for RFID/NFC card to write to!')
while True:
    # Check if a card is available to read
    uid = pn532.read_passive_target(timeout=0.5)
    print('.', end="")
    # Try again if no card is available.
    if uid is not None:
        break

print("")
print('Found card with UID:', [hex(i) for i in uid])

# Set 4 bytes of block to 0xFEEDBEEF
data = bytearray(4)
data[0:4] = b'\xFF\xFF\xFF\xFF'
# Write 4 byte block.
pn532.ntag2xx_write_block(6, data)
# Read block #6
print('Wrote to block 6, now trying to read that data:',
      [hex(x) for x in pn532.ntag2xx_read_block(6)])
