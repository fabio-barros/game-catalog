import { Fragment } from "react";
import { Login } from "react-admin";
import { Container } from "react-bootstrap";
import { Provider } from "react-redux";
import {
    BrowserRouter,
    BrowserRouter as Router,
    Route,
    Switch,
} from "react-router-dom";
import { Footer } from "../components/Footer";
import { Header } from "../components/Header";
import { AdminDashboard } from "../components/pages/AdminDashboard";
import { Favorites } from "../components/pages/Favorites";
import { Home } from "../components/pages/Home";
import store from "../redux/store";
import Routes from "../routes/routes";

function App() {
    return (
        <Fragment>
            <Routes />
            {/* <AdminDashboard /> */}
        </Fragment>
    );
}

export default App;
