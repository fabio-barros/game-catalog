import { FC, Fragment, useEffect } from "react";
import { Col, Container, Row } from "react-bootstrap";
import { useDispatch, useSelector } from "react-redux";
import { listProducts } from "../../redux/actions/gameActions";
import { ApplicationSate } from "../../redux/store";
import { GameState } from "../../redux/types/types";
import { GameCard } from "../GameCard";
import { Loader } from "../Loader";
import { Message } from "../Message";

const games = [
    {
        id: {
            $oid: "60cf6ad2fc13ae61f6000073",
        },
        title: "Hot Dog... The Movie",
        developer: "Waelchi, Von and Hudson",
        publisher: "Paucek, Ondricka and O'Keefe",
        "releaser year": "7/13/2020",
        price: "$150.45",
        url: "http://dummyimage.com/137x100.png/5fa2dd/ffffff",
    },
    {
        id: {
            $oid: "60cf6ad2fc13ae61f6000074",
        },
        title: "Brink of Life (Nära livet)",
        developer: "Connelly, Kunde and Reilly",
        publisher: "Lebsack LLC",
        "releaser year": "1/1/2020",
        price: "$98.95",
        url: "http://dummyimage.com/129x100.png/dddddd/000000",
    },
    {
        id: {
            $oid: "60cf6ad2fc13ae61f6000075",
        },
        title: "Wackness, The",
        developer: "Stamm LLC",
        publisher: "Haag-Hintz",
        "releaser year": "7/20/2019",
        price: "$118.25",
        url: "http://dummyimage.com/147x100.png/5fa2dd/ffffff",
    },
    {
        id: {
            $oid: "60cf6ad2fc13ae61f6000076",
        },
        title: "Backfire",
        developer: "Erdman Inc",
        publisher: "Lang and Sons",
        "releaser year": "8/11/2019",
        price: "$117.64",
        url: "http://dummyimage.com/107x100.png/cc0000/ffffff",
    },
    {
        id: {
            $oid: "60cf6ad2fc13ae61f6000077",
        },
        title: "Barney's Great Adventure",
        developer: "Walsh Group",
        publisher: "Morissette-Ondricka",
        "releaser year": "3/13/2021",
        price: "$178.69",
        url: "http://dummyimage.com/112x100.png/5fa2dd/ffffff",
    },
];

interface HomeProps {}

export const Home: FC<HomeProps> = () => {
    const dispatch = useDispatch();

    const gameList = useSelector((state: ApplicationSate) => {
        console.log(`state: ${state}`);
        return state.gameList;
    });

    const { loading, error, data } = gameList;

    useEffect(() => {
        console.log("howdy!");
        dispatch(listProducts());
    }, [dispatch]);

    return (
        <Fragment>
            <Container className="games-wrapper">
                {loading ? (
                    <Loader />
                ) : error ? (
                    <Message variant="danger">{error}</Message>
                ) : (
                    <Row>
                        {data.map((game) => {
                            return (
                                <Col key={game.id} sm={12} md={6} lg={4} xl={3}>
                                    <GameCard game={game} />
                                </Col>
                            );
                        })}
                    </Row>
                )}
            </Container>
        </Fragment>
    );
};
