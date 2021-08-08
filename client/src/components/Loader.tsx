import { FC } from "react";
import { Col, Row, Spinner } from "react-bootstrap";

interface LoaderProps {}

export const Loader: FC<LoaderProps> = ({}) => {
    return (
        <Row>
            <Col>
                <Spinner animation="border" role="status">
                    <span className="visually-hidden">Loading...</span>
                </Spinner>
                {/* <span className="sr-only">Carregando...</span>
                </Spinner> */}
            </Col>
        </Row>
    );
};
