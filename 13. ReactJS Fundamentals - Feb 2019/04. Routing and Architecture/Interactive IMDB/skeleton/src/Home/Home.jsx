import React, { Component } from 'react';
import './Home.css'

class Home extends Component {
  constructor(props){
    super(props);
  }
  
  render() {
    return (
      <div className="Home">
        <h1>All movies</h1>
        <ul className="movies">
          {
            this.props.movies.map((mov, ind) => 
            (<li key={mov._id} className="movie">
                <h2>{mov.title}</h2>
                <img src={mov.poster} alt='' />
              </li>))   
          }
        </ul>
    </div>
    );
  }
}

export default Home;
