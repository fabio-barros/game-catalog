import { ActionType } from "../types/types";
import { Dispatch } from "redux";
import axios from "axios";

export const userLoginAction =
    (emai: string, password: string) => async (dispatch: Dispatch) => {
        try {
            console.log(`${process.env.REACT_APP_GAME_CATALOG_API_LOGIN}`);
            dispatch({ type: ActionType.USER_LOGIN_REQUEST });
            const { data } = await axios.post(
                // "https://localhost:5001/api/v1/Game"
                `${process.env.REACT_APP_GAME_CATALOG_API_GAMES}`
            );
            dispatch({
                type: ActionType.USER_LOGIN_SUCCESS,
                payload: data,
            });
        } catch (error) {
            dispatch({
                type: ActionType.USER_LOGIN_FAIL,
                payload:
                    error.response && error.reponse.data.message
                        ? error.reponse.data.message
                        : error.message,
            });
        }
    };
