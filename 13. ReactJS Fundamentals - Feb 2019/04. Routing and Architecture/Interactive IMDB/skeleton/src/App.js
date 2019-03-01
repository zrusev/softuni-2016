import React, { Component,  Fragment } from 'react';
import { BrowserRouter as Router, Route, Redirect } from 'react-router-dom';
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

import AppHeader from "./Common/AppHeader";
import Home from './Home/Home';
import Register from './Register/Register';
import Login from './Login/Login';
import Create from './Create/Create';
import Details from './Details/Details';
import './App.css';

class App extends Component {
  constructor(props) {
    super(props);

    this.state = {
      userName: sessionStorage.getItem('userName'),
      isAdmin: sessionStorage.getItem('isAdmin'),
      movies: [],
      selectedMovieId: 0
    }
  }

  registerUser(user) {
    const {
      username,
      password,
      email
    } = user;

    fetch('http://localhost:9999/auth/signup', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json'
        },
        body: JSON.stringify({
          username,
          password,
          email
        })
      })
      .then((res) => res.json())
      .then((data) => {
        if (!data.errors) {
          sessionStorage.setItem('userId', data.userId);
          sessionStorage.setItem('userName', data.username);
          this.setState({
            userName: data.username,
            message: data.message,
            showSnack: true
          });
          toast.success(`Welcome, ${data.username}`, {
            position: "top-center",
            autoClose: 5000,
            hideProgressBar: false,
            closeOnClick: true,
            pauseOnHover: true,
            draggable: true,
            closeButton: false
          });
        } else {
          toast.error(data.errors.message, {
            position: "top-center",
            autoClose: 5000,
            hideProgressBar: false,
            closeOnClick: true,
            pauseOnHover: true,
            draggable: true,
            closeButton: false
          });
        }
      })
      .catch((err) => {
        console.dir(err);
      });
  }

  loginUser(user) {
    const {
      usernameLogin: username,
      passwordLogin: password
    } = user;

    fetch('http://localhost:9999/auth/signin', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json'
        },
        body: JSON.stringify({
          username,
          password
        })
      })
      .then((res) => res.json())
      .then((data) => {
        if (data.username) {
          sessionStorage.setItem('userId', data.userId);
          sessionStorage.setItem('userName', data.username);
          sessionStorage.setItem('userToken', data.token);
          this.setState({
            userName: data.username,
            isAdmin: data.isAdmin
          });
          toast.success(`Welcome, ${data.username}`, {
            position: "top-center",
            autoClose: 5000,
            hideProgressBar: false,
            closeOnClick: true,
            pauseOnHover: true,
            draggable: true,
            closeButton: false
          });
        } else {
          toast.error(data.message, {
            position: "top-center",
            autoClose: 5000,
            hideProgressBar: false,
            closeOnClick: true,
            pauseOnHover: true,
            draggable: true,
            closeButton: false
          });
        }
      })
      .catch((err) => {
        console.dir(err);
      });
  }

  logout() {
    sessionStorage.clear();
    this.setState({
      userName: null,
      isAdmin: null
    });
  }

  createMovie(movie) {
    fetch('http://localhost:9999/feed/movie/create', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json'
        },
        body: JSON.stringify(movie)
      })
      .then((res) => res.json())
      .then((data) => {
        if (!data.errors) {
          toast.success(`Welcome, ${data.message}`, {
            position: "top-center",
            autoClose: 5000,
            hideProgressBar: false,
            closeOnClick: true,
            pauseOnHover: true,
            draggable: true,
            closeButton: false
          });
        } else {
          toast.error(data.errors.message, {
            position: "top-center",
            autoClose: 5000,
            hideProgressBar: false,
            closeOnClick: true,
            pauseOnHover: true,
            draggable: true,
            closeButton: false
          });
        }
      })
      .catch((err) => {
        console.dir(err);
      });
  }

  componentWillMount() {
    const isAdmin = !!sessionStorage.getItem('isAdmin');
    if (sessionStorage.getItem('userName')) {
      this.setState({
        userName: sessionStorage.getItem('userName'),
        isAdmin: isAdmin
      })
    }
    fetch('http://localhost:9999/feed/movies')
    .then((data) => data.json())
    .then((body) => {
      this.setState({
        movies: body.movies
      })
    })
    .catch((err) => {
      console.dir(err);
    });
  }

  render() {
    return (
    <div className = "App">
      <Router >
        <Fragment>
          <AppHeader isAdmin = { this.state.isAdmin } userName = { this.state.userName }/> 
          <ToastContainer position = "top-center" 
                          autoClose = { 5000 }
                          hideProgressBar = { false }
                          newestOnTop = { false }
                          closeOnClick rtl = { false }
                          pauseOnVisibilityChange draggable pauseOnHover />
          <Route path = "/" exact render={(props) => 
              <Home {...props} movies = { this.state.movies } /> } /> 
          <Route path = "/register" exact render = {(props) => 
              <Register {...props} registerUser = { this.registerUser.bind(this) } /> } /> 
          <Route path = "/login" exact render = {() => 
              <Login loginUser = { this.loginUser.bind(this) } /> } /> 
          <Route path = "/create" exact render = {(props) =>              
              this.state.isAdmin ? 
              <Create {...props} createMovie = { this.createMovie.bind(this) } /> :
              <Redirect to={{ pathname: '/login' }} /> } />                           
          <Route path = '/movies/:id' render = {(props) => 
            <Details {...props} movie={this.state.movies[this.state.selectedMovieId]} /> } />
          <Route render = {() => <h1>Not Found</h1>} />
        </Fragment>
      </Router> 
    </div>);
    }
  }

  export default App;