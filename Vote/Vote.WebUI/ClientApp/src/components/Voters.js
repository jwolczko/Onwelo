import React, { Component } from 'react'
import { Button } from 'bootstrap';
import './components.css'

export class Voters extends Component {

    constructor(props) {
        super(props);
    }

    static renderVotersTable(voters) {
        return (
            <table className="table table-striped" aria-labelledby="tableLabel">
                <thead>
                    <tr>
                        <th>Id</th>
                        <th>Name</th>
                        <th>Has voted</th>
                        <th className="button_header">
                            <button onClick={this.props.addVoterFn} className="header">
                                +
                            </button>
                        </th>

                    </tr>
                </thead>
                <tbody>
                    {voters.map(voter =>
                        <tr key={voter.id}>
                            <td>{voter.id}</td>
                            <td>{voter.name}</td>
                            <td>{voter.hasVote}</td>
                            <td></td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    render() {
        return (
            <div>
            <h3>Voters</h3>
                {Voters.renderVotersTable(this.props.items)}
            </div>
        );
    }
}