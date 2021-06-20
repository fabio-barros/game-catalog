import { combineReducers } from "redux";
import { gameListReducer } from "./gameReducers";
// import { cartReducer } from "./cartReducers";

const reducers = combineReducers({
    gameList: gameListReducer,
    // productDetails: productDetailsReducer,
    // cart: cartReducer,
});

export default reducers;
