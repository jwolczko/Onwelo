import React, { Component } from 'react'
import './components.css'

export class Candidates extends Component {

    constructor(props) {
        super(props);
    }

    static renderCandidatesTable(candidates) {
        return (
            <table className="table table-striped" aria-labelledby="tableLabel">
                <thead>
                    <tr>
                        <th>Id</th>
                        <th>Name</th>
                        <th>Votes</th>
                        <th className="button_header">
                            <button onClick={this.props.addCandidateFn} className="header">
                                +
                            </button>
                        </th>
                    </tr>
                </thead>
                <tbody>
                    {candidates.map(candidate =>
                        <tr key={candidate.id}>
                            <td>{candidate.id}</td>
                            <td>{candidate.name}</td>
                            <d> {candidate.votesNumber}</d>
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
                <h3>Candidates</h3>
                {Candidates.renderCandidatesTable(this.props.items)}
            </div>
        );
    }
}