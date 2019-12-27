import React, { Component } from 'react';

export class DbUsers extends Component {

    componentDidMount() {
        this.populateUsersData();
    }

    static renderUserTable(users) {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>Username</th>
                        <th>Description</th>
                    </tr>
                </thead>
                <tbody>
                    {users.map(user =>
                        <tr key={user.DbUserId}>
                            <td>{user.Username}</td>
                            <td>{user.Description}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : FetchData.renderUserTable(this.state.users);

        return (
            <div>
                <h1 id="tabelLabel" >Users</h1>
                <p>This table displays all allowed users</p>
                {contents}
            </div>
        );
    }

    async populateUsersData() {
        const response = await fetch('DbUsers');
        const data = await response.json();
        this.setState({ users: data, loading: false });
    }
}