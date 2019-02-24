import React from 'react';
import './login.css';

class LogInForm extends React.Component {
    constructor(props) {
        super(props);

        this.state = {
            usernameLogin: '',
            passwordLogin: ''
        }
    }

    handleChange = event => {
        this.setState({
          [event.target.id]: event.target.value
        });
    }

    render() {
        return (
            <div className="Login">
                <h1>Login</h1>
                <form onSubmit={(event) => {
                    event.preventDefault();
                    this.props.loginUser(this.state);
                }}>
                    <label>Usersname</label>
                    <input type="text" id="usernameLogin" onChange={this.handleChange} />
                    <label>Password</label>
                    <input type="password" id="passwordLogin" onChange={this.handleChange} />
                    <input type="submit" value="Login"/>
                </form>
            </div>
        )
    }
}

export default LogInForm;
