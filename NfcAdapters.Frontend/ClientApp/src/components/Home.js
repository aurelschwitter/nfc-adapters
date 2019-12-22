import React, { Component } from 'react';

export class Home extends Component {
    static displayName = Home.name;

    render() {
        return (
            <main class="container">
                <div class="form-container">
                    <div class="form-row">
                        <label class="col-md-4">Server: <input class="form-control" type="text" id="server" /></label>
                        <div class="col-md-4">
                            <button class="btn btn-secondary" type="button" onclick="init();">Update Server</button>
                        </div>
                    </div>
                    <div class="btn-group">
                        <button class="btn btn-secondary" onclick="onCloseClick(); return false;">close</button>
                        <button class="btn btn-secondary" onclick="output('read'); send('read'); return false;" type="button">READ</button>
                    </div>
                </div>
                <div id="log"></div>
            </main>
        );
    }
}
