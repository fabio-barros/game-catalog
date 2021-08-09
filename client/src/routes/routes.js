import { Component } from "react";
import { BrowserRouter, Switch, Route, Redirect } from "react-router-dom";
import { isAuthenticated } from "../authentication/auth";
import { AdminDashboard } from "../components/pages/AdminDashboard";
import { Favorites } from "../components/pages/Favorites";
import { Home } from "../components/pages/Home";
import { Login } from "../components/pages/Login";

const PrivateRoute = ({ component: Component, ...rest }) => {
    return (
        <Route
            {...rest}
            render={(props) =>
                isAuthenticated() ? (
                    <Component {...props} />
                ) : (
                    <Redirect
                        to={{ pathname: "/", state: { from: props.location } }}
                    />
                )
            }
        />
    );
};
const Routes = () => {
    return (
        <BrowserRouter>
            <Switch>
                <Route path="/" component={Home} exact />
                <Route path="/login" component={Login} />
                <Route path="/home" component={Home} exact />
                <PrivateRoute
                    path="/home/favorites"
                    component={Favorites}
                    exact
                />
                <Route
                    path="/home/admin-dashboard"
                    component={AdminDashboard}
                    exact
                />
                {/* <Route path="/product/:id" component={ProductScreen} /> */}
                {/* <Route path="/cart/:id?" component={CartScreen} /> */}
            </Switch>
        </BrowserRouter>
    );
};

export default Routes;
