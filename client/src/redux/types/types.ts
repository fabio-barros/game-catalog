export enum ActionType {
    GAME_LIST_REQUEST = "GAME_LIST_REQUEST",
    GAME_LIST_SUCCESS = "GAME_LIST_SUCCESS",
    GAME_LIST_FAIL = "GAME_LIST_FAIL",
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
    readonly error: string;
}
