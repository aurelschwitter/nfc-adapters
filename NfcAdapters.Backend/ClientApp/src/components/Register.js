import React, { Component } from 'react';
import { Spinner } from './Spinner';
import { ApiClient } from '../client/ApiClient';


export class Register extends Component {
    static displayName = Register.name;

    constructor(props) {
        super(props);
        this.state = {
            username: "",
            description: navigator.userAgent,
            authenticated: false,
            loading: false
        };

        this.startRegistration = this.startRegistration.bind(this);
    }


    async startRegistration() {
        this.setState({
            loading: true
        });

        var client = new ApiClient();
        var result = await client.register(this.state.username, this.state.description);

        this.setState({
            loading: false
        })
    }


    render() {
        var form_value = (
            <div>
                <h1>Register</h1>

                <p>Register here by pressing "Register" and then scanning the <em>Admin</em> Tag.</p>

                <div className="form-group">
                    <label for="username">Username</label>
                    <input id="username" required className="form-control" type="text" onChange={(e) => this.setState({ username: e.target.value })} placeholder="max" value={this.state.username} />
                    <small className="form-text text-muted">Specify a username of your choice</small>
                </div>
                <div className="form-group">
                    <label for="username">User Agent</label>
                    <input className="form-control" disabled value={navigator.userAgent} type="text" />
                    <small className="form-text text-muted">To identify your device</small>
                </div>
                <button className="btn btn-primary" onClick={this.startRegistration}>Register</button>
            </div>
        );

        var loading_value = (
            <div>
                <h1>Scan Admin Tag</h1>

                <p>Please hold now the <em>Admin</em> Tag on the scanner Admin.</p>

                <Spinner />
            </div>
        );

        return this.state.loading == false ? form_value : loading_value;
    }

}
