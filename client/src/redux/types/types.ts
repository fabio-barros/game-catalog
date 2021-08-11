export enum ActionType {
    GAME_LIST_REQUEST = "GAME_LIST_REQUEST",
    GAME_LIST_SUCCESS = "GAME_LIST_SUCCESS",
    GAME_LIST_FAIL = "GAME_LIST_FAIL",

    USER_LOGIN_REQUEST = "USER_LOGIN_REQUEST",
    USER_LOGIN_SUCCESS = "USER_LOGIN_SUCCESS",
    USER_LOGIN_FAIL = "USER_LOGIN_FAIL",

    IS_USER_AUTHENTICATED_REQUEST = "IS_USER_AUTHENTICATED_REQUEST",
    IS_USER_AUTHENTICATED_SUCCESS = "IS_USER_AUTHENTICATED_SUCCESS",
    IS_USER_AUTHENTICATED_FAIL = "IS_USER_AUTHENTICATED_FAIL",

    SIGNUP_REQUEST = "SIGNUP_REQUEST",
    SIGNUP_SUCCESS = "SIGNUP_SUCCESS",
    SIGNUP_FAIL = "SIGNUP_FAIL",
}

export interface GameInterface {
    id: string;
    title: string;
    developer: string;
    publisher: string;
    releaseDate: string; //Date
    coverArtUrl: string;
    price: number;
}

export interface GameState {
    readonly data: GameInterface[];
    readonly loading: boolean;
    readonly error: { message: string; data: string };
}

export interface LoginResponse {
    user: {
        id: string;
        firstName: string;
        lastName: string;
        email: string;
        password: string;
        role: string;
    };
    token: string;
    auth: boolean;
}

export interface LoginState {
    readonly data: LoginResponse;
    readonly loading: boolean;
    readonly error: { message: string; data: string };
}

export interface IsAuthenticatedState {
    readonly data: string;
    readonly loading: boolean;
    readonly error: string;
}

export interface SignUpResponse {
    id: string;
    firstName: string;
    lastName: string;
    email: string;
    password: string;
    role: string;
}

export interface SignUpState {
    readonly data: SignUpResponse;
    readonly loading: boolean;
    readonly error: { message: string; data: string };
}
