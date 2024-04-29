import React from 'react';
import { NavLink, Link } from 'react-router-dom';
import {FontAwesomeIcon} from "@fortawesome/react-fontawesome";
import Logo from "../../assets/images/Logo.svg";
const Header = () => {
    return (
        <header>
            <div className='container'>
                <Link className='logo'  to="/">
                    <img src={Logo} alt="Logotype" />
                </Link>
                <nav>
                    <NavLink to="/">Overview</NavLink>
                    <NavLink to="/features">Features</NavLink>
                    <NavLink to="/contact">Contact</NavLink>

                </nav>
                <div className='btn-toggle' id="theme-mode">
                    <label htmlFor='toggle-theme-mode'>Light</label>
                    <label htmlFor='toggle-theme-mode' className='toggle-switch'>
                        <input type="checkbox" id="toggle-theme-mode"/>
                        <span className='slider round'></span>
                    </label>
                    <label htmlFor='toggle-theme-mode'>Dark</label>
                </div>
                <div className='account-buttons'>
                    <Link className='btn btn-gray' to="/signin"><i className="fa-solid fa-right-to-bracket"></i> Sign in</Link>
                    <Link className='btn btn-theme' to="/signup"><i className="fa-solid fa-user"></i> Sign up</Link>
                </div>
                <button className='btn-bars'><i className="fa-solid fa-bars"></i></button>
            </div>
        
        </header>
    )
}

export default Header