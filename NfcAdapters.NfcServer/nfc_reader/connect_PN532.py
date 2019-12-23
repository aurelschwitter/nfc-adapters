import RPi.GPIO as GPIO
import time


def connect():

    import board
    import busio
    from digitalio import DigitalInOut
    from adafruit_pn532.spi import PN532_SPI

    # SPI connection:
    spi = busio.SPI(board.SCK, board.MOSI, board.MISO)
    cs_pin = DigitalInOut(board.D4)
    pn532 = PN532_SPI(spi, cs_pin, debug=False)

    #ic, ver, rev, support = pn532.get_firmware_version()
    #print('Found PN532 with firmware version: {0}.{1}'.format(ver, rev))

    # Configure PN532 to communicate with MiFare cards
    pn532.SAM_configuration()

    return pn532
