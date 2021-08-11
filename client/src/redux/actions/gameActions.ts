import { ActionType } from "../types/types";
import { Dispatch } from "redux";
import axios from "axios";
import { errorTreatment } from "./errorTreatment";

const config = {
    headers: {
        Authorization: `Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJyb2xlIjoidXNlciIsInVuaXF1ZV9uYW1lIjoiV3ljbGVmIEplYW4iLCJuYmYiOjE2Mjg2NTI3NzgsImV4cCI6MTYyODY1NjM3OCwiaWF0IjoxNjI4NjUyNzc4fQ.tWxvpWrjaUvZ2txzVX2iO2E0LoQWzG9GqQq-oO2Ko8M`,
    },
};
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
        // console.log(error);
        dispatch({
            type: ActionType.GAME_LIST_FAIL,
            payload: errorTreatment(error),
            // error.response.status === 400
            //     ? {
            //           message: error.message,
            //           data: error.response.data.errors,
            //       }
            //     : error.response.status === 402 ||
            //       error.response.status === 422
            //     ? { message: error.message, data: error.response.data }
            //     : error.response.status === 401
            //     ? { message: error.message, data: "Unauthorized" }
            //     : error,
        });
    }
};
