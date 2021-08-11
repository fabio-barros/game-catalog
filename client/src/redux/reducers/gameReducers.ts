import { Reducer } from "redux";
import { ActionType, GameState } from "../types/types";

const INITIAL_STATE: GameState = {
    data: [
        {
            id: "60cf6ad2fc13ae61f6000073",
            title: "Hot Dog... The Movie",
            developer: "Waelchi, Von and Hudson",
            publisher: "Paucek, Ondricka and O'Keefe",
            releaseDate: "7-13-2020",
            price: 150.45,
            coverArtUrl: "http://dummyimage.com/137x100.png/5fa2dd/ffffff",
        },
    ],
    loading: false,
    error: { message: "", data: "" },
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
                error: { message: "", data: "" },
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
