import { Button } from 'bootstrap';
import React, { Component } from 'react';
import Dropdown from 'react-dropdown';
import { Voters } from './Voters'
import { Candidates } from './Candidates'
import { Vote } from './Vote'
import './components.css'
import 'react-dropdown/style.css';

const options = [
    'one', 'two', 'three'
];

const options2 = [
    'Duda', 'Morawiecki', 'Jebany Kaczyñski!'
];

const defaultOption = options[0];
const defaultOption2 = options2[0];

export class Home extends Component {
    static displayName = 'Voting app';

    constructor(props) {
        super(props)
        this.state = this.state = { voters: [], candidates: [], loading: true };
    }

    componentDidMount() {
        this.loadVoters();
        this.loadCandidates();
    }

    addPerson = (e) => {
        e.preventDefault();
        console.log(e.target.value);
    }


    addVoter = (e) => {
        e.preventDefault();
        console.log(e.target.value);
    }

    addCandidate = (e) => {
        e.preventDefault();
        console.log(e.target.value);
    }

    render() {
        return (
            <div>
                <div>
                    <h1>Voting app</h1>
                    <div className="component">
                        <Voters items={this.state.voters} addVoterFn={this.addPerson} />
                    </div>
                    <div className="component">
                        <Candidates items={this.state.candidates} addCandidateFn={this.addPerson} />
                    </div>
                    
                </div>

                <div>
                    <Vote/>
                </div>
            </div>
        );
    }

    async loadVoters() {
        const response = await fetch('http://localhost:5062/api/voters');
        const data = await response.json();
        this.setState({ voters: data, loading: false });
    }


    async loadCandidates() {
        const response = await fetch('http://localhost:5062/api/candidates');
        const data = await response.json();
        this.setState({ candidates: data, loading: false });
    }   
}
