import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import './style/index.css';
import './style/app.css';
// import App from './App/App';
// import * as serviceWorker from './serviceWorker';
import contacts from './data/contacts.json';

const htmlArray = [];

const handleContactClick = (index) => {
    currentlySelectedContactIndex = index;
    render();
}

contacts.forEach((contact, index) => {
    htmlArray.push(<div onClick={() => handleContactClick(index)} key={index} className="contact">
    <span className="avatar small">&#9787;</span>
    <span className="title">{contact.firstName} {contact.lastName}</span>
    </div>)
});

let currentlySelectedContactIndex = 3;

const Main = () => (
    <div class="container">
        <header>&#9993; Contact Book</header>
        <div id="book">
            <div id="list">
                <h1>Contacts</h1>
                <div class="content">
                    <Contacts />
                </div>
            </div>
            <Details index={currentlySelectedContactIndex} />
        </div>
    </div>
)

const Contacts = () => (
    htmlArray
)

const Details = (props) => (
    <div id="details">
        <h1>Details</h1>
        <div class="content">
            <div class="info">
                <div class="col">
                    <span class="avatar">&#9787;</span>
                </div>
                <div class="col">
                    <span class="name">{contacts[props.index].firstName}</span>
                    <span class="name">{contacts[props.index].lastName}</span>
                </div>
            </div>
            <div class="info">
                <span class="info-line">&phone; {contacts[props.index].phone}</span>
                <span class="info-line">&#9993; {contacts[props.index].email}</span>
            </div>
        </div>
    </div>
)

const render = () => ReactDOM.render(<Main />, document.getElementById('root'));

render();

// If you want your app to work offline and load faster, you can change
// unregister() to register() below. Note this comes with some pitfalls.
// Learn more about service workers: http://bit.ly/CRA-PWA
// serviceWorker.unregister();
