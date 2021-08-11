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
import { Button, Card, Form, Row, Tab, Tabs } from "react-bootstrap";
import { useDispatch, useSelector } from "react-redux";
import { LoginResponse, LoginState } from "../../redux/types/types";
import { userLoginAction } from "../../redux/actions/loginActions";
import store, { ApplicationSate } from "../../redux/store";
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
        console.log(data);
    };

    const loginHandler = async (e: FormEvent<HTMLElement>) => {
        e.preventDefault();
        fetchUserData();

        console.log(data);
    };

    useEffect(() => {
        localStorage.setItem("token", JSON.stringify(data.token));
    }, [data.token]);

    return (
        <Tabs
            defaultActiveKey="login"
            id="uncontrolled-tab-example"
            className="mb-3"
        >
            <Tab eventKey="login" title="Login">
                <LoginForm
                    setEmailLog={setEmailLog}
                    setPasswordLog={setPasswordLog}
                    loginHandler={loginHandler}
                    userLoginResponse={userLoginResponse}
                />
                {data.user.role === "user" ? (
                    <Redirect
                        to={{
                            pathname: "/favorites",
                            state: { from: location },
                        }}
                    />
                ) : data.user.role === "admin" ? (
                    <Redirect
                        to={{
                            pathname: "/home",
                            state: { from: location },
                        }}
                    />
                ) : null}
            </Tab>
            <Tab eventKey="register" title="Register"></Tab>
        </Tabs>
    );
};
