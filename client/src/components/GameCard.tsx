import { FC, Fragment } from "react";
import { Card } from "react-bootstrap";
import { Link } from "react-router-dom";
import { GameInterface } from "../redux/types/types";

interface GameCardProps {
    game: GameInterface;
}

export const GameCard: FC<GameCardProps> = ({ game }) => {
    const {
        id,
        title,
        developer,
        publisher,
        releaseDate, //Date
        coverArtUrl,
        price,
    } = game;
    return (
        <Card className="my-2 border-0" style={{ width: "11em" }}>
            <Card.Img
                src={coverArtUrl}
                variant="top"
                style={{ height: "15em" }}
            ></Card.Img>

            <Card.Body className="p-2">
                <Card.Title as="div">
                    <strong>{`${title}`}</strong>
                </Card.Title>
                <Card.Subtitle>
                    <strong>{new Date(releaseDate).getFullYear()}</strong>
                </Card.Subtitle>

                <Card.Text as="div"></Card.Text>
                {/* <Card.Text as="h3">R${price}</Card.Text> */}
            </Card.Body>
        </Card>
    );
};
