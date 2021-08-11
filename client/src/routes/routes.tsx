import { Component } from "react";
import { Container } from "react-bootstrap";
import { Provider } from "react-redux";
import { BrowserRouter, Switch, Route, Redirect } from "react-router-dom";
import { isAuthenticated } from "../authentication/auth";
import { Footer } from "../components/Footer";
import { Header } from "../components/Header";
import { AdminDashboard } from "../components/pages/AdminDashboard";
import { Favorites } from "../components/pages/Favorites";
import { Home } from "../components/pages/Home";
import { Login } from "../components/pages/Login";
import store from "../redux/store";

const Routes = () => {
    return (
        <Provider store={store}>
            <BrowserRouter>
                <Header />
                <main className="py-3 ">
                    <Container fluid>
                        <Switch>
                            <Route exact path="/" component={Home} />
                            <Route exact path="/home" component={Home} />
                            <Route
                                exact
                                path="/auth/signin"
                                component={Login}
                            />
                            {/* <Route path="/auth/register" component={Login} /> */}
                            <Route
                                path="/favorites"
                                component={Favorites}
                                exact
                            />
                            <Route
                                path="/auth/admin-dashboard"
                                component={AdminDashboard}
                                exact
                            />
                            {/* <Route path="/product/:id" component={ProductScreen} /> */}
                            {/* <Route path="/cart/:id?" component={CartScreen} /> */}
                        </Switch>
                    </Container>
                </main>
            </BrowserRouter>
            <Footer />;
        </Provider>
    );
};

export default Routes;
