import { FC, FormEvent, Fragment } from "react";
import { Button, Card, Form } from "react-bootstrap";
import { Redirect } from "react-router";
import { LoginState } from "../redux/types/types";
import { Message } from "./Message";

interface LoginFormProps {
    loginHandler: (e: FormEvent<HTMLElement>) => Promise<void>;
    setEmailReg: (value: React.SetStateAction<string>) => void;
    setPasswordReg: (value: React.SetStateAction<string>) => void;
    userLoginResponse: LoginState;
}

export const LoginForm: FC<LoginFormProps> = ({
    loginHandler,
    setEmailReg,
    setPasswordReg,
    userLoginResponse: { loading, error, data },
}) => {
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
                    <Form.Group className="mb-3" controlId="formBasicEmail">
                        <Form.Label>Email</Form.Label>
                        <Form.Control
                            type="email"
                            placeholder="Enter your email"
                            required
                            onChange={(e) => setEmailReg(e.target.value)}
                        />
                    </Form.Group>

                    <Form.Group className="mb-3" controlId="formBasicPassword">
                        <Form.Label>Password</Form.Label>
                        <Form.Control
                            type="password"
                            placeholder="Password"
                            required
                            minLength={8}
                            maxLength={20}
                            onChange={(e) => setPasswordReg(e.target.value)}
                        />
                    </Form.Group>
                    <Button variant="primary" type="submit">
                        Submit
                    </Button>
                </Form>
                <Card.Text as="p">
                    {!error.data ? (
                        ""
                    ) : (
                        <Message variant="danger">{error.data}</Message>
                    )}
                </Card.Text>
            </Card.Body>
        </Card>
    );
};
