import { createStore, applyMiddleware, Store } from "redux";
import reducers from "./reducers/rootReducer";
import thunk from "redux-thunk";
import { composeWithDevTools } from "redux-devtools-extension";
import { createLogger } from "redux-logger";
import { GameState } from "./types/types";

export interface ApplicationSate {
    gameList: GameState;
}

// const cartItemsFromStorage = localStorage.getItem("cartItems")
//     ? JSON.parse(localStorage.getItem("cartItems"))
//     : [];

// const initialState = {
//     cart: { cartItems: cartItemsFromStorage },
// };

const middlewares = [thunk];

const logger = createLogger();
const store: Store<ApplicationSate> = createStore(
    reducers,
    // initialState,
    composeWithDevTools(applyMiddleware(...middlewares, logger))
);

export default store;
