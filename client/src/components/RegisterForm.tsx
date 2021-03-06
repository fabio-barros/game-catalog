import { FC, FormEvent, Fragment } from "react";
import { Button, Card, Col, Row, Form } from "react-bootstrap";
import { SignUpState } from "../redux/types/types";
import { Message } from "./Message";

interface RegisterFormProps {
    registerHandler: (e: FormEvent<HTMLElement>) => void;
    setEmailReg: (value: React.SetStateAction<string>) => void;
    setFirstNameReg: (value: React.SetStateAction<string>) => void;
    setLastNameReg: (value: React.SetStateAction<string>) => void;
    setPasswordReg: (value: React.SetStateAction<string>) => void;
    setConfirmPasswordReg: (value: React.SetStateAction<string>) => void;
    setRoleReg: (value: React.SetStateAction<string>) => void;
    userRegResponse: SignUpState;
}

export const RegisterForm: FC<RegisterFormProps> = ({
    registerHandler,
    setEmailReg,
    setFirstNameReg,
    setLastNameReg,
    setPasswordReg,
    setConfirmPasswordReg,
    setRoleReg,
    userRegResponse: { loading, error, data },
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
                <Form onSubmit={registerHandler}>
                    <Form.Group
                        className="mb-3"
                        controlId="exampleForm.ControlInput1"
                    >
                        <Form.Label>Email</Form.Label>
                        <Form.Control
                            type="email"
                            placeholder="Enter your email"
                            required
                            onChange={(e) => setEmailReg(e.target.value)}
                        />
                    </Form.Group>
                    <Row>
                        {" "}
                        <Col>
                            <Form.Group className="mb-3">
                                <Form.Label>First Name</Form.Label>
                                <Form.Control
                                    type="text"
                                    placeholder="Enter your First Name"
                                    required
                                    minLength={3}
                                    maxLength={10}
                                    onChange={(e) =>
                                        setFirstNameReg(e.target.value)
                                    }
                                />
                            </Form.Group>
                        </Col>
                        <Col>
                            <Form.Group className="mb-3">
                                <Form.Label>Last Name</Form.Label>
                                <Form.Control
                                    type="text"
                                    placeholder="Enter your Last Name"
                                    required
                                    minLength={3}
                                    maxLength={10}
                                    onChange={(e) =>
                                        setLastNameReg(e.target.value)
                                    }
                                />
                            </Form.Group>
                        </Col>
                    </Row>

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
                    <Form.Group className="mb-3" controlId="formBasicPassword">
                        <Form.Label>Confirm Password</Form.Label>
                        <Form.Control
                            type="password"
                            placeholder="Confirm Password"
                            required
                            minLength={8}
                            maxLength={50}
                            onChange={(e) =>
                                setConfirmPasswordReg(e.target.value)
                            }
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
