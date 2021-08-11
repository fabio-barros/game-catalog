import { FC } from "react";
import { Col, Container, Row } from "react-bootstrap";

interface FooterProps {}

export const Footer: FC<FooterProps> = ({}) => {
    return (
        <Container className="footer-wrapper" fluid>
            <Row className="footer">
                <Col className="text-center py-3 ">
                    &copy; 2021 Fábio Barros Ribeiro
                </Col>
            </Row>
        </Container>
    );
};
