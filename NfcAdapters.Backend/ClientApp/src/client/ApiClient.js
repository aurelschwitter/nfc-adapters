export class ApiClient {

    SetValues(username, key, endpoint) {
        this.username = username;
        this.key = key;
        this.endpoint = endpoint;
    }

    constructor() {
        this.username = localStorage.getItem("username");
        this.key = localStorage.getItem("apiKey");
        this.endpoint = localStorage.getItem("endpoint");
    }

    SaveLogin() {
        localStorage.setItem("username", this.username);
        localStorage.setItem("apiKey", this.key);
        localStorage.setItem("endpoint", this.endpoint);
    }

    static parse_response(data) {

        var response = JSON.parse(data);

        switch (response.method) {
            case "read":
                ApiClient.read_response(response);
            default:
                ApiClient.output("Output: " + response.data);
        }
    }

    static read_response(rsp) {
        var sum = 0;

        for (let i = 0; i < rsp.data.length; i++) {
            sum += (2 ** i) * rsp.data[i];
        }

        ApiClient.output("Card ID: " + sum);
    }

    connect() {
        this.ws = new WebSocket(`ws://${this.server}/`);
    }

    init(server) {
        this.server = server;

        if (this.ws) {
            this.close();
        }

        this.connect();

        // Set event handlers.
        this.ws.onopen = function () {
            ApiClient.output("open!");
        };

        this.ws.onmessage = function (e) {
            // e.data contains received string.
            ApiClient.parse_response(e.data);
        };

        this.ws.onclose = function () {
            ApiClient.output("closed!");
        };

        this.ws.onerror = function (e) {
            ApiClient.output("error: " + e);
            console.log(e);
        };
    }


    send(msg) {
        this.ws.send(msg);
    }

    close() {
        this.ws.close();
    }


    static output(str) {
        var log = document.getElementById("log");
        var escaped = str
            .replace(/&/, "&amp;")
            .replace(/</, "&lt;")
            .replace(/>/, "&gt;")
            .replace(/"/, "&quot;"); // "
        log.innerHTML = escaped + "<br>" + log.innerHTML;
    }

    async register(username, description) {
        var request = await fetch('api/dbuser', {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({
                username: username,
                description: description
            })
        });

        var result = await request.json();
        this.username = result.username;
        this.key = result.authKey;

        this.SaveLogin();

        return result;
    }
}