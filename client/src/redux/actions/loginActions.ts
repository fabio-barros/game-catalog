import { ActionType } from "../types/types";
import { Dispatch } from "redux";
import axios from "axios";

export const userLoginAction =
    (email: string, password: string) => async (dispatch: Dispatch) => {
        try {
            console.log(`${process.env.REACT_APP_GAME_CATALOG_API_LOGIN}`);
            dispatch({ type: ActionType.USER_LOGIN_REQUEST });
            const { data } = await axios.post(
                // "https://localhost:5001/api/v1/Game"
                `${process.env.REACT_APP_GAME_CATALOG_API_LOGIN}`,
                { email: email, password: password }
            );
            dispatch({
                type: ActionType.USER_LOGIN_SUCCESS,
                payload: data,
            });
        } catch (error) {
            dispatch({
                type: ActionType.USER_LOGIN_FAIL,
                payload:
                    error.response.status === 400
                        ? {
                              message: error.message,
                              data: error.response.data.errors,
                          }
                        : error.response.status === 402 ||
                          error.response.status === 422
                        ? { message: error.message, data: error.response.data }
                        : error,
            });
        }
    };

//400 .response.status === 400 -> {message: error.message, data: error.response.data.errors}
//402 .response.status === 402 -> {message: error.message, data: error.response.data}
//422 .response.status === 402 -> {message: error.message, data: error.response.data}

// error.reponse.status === "402" ||
//                     error.reponse.status === "422"
//                         ? { message: error.message, data: error.response.data }
//                         : error.response.status === "400"
//                         ? {
//                               message: error.message,
//                               data: error.response.data.errors,
//                           }
//                         : error,
