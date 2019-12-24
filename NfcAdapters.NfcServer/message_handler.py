import os
import sys

dir_path = os.path.dirname(os.path.realpath(__file__))
sys.path.append(dir_path + '/nfc_reader')

import nfc_helper
import connect_PN532
import message 




def process(msg, args, client):

    print("Client(%s): %s (%s)" % (client['id'], msg, args))

    messages = {
        "READ" : read,
        "WRITER" :  write
    }

    fun = messages.get(msg.upper(), default)
    return message.respond(msg, fun(msg, args, client), True)


def read(message, args, client):
    
    pn532 = connect_PN532.connect()
    uid = nfc_helper.wait_for_tag(pn532)
    
    print("Read complete")
    return [i for i in uid]


def write():
    pass

def default(message, args, client):
    print("Client(%s) send unknown message (%s) with args (%s)" % (client['id'],message))
    return "unknown command"
