import axios from "axios";
import { errorTreatment } from "../redux/actions/errorTreatment";

export const authConfigToken = {
    headers: {
        Authorization: `Bearer ${JSON.parse(
            localStorage.getItem("token") || "{}"
        )}`,
    },
};

export const isAuthenticated = async () => {
    try {
        console.log(authConfigToken);
        var { data } = await axios.get(
            `${process.env.REACT_APP_GAME_CATALOG_API_LOGIN}/authenticated`,
            authConfigToken
        );
        console.log(`AUTH: ${data}`);
        return data;
    } catch (error) {
        const err = errorTreatment(error);
        console.log(err.data ? err.data : err.message);
        return err.data ? err.data : err.message;
    }
};
