import React, { Component } from 'react';
import { ApiClient } from '../client/ApiClient';

export class Home extends Component {
    static displayName = Home.name;

    constructor(props) {
        super(props);
        this.state = { server: "" };
        this.apiClient = new ApiClient();
    }



    render() {
        return (
            <main className="container">
                <div className="form-container">
                    <div className="form-row">
                        <label className="col-md-4">Server: <input className="form-control" type="text" id="server" onChange={(e) => { this.setServerName(e.target.value) }} /></label>
                        <div className="col-md-4">
                            <button className="btn btn-secondary" type="button" onClick={() => this.init()}>Update Server</button>
                        </div>
                    </div>
                    <div className="btn-group">
                        <button className="btn btn-secondary" disabled={ (this.state.server == "") } onClick={() => { this.apiClient.close() }}>close</button>
                        <button className="btn btn-secondary" disabled={ this.state.server == ""} onClick={() => { this.read() }} type="button">READ</button>
                    </div>
                    <div id="log"></div>
                </div>
            </main>
        );
    }

    setServerName(serverName) {
        this.setState({
            server: serverName
        });
    }

    read() {
        ApiClient.output('read');
        this.apiClient.send('read');
    }

    init() {
        this.apiClient.init(this.state.server);
    }
}
