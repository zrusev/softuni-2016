import React, { Component } from 'react';
import './Register.css';

class Register extends Component {
  constructor (props) {
    super(props);

    this.state = {
      username: '',
      email: '',
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
    <div className="Register">
      <h1>Register</h1>

      <form onSubmit={(event) => {
        event.preventDefault();
        this.props.registerUser(this.state);
      }}>
        <label htmlFor="username">Username</label>
        <input type="text" id="username" onChange={this.handleChange} />

        <label htmlFor="email">Email</label>
        <input type="text" id="email" onChange={this.handleChange} />

        <label htmlFor="password">Password</label>
        <input type="password" id="password" onChange={this.handleChange} />

        <input type="submit" value="REGISTER" />
      </form>
    </div>          
   );
  }
}

export default Register;