import { Reducer } from "redux";
import { ActionType, LoginState, LoginResponse } from "../types/types";

const LOGIN_INITIAL_STATE: LoginState = {
    data: {},
    loading: false,
    error: "",
};

export const userLoginReducer: Reducer<LoginState> = (
    state: LoginState = LOGIN_INITIAL_STATE,
    action
) => {
    switch (action.type) {
        case ActionType.USER_LOGIN_REQUEST:
            return { ...state, loading: true };
        case ActionType.USER_LOGIN_SUCCESS:
            return {
                ...state,
                loading: false,
                error: "",
                data: action.payload,
            };
        case ActionType.USER_LOGIN_FAIL:
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
