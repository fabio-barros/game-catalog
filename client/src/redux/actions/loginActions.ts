import { ActionType } from "../types/types";
import { Dispatch } from "redux";
import axios from "axios";
import { errorTreatment } from "./errorTreatment";

export const authConfigToken = {
    headers: {
        Authorization: `Bearer ${JSON.parse(
            localStorage.getItem("token") || "{}"
        )}`,
    },
};

export const userLoginAction =
    (email: string, password: string) => async (dispatch: Dispatch) => {
        try {
            dispatch({ type: ActionType.USER_LOGIN_REQUEST });
            const { data } = await axios.post(
                // "https://localhost:5001/api/v1/Game"
                `${process.env.REACT_APP_GAME_CATALOG_API_LOGIN}`,
                { email: email, password: password }
            );
            localStorage.setItem("token", JSON.stringify(data.token));
            localStorage.setItem("userId", JSON.stringify(data.user.id));
            dispatch({
                type: ActionType.USER_LOGIN_SUCCESS,
                payload: data,
            });
        } catch (error) {
            dispatch({
                type: ActionType.USER_LOGIN_FAIL,
                payload: errorTreatment(error),
            });
        }
    };

export const isUserAthenticatedAction = () => async (dispatch: Dispatch) => {
    try {
        dispatch({ type: ActionType.IS_USER_AUTHENTICATED_REQUEST });
        const { data } = await axios.get(
            `${process.env.REACT_APP_GAME_CATALOG_API_LOGIN}/authenticated`,
            authConfigToken
        );
        dispatch({
            type: ActionType.IS_USER_AUTHENTICATED_SUCCESS,
            payload: data,
        });
    } catch (error) {
        const err = errorTreatment(error);
        dispatch({
            type: ActionType.IS_USER_AUTHENTICATED_FAIL,
            payload: err.data ? err.data : err.message,
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
