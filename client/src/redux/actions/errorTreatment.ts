export const errorTreatment = (error) => {
    if (error.response.status === 400) {
        return { message: error.message, data: error.response.data.errors };
    } else if (error.response.status === 402 || error.response.status === 422) {
        return { message: error.message, data: error.response.data };
    } else if (error.response.status === 401) {
        return { message: error.message, data: "Unauthorized" };
    } else {
        return error;
    }
};
