import React, { Component } from 'react';
import './Login.css';

class Login extends Component {
  constructor (props) {
    super(props);

    this.state = {
      username: '',
      password: ''       
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
          <label htmlFor="usernameLogin">Username</label>
          <input type="text" id="usernameLogin" onChange={this.handleChange} />
          
          <label htmlFor="passwordLogin">Password</label>
          <input type="password" id="passwordLogin" onChange={this.handleChange} />
          
          <input type="submit" value="Login" />
        </form>
      </div>
    );
  }
}

export default Login;
