import os
import sys

dir_path = os.path.dirname(os.path.realpath(__file__))
sys.path.append(dir_path + '/nfc_reader')

import nfc_helper
import connect_PN532
import message 




def process(msg, client):

    print("Client(%s): %s" %(client, message))

    messages = {
        "READ" : read,
        "WRITER" :  write
    }

    fun = messages.get(msg.upper(), default)
    return message.respond(msg, fun(msg, client), True)


def read(client, message):
    pn532 = connect_PN532.connect()
    uid = nfc_helper.wait_for_tag(pn532)

    return [i for i in uid]


def write():
    pass

def default(client, message):
    print("Client(%s) send unknown message (%s)" % (client,message))
    return "unknown command"
