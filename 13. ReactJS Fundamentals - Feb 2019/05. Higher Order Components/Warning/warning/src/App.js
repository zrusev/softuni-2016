import React, { Component } from 'react';
import Article from './components/Article/Article'
import RegisterForm from './components/RegisterForm/RegisterForm'
import Navigation from './components/Navigation/Navigation'
import BindingForm from './components/BindingForm/BindingForm';
import warningWrapper from './hoc/warningWrapper';
import errorHandlingWrapper from './hoc/errorHandlingWrapper';
import './App.css';

const ArticleWithWarning = warningWrapper(errorHandlingWrapper(Article));
const RegisterFormWithWarning = warningWrapper(errorHandlingWrapper(RegisterForm));
const NavigationWithWarning = warningWrapper(errorHandlingWrapper(Navigation));

class App extends Component {
  onSubmit(e, data) {
    e.preventDefault();
    console.log(data);
  }

  render() {
    return (
      <section className="App">     
          <BindingForm onSubmit={this.onSubmit}>
            <input type="text" name="username" placeholder="username" />
            <input type="password" name="password" placeholder="password" />
          </BindingForm>   
          <ArticleWithWarning />
          <RegisterFormWithWarning />
          <NavigationWithWarning />        
      </section>
    )
  }
}

export default App;
