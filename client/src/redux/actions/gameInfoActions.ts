import { ActionType } from "../types/types";
import { Dispatch } from "redux";
import axios from "axios";
import { errorTreatment } from "./errorTreatment";

export const addGameToUserList = () => async (dispatch: Dispatch) => {
    try {
        console.log(`${process.env.REACT_APP_GAME_CATALOG_API_GAME_INFO}`);
        dispatch({ type: ActionType.GAME_LIST_REQUEST });
        const { data } = await axios.post(
            `${process.env.REACT_APP_GAME_CATALOG_API_GAME_INFO}`
        );

        dispatch({
            type: ActionType.GAME_LIST_SUCCESS,
            payload: data,
        });
    } catch (error) {
        dispatch({
            type: ActionType.GAME_LIST_FAIL,
            payload: errorTreatment(error),
        });
    }
};

export const deleteGameFromUserList = () => async (dispatch: Dispatch) => {
    try {
        console.log(`${process.env.REACT_APP_GAME_CATALOG_API_GAME_INFO}`);
        dispatch({ type: ActionType.GAME_LIST_REQUEST });
        const { data } = await axios.delete(
            `${process.env.REACT_APP_GAME_CATALOG_API_GAME_INFO}`
        );

        dispatch({
            type: ActionType.GAME_LIST_SUCCESS,
            payload: data,
        });
    } catch (error) {
        dispatch({
            type: ActionType.GAME_LIST_FAIL,
            payload: errorTreatment(error),
        });
    }
};
