import { Reducer } from "redux";
import { ActionType, GameState } from "../types/types";

const INITIAL_STATE: GameState = {
    data: [],
    loading: false,
    error: "",
};

export const gameListReducer: Reducer<GameState> = (
    state = INITIAL_STATE,
    action
) => {
    switch (action.type) {
        case ActionType.GAME_LIST_REQUEST:
            return { ...state, loading: true };
        case ActionType.GAME_LIST_SUCCESS:
            return {
                ...state,
                loading: false,
                error: "",
                data: action.payload,
            };
        case ActionType.GAME_LIST_FAIL:
            return {
                ...state,
                loading: false,
                error: action.payload,
                data: [],
            };
        default:
            return state;
    }
};
