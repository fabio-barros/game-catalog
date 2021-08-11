import { combineReducers } from "redux";
import { gameListReducer } from "./gameReducers";
import { isUserAthenticatedReducer, userLoginReducer } from "./loginReducer";
import { signUpReducer } from "./userReducers";
// import { cartReducer } from "./cartReducers";

const reducers = combineReducers({
    gameList: gameListReducer,
    userLogin: userLoginReducer,
    signup: signUpReducer,
    isAuthenticated: isUserAthenticatedReducer,
    // cart: cartReducer,
});

export default reducers;
