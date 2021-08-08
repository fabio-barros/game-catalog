import { ActionType } from "../types/types";
import { Dispatch } from "redux";
import axios from "axios";

export const listProducts = () => async (dispatch: Dispatch) => {
    try {
        console.log(`${process.env.REACT_APP_GAME_CATALOG_API_GAMES}`);
        dispatch({ type: ActionType.GAME_LIST_REQUEST });
        const { data } = await axios.get(
            // "https://localhost:5001/api/v1/Game"
            `${process.env.REACT_APP_GAME_CATALOG_API_GAMES}`
        );
        dispatch({
            type: ActionType.GAME_LIST_SUCCESS,
            payload: data,
        });
    } catch (error) {
        dispatch({
            type: ActionType.GAME_LIST_FAIL,
            payload:
                error.response && error.reponse.data.message
                    ? error.reponse.data.message
                    : error.message,
        });
    }
};
