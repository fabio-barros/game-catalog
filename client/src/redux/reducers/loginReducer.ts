import { Reducer } from "redux";
import { ActionType, LoginState, LoginResponse } from "../types/types";

const LOGIN_INITIAL_STATE: LoginState = {
    data: {
        user: {
            id: "",
            firstName: "",
            lastName: "",
            email: "",
            password: "",
            role: "",
            games: [
                {
                    gameFromMongoId: "",
                },
            ],
        },
        token: "",
        auth: false,
    },
    loading: false,
    error: { message: "", data: "" },
};

export const userLoginReducer: Reducer<LoginState> = (
    state = LOGIN_INITIAL_STATE,
    action
) => {
    switch (action.type) {
        case ActionType.USER_LOGIN_REQUEST:
            return { ...state, loading: true };
        case ActionType.USER_LOGIN_SUCCESS:
            return {
                ...state,
                loading: false,
                error: { message: "", data: "" },
                data: action.payload,
            };
        case ActionType.USER_LOGIN_FAIL:
            return {
                ...state,
                loading: false,
                error: action.payload,
                data: LOGIN_INITIAL_STATE.data,
            };
        default:
            return state;
    }
};
