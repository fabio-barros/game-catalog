import { Container } from "react-bootstrap";
import { BrowserRouter as Router, Route } from "react-router-dom";
import { Home } from "../components/pages/Home";
import { Provider } from "react-redux";
import store from "../redux/store";
function App() {
    return (
        <Provider store={store}>
            <Router>
                <main className="py-3">
                    <Container fluid>
                        <Route path="/" component={Home} exact />
                        {/* <Route path="/product/:id" component={ProductScreen} /> */}
                        {/* <Route path="/cart/:id?" component={CartScreen} /> */}
                    </Container>
                </main>
            </Router>
        </Provider>
    );
}

export default App;
