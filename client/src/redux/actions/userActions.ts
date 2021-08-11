import { ActionType } from "../types/types";
import { Dispatch } from "redux";
import axios from "axios";
import { errorTreatment } from "./errorTreatment";

export const signInAction =
    (
        email: string,
        firstName: string,
        lastName: string,
        password: string,
        confirmPassword: string,
        role: string
    ) =>
    async (dispatch: Dispatch) => {
        try {
            dispatch({ type: ActionType.SIGNUP_REQUEST });
            const { data } = await axios.post(
                `${process.env.REACT_APP_GAME_CATALOG_API_USER}`,
                {
                    email: email,
                    firstName: firstName,
                    lastName: lastName,
                    password: password,
                    confirmPassword: confirmPassword,
                    role: role,
                }
            );
            dispatch({
                type: ActionType.SIGNUP_SUCCESS,
                payload: data,
            });
        } catch (error) {
            dispatch({
                type: ActionType.SIGNUP_FAIL,
                payload: errorTreatment(error),
            });
        }
    };
