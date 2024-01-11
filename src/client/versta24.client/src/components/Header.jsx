import React from 'react';
import { Link } from 'react-router-dom';
import 'bootstrap/dist/css/bootstrap.min.css';

export default function Header() {
    return (
        <nav className="navbar navbar-expand-lg navbar-light border-bottom mb-4">
            <Link to="/createOrder" className="navbar-brand">
                <p className="nav-link m-0 px-2">Создание заказа</p>
            </Link>
            <Link to="/" className="navbar-brand">
                <p className="nav-link m-0">Таблица заказов</p>
            </Link>
        </nav>
    );
}
