import React, {Component} from 'react';
import './App.css';
import AppHeader from "./App/AppHeader";
import AppContent from "./App/AppContent";
import AppFooter from "./App/AppFooter";

class App extends Component {
    constructor(props) {
        super(props);
        this.state = {
            user: null,
            games: [],
            hasFetched: false,
            loginForm: false,
            showSnack: false,
            message: ''
        }
    }

    registerUser(user) {
        const { usernameReg: username, passwordReg:password, emailReg:email } = user;

        fetch('http://localhost:9999/auth/signup', {
            method: 'POST',
            headers: {'Content-Type':'application/json'},
            body: JSON.stringify({
                username, password, email
            })
        })
        .then((res) => res.json())
        .then((data) => {
            if(!data.errors) {                
                sessionStorage.setItem('userId', data.userId);
                sessionStorage.setItem('userName', data.username);
                this.setState({
                    user: data.username,
                    message: data.message,
                    showSnack: true
                });
            }
        })
        .catch((err) => {
            console.dir(err);
        });
    }

    loginUser(user) {
        const { usernameLogin: username, passwordLogin: password } = user;

        fetch('http://localhost:9999/auth/signin', {
            method: 'POST',
            headers: {'Content-Type':'application/json'},
            body: JSON.stringify({
                username, password
            })
        })
        .then((res) => res.json())
        .then((data) => {
            if(!data.errors) {                
                sessionStorage.setItem('userId', data.userId);
                sessionStorage.setItem('userName', data.username);
                sessionStorage.setItem('userToken', data.token);
                this.setState({
                    user: data.username,
                    message: data.message,
                    showSnack: true
                });
            }
        })
        .catch((err) => {
            console.dir(err);
        });
    }

    logout(event) {
        event.preventDefault();
        sessionStorage.clear();
        this.setState({
            user: null,
            message: 'Successfully logged out!',
            showSnack: true
        });
    }

    componentWillMount() {
        const userName = sessionStorage.getItem('userName') || null;

        this.setState({
            user: userName
        });
                
        this.fetchGames();
    }
            
    createGame(data) {
        fetch('http://localhost:9999/feed/game/create', {
            method: 'POST',
            headers: {'Content-Type':'application/json'},
            body: JSON.stringify(data)
        })
        .then((res) => res.json())
        .then((data) => {
            if(!data.errors) {                
                this.fetchGames();
                document.getElementById("create-course-form").reset();
            }
        })
        .catch((err) => {
            console.dir(err);
        });
    }

    fetchGames() {
        fetch('http://localhost:9999/feed/games')
        .then((res) => res.json())
        .then((data) => {
            if(!data.errors) {                
                this.setState({
                    games: data.games,
                    message: data.message,
                    showSnack: true
                });
            }
        })
        .catch((err) => {
            console.dir(err);
        });
    }

    switchForm() {
        this.setState({
            loginForm: !this.state.loginForm 
        })
    }

    render() {
        return (
            <main>
                <AppHeader
                    user={this.state.user}
                    logout={this.logout.bind(this)}
                    switchForm={this.switchForm.bind(this)}
                    loginForm={this.state.loginForm}
                />
                <AppContent
                    registerUser={this.registerUser.bind(this)}
                    loginUser={this.loginUser.bind(this)}
                    games={this.state.games}
                    createGame={this.createGame.bind(this)}
                    user={this.state.user}
                    loginForm={this.state.loginForm}                    
                />
                <AppFooter showSnack={this.state.showSnack} message={this.state.message} />
            </main>
        )
    }
}

export default App;