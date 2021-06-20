import { ActionType } from "../types/types";
import { Dispatch } from "redux";
import axios from "axios";

export const listProducts = () => async (dispatch: Dispatch) => {
    try {
        dispatch({ type: ActionType.GAME_LIST_REQUEST });
        const { data } = await axios.get(`${process.env.REACT_APP_DOTNET_API}`);
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
