import { Reducer } from "redux";
import { ActionType, SignUpState } from "../types/types";

const SIGNUP_INITIAL_STATE: SignUpState = {
    data: {
        id: "",
        firstName: "",
        lastName: "",
        email: "",
        password: "",
        role: "",
    },
    loading: false,
    error: { message: "", data: "" },
};

export const signUpReducer: Reducer<SignUpState> = (
    state = SIGNUP_INITIAL_STATE,
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
                data: SIGNUP_INITIAL_STATE.data,
            };
        default:
            return state;
    }
};
