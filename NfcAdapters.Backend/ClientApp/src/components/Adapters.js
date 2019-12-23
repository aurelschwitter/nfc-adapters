import React, { Component } from 'react';

export class AdapterTypes extends Component {

    componentDidMount() {
        this.populateAdapterData();
    }

    static renderAdapesTable(adapters) {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>Picture</th>
                        <th>Description</th>
                        <th>Available?</th>
                    </tr>
                </thead>
                <tbody>
                    {adapters.map(adapter =>
                        <tr key={adapter.Picture}>
                            <td>{adapter.Description}</td>
                            <td>{adapter.NrAvailable}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : FetchData.renderAdaperTable(this.state.adaperTypes);

        return (
            <div>
                <h1 id="tabelLabel" >Users</h1>
                <p>This table displays all allowed users</p>
                {contents}
            </div>
        );
    }

    async populateAdapterData() {
        const response = await fetch('api/Adapters');
        const data = await response.json();
        this.setState({ adaperTypes: data, loading: false });
    }
}