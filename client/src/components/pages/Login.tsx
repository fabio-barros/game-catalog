import axios from "axios";
import {
    Dispatch,
    FC,
    FormEvent,
    Fragment,
    useEffect,
    useState,
    Component,
} from "react";
import { Button, Card, Form, Row } from "react-bootstrap";
import { useDispatch, useSelector } from "react-redux";
import { LoginResponse, LoginState } from "../../redux/types/types";
import { userLoginAction } from "../../redux/actions/loginActions";
import { ApplicationSate } from "../../redux/store";
import { Redirect, Route, RouteComponentProps } from "react-router";
import { Home } from "./Home";
import { LoginForm } from "../LoginForm";
import { Loader } from "../Loader";
import { Message } from "../Message";

interface LoginProps extends RouteComponentProps {}

type errorType = {
    error: {
        message: string;
        data: string;
    };
};

export const Login: FC<LoginProps> = ({ location }) => {
    const [emailLog, setEmailLog] = useState("");
    const [passwordLog, setPasswordLog] = useState("");

    const dispatch: Dispatch<any> = useDispatch();

    const userLoginResponse: LoginState = useSelector(
        (state: ApplicationSate) => {
            console.log(`state: ${state}`);
            return state.userLogin;
        }
    );

    const { loading, error, data } = userLoginResponse;

    const fetchUserData = () => {
        dispatch(userLoginAction(emailLog, passwordLog));
        console.log(error);
    };

    const loginHandler = async (e: FormEvent<HTMLElement>) => {
        e.preventDefault();
        fetchUserData();
    };

    useEffect(() => {}, []);

    return (
        <>
            <LoginForm
                setEmailLog={setEmailLog}
                setPasswordLog={setPasswordLog}
                loginHandler={loginHandler}
                userLoginResponse={userLoginResponse}
            />
            {data.auth && (
                <Redirect
                    to={{
                        pathname: "/home",
                        state: { from: location },
                    }}
                />
            )}
        </>
    );
};
