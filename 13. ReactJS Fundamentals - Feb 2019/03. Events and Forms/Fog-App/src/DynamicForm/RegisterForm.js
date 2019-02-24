import React from 'react';
import './register.css';

class RegisterForm extends React.Component {
    constructor(props) {
        super(props);

        this.state = {
            usernameReg: '',
            emailReg: '',
            passwordReg: ''
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
                <h1>Sign Up</h1>
                <form onSubmit={(event) => {
                    event.preventDefault();
                    this.props.registerUser(this.state);
                }}>
                    <label>Username</label>
                    <input type="text" id="usernameReg" onChange={this.handleChange} />
                    <label>Email</label>
                    <input type="text" id="emailReg" onChange={this.handleChange} />
                    <label>Password</label>
                    <input type="password" id="passwordReg" onChange={this.handleChange} />
                    <input type="submit" value="Sign Up"/>
                </form>
            </div>
        )
    }
}
export default RegisterForm;