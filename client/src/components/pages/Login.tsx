import axios from "axios";
import { Dispatch, FC, FormEvent, Fragment, useEffect, useState } from "react";
import { Button, Card, Form } from "react-bootstrap";
import { useDispatch, useSelector } from "react-redux";
import { LoginResponse } from "../../redux/types/types";
import { userLoginAction } from "../../redux/actions/loginActions";
import { ApplicationSate } from "../../redux/store";

interface LoginProps {}

export const Login: FC<LoginProps> = ({}) => {
    const [emailReg, setEmailReg] = useState("");
    const [passwordReg, setPasswordReg] = useState("");
    const [userData, setUserData] = useState<LoginResponse | undefined>(
        undefined
    );

    const dispatch: Dispatch<any> = useDispatch();

    const userLoginResponse = useSelector((state: ApplicationSate) => {
        console.log(`state: ${state}`);
        return state.userLogin;
    });

    const { loading, error, data } = userLoginResponse;

    const loginHandler = async (e: FormEvent<HTMLElement>) => {
        e.preventDefault();
        const { data } = await axios.post(
            `${process.env.REACT_APP_GAME_CATALOG_API_LOGIN}`,
            {
                email: emailReg,
                password: passwordReg,
            }
        );
        setUserData(data);
    };

    useEffect(() => {
        console.log(userData);
    }, [userData]);

    return (
        <Card
            style={{ width: "40rem", backgroundColor: "#eaeaea" }}
            className="shadow-sm border-0 px-3 rounded-2 mb-3 py-4 mx-auto mt-5 mb-5"
        >
            {/* <h1>{user === undefined ? "howdy" : user.user.firstName}</h1> */}
            <Card.Header
                className=" bg-transparent border-0 text-center"
                style={{ width: "40rem", backgroundColor: "#ffffff" }}
            >
                <h3>Login</h3>
            </Card.Header>
            <Card.Body>
                <Form onSubmit={loginHandler}>
                    {/* <Form.Group className="mb-3" controlId="formBasicEmail">
                <Form.Label>First Name</Form.Label>
                <Form.Control type="text" placeholder="Enter first name" />
            </Form.Group>

            <Form.Group className="mb-3" controlId="formBasicEmail">
                <Form.Label>Last Name</Form.Label>
                <Form.Control type="text" placeholder="Enter your last name" />
            </Form.Group> */}

                    <Form.Group className="mb-3" controlId="formBasicEmail">
                        <Form.Label>Last Name</Form.Label>
                        <Form.Control
                            type="email"
                            placeholder="Enter your email"
                            onChange={(e) => setEmailReg(e.target.value)}
                        />
                    </Form.Group>

                    <Form.Group className="mb-3" controlId="formBasicPassword">
                        <Form.Label>Password</Form.Label>
                        <Form.Control
                            type="password"
                            placeholder="Password"
                            onChange={(e) => setPasswordReg(e.target.value)}
                        />
                    </Form.Group>
                    <Button variant="primary" type="submit">
                        Submit
                    </Button>
                </Form>
            </Card.Body>
        </Card>
    );
};