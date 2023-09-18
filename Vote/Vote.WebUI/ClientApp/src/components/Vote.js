import React, { Component } from 'react'
import Dropdown from 'react-dropdown';
import './components.css'

export class Vote extends Component {

    constructor(props) {
        super(props);
        this.state = { voters: [], candidates: [], loading: true };
    }

    componentDidMount() {
        this.loadVoters();
        this.loadCandidates();
    }

    voting() {

    }

    render() {
        return (
            <div>
                <div>
                    <h3>Vote!</h3>
                    <div className="component">
                        <Dropdown options={this.state.voters} onChange={this._onSelect} placeholder="I am" />
                    </div>
                    <div className="component">
                        <Dropdown options={this.state.candidates} onChange={this._onSelect} placeholder="I vote for" />
                    </div>
                    <div className="component2">
                        <button onClick={this.voting}>
                            Submit!
                        </button>
                    </div>
                </div>
            </div>
        );
    }


    async loadVoters() {
        const response = await fetch('http://localhost:5062/api/voters');
        const data = await response.json();

        let voters = [];

        data.forEach((voter) => voters.unshift({ value: voter, label: voter.name }));

        this.setState({ voters: voters, loading: false });
    }

    async loadCandidates() {
        const response = await fetch('http://localhost:5062/api/candidates');
        const data = await response.json();

        let candidates = [];

        data.forEach((candidate) => candidates.unshift({ value: candidate, label: candidate.name }));
                
        this.setState({ candidates: candidates, loading: false });
    }
}