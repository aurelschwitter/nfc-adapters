from websocket_server import WebsocketServer
import message_handler
import message

# Called for every client connecting (after handshake)
def new_client(client, server):
	print("New client connected and was given id %d" % client['id'])
	server.send_message_to_all(message.respond("hello", "Hey all, a new client has joined us", True))


# Called for every client disconnecting
def client_left(client, server):
	print("Client(%d) disconnected" % client['id'])


# Called when a client sends a message
def message_received(client, server, msg):
	
    response = message_handler.process(msg, client)
    server.send_message(client, response)
    

PORT=9001
server = WebsocketServer(PORT, host='0.0.0.0')
server.set_fn_new_client(new_client)
server.set_fn_client_left(client_left)
server.set_fn_message_received(message_received)
server.run_forever()