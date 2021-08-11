export enum ActionType {
    GAME_LIST_REQUEST = "GAME_LIST_REQUEST",
    GAME_LIST_SUCCESS = "GAME_LIST_SUCCESS",
    GAME_LIST_FAIL = "GAME_LIST_FAIL",

    USER_LOGIN_REQUEST = "USER_LOGIN_REQUEST",
    USER_LOGIN_SUCCESS = "USER_LOGIN_SUCCESS",
    USER_LOGIN_FAIL = "USER_LOGIN_FAIL",
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
        games?: [
            {
                gameFromMongoId: string;
            }
        ];
    };
    token: string;
    auth: boolean;
}

export interface LoginState {
    readonly data: LoginResponse;
    readonly loading: boolean;
    readonly error: { message: string; data: string };
}
