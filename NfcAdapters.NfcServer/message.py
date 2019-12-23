import json


def respond(method, data, success):
    return format({"method": method, "data": data, "success": success})


def format(response):
    return json.dumps(response)
