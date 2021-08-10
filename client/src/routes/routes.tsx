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
                <Route exact path="/" component={Home} />
                <Route exact path="/home" component={Home} />
                <Route exact path="/auth/signin" component={Login} />
                {/* <Route path="/auth/register" component={Login} /> */}
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
