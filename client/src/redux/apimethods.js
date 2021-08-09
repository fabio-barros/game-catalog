import axios from "axios";

const register = async (params) => {
    await axios.post(`${process.env.REACT_APP_GAME_CATALOG_API_USER}`, {
        id: "",
        firstName: "",
        lastName: "",
        email: "",
        password: "",
        confirmPassword: "",
        role: "",
        games: [
            {
                gameFromMongoId: "",
            },
        ],
    });
};
const login = async (params) => {
    await axios.post(`${process.env.REACT_APP_GAME_CATALOG_API_USER}`, {
        email: "",
        password: "",
    });
};
