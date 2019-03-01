import React, { Component } from 'react';
import './Create.css';

class Create extends Component {
  constructor(props) {
    super(props);

    this.state = {
      title: null,
      storyLine: null,
      trailerUrl: null,
      poster: null
    }
  }

  handleChange = event => {
    this.setState({
      [event.target.id]: event.target.value
    });
  }
  
  render() {
    return (
      <div className="Create">
        <h1>Create Movie</h1>
        <form onSubmit={(event) => {
          event.preventDefault();
          this.props.createMovie(this.state);
        }}>
          <label htmlFor="title">Title</label>
          <input type="text" id="title" onChange={this.handleChange} />

          <label htmlFor="storyLine">Story Line</label>
          <input type="text" id="storyLine" onChange={this.handleChange} />

          <label htmlFor="trailerUrl">Trailer Url</label>
          <input type="text" id="trailerUrl" onChange={this.handleChange} />

          <label htmlFor="poster">Movie Poster</label>
          <input type="text" id="poster" onChange={this.handleChange} />

          <input type="submit" value="Create" />
        </form>
      </div>
    );
  }
}

export default Create;
