class ApiClient {


    constructor(username, key, endpoint) {
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



}