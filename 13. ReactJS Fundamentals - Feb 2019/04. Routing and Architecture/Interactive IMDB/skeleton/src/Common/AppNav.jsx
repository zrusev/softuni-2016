import React from 'react';
import { NavLink } from 'react-router-dom';

function AppNav(props) {
    return (
        <header>
            <NavLink to="/" className="logo">Interactive IMDB</NavLink>
            <div className="header-right">
            <NavLink to="/">Home</NavLink>            
            {
                props.userName 
                ?
                (<span>
                    <a href="#">Welcome, {props.userName}</a>
                    {
                        props.isAdmin ?
                        (<NavLink to="/create">Create</NavLink>) :
                        null
                    }
                    <a href="#">Logout</a>
                </span>) 
                :                        
                (<span>
                    <NavLink to="/register">Register</NavLink>
                    <NavLink to="/login">Login</NavLink>
                </span>)
            }            
            </div>
        </header>
    )
}

export default AppNav;