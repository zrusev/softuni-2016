import React, { Component } from 'react';
import './App.css';
import Street from './Street/Street';
import House from './House/House';
import HouseDetails from './HouseDetails/HouseDetails';

class App extends Component {
  constructor(props) {
    super(props);

    this.state = {
      streets: [],
      selectedStreetIndex: 0,
      selectedHouseIndex: 0,
      hasFetched: false
    }
  }

  componentWillMount() {
    fetch('http://localhost:9999/feed/street/all')
      .then((res) => res.json())
      .then((data) => {
        this.setState({
          streets: data.streets,
          hasFetched: true
        })
      })
  }
  
  getSelectedStreet() {
    return this.state.streets[this.state.selectedStreetIndex].homes;
  }

  getSelectedHouse() {
    return this.state.streets[this.state.selectedStreetIndex].homes[this.state.selectedHouseIndex];
  }

  streetHoverEvent(idx) {
    this.setState({
      selectedStreetIndex: idx
    });
  }

  houseHoverEvent(idx) {
    this.setState({
      selectedHouseIndex: idx
    });
  }

  render() {
    if (!this.state.hasFetched) {
      return null;
    }

    return (
      <div className="App">
        <div className="streets">
          <h2>Streets</h2>
          {
            this.state.streets.length > 0 ? 
            this.state.streets.map((street, idx) => {
              return (<Street location={street.location} key={idx} id={idx} streetHoverEvent={this.streetHoverEvent.bind(this)} />)
            }) :
            null
          }
        </div>

        <div className="houses">
        <h2>Houses</h2>
        {
          this.state.streets.length > 0 ?
          this.getSelectedStreet().map((home, idx) => {
            return (<House type={home.type} description={home.description} id={idx} imageUrl={home.imageUrl} price={home.price} key={idx} houseHoverEvent={this.houseHoverEvent.bind(this)} />)
          }) :
          null
        }
        </div>
        
        {
          this.state.streets.length > 0 ?
          <HouseDetails type={this.getSelectedHouse().type} 
            description={this.getSelectedHouse().description} 
            imageUrl={this.getSelectedHouse().imageUrl} 
            price={this.getSelectedHouse().price} 
            key={this.state.selectedHouseIndex } /> :
            null
        }
      </div>
    );
  }
}

export default App;
