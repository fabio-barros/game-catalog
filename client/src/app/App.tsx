import { Container } from "react-bootstrap";
import { Provider } from "react-redux";
import store from "../redux/store";
import Routes from "../routes/routes";

function App() {
    return (
        <Provider store={store}>
            <main className="py-3">
                <Container fluid>
                    <Routes />
                </Container>
            </main>
        </Provider>
    );
}

export default App;
