import { FC, useEffect, useState } from "react";
import { Container, Nav, Navbar } from "react-bootstrap";
import { LinkContainer } from "react-router-bootstrap";
import { Icon } from "@iconify/react";
import { isAuthenticated } from "../authentication/auth";
interface HeaderProps {}

export const Header: FC<HeaderProps> = ({}) => {
    const [loginStatus, setLoginStatus] = useState("");

    const getAuthUser = async () => {
        setLoginStatus(await isAuthenticated());
    };

    useEffect(() => {
        getAuthUser();
    }, [getAuthUser, loginStatus]);

    return (
        <Navbar bg="dark" variant="dark" expand="lg" collapseOnSelect>
            <Container>
                <LinkContainer to="/home">
                    <Navbar.Brand>Games</Navbar.Brand>
                </LinkContainer>
                <Navbar.Toggle aria-controls="basic-navbar-nav" />
                <Navbar.Collapse id="basic-navbar-nav">
                    <Nav className="ml-auto">
                        <LinkContainer to="/auth/signin">
                            <Nav.Link>
                                <Icon
                                    icon="bx:bxs-user"
                                    color={
                                        loginStatus === "Unauthorized"
                                            ? "#4cbb17"
                                            : "#FF5733"
                                    }
                                    width="20"
                                    height="20"
                                />
                                {loginStatus === "Unauthorized"
                                    ? " Sign In / Sign Up"
                                    : " Sign Out"}
                            </Nav.Link>
                        </LinkContainer>
                        <LinkContainer to="/favorites">
                            <Nav.Link>
                                <Icon
                                    icon="carbon:favorite-filled"
                                    color="#e31b23"
                                    width="20"
                                    height="20"
                                />
                                Favorites
                            </Nav.Link>
                        </LinkContainer>
                        <LinkContainer to="/auth/admin-dashboard">
                            <Nav.Link>
                                <Icon
                                    icon="dashicons:admin-network"
                                    color="#096484"
                                    width="20"
                                    height="20"
                                />
                                Admin
                            </Nav.Link>
                        </LinkContainer>
                    </Nav>
                </Navbar.Collapse>
            </Container>
        </Navbar>
    );
};
