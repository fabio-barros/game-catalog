import { combineReducers } from "redux";
import { gameListReducer } from "./gameReducers";
import { userLoginReducer } from "./loginReducer";
// import { cartReducer } from "./cartReducers";

const reducers = combineReducers({
    gameList: gameListReducer,
    userLogin: userLoginReducer,
    // cart: cartReducer,
});

export default reducers;
