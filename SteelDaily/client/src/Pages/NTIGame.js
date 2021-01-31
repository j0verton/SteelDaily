import React, { useContext, useState } from "react";
import { toast } from "react-toastify";
import NTIQuestionCard from "../components/NTIQuestionCard";
import ScoreDisplay from "../components/ScoreDisplay";
import { Button, Card } from "reactstrap";
import "./NTIGame.css";
import 'bootstrap/dist/css/bootstrap.min.css';


const NTIGame = () => {


    return (
        <div className="game-area">
            <div className="score-container">
                <ScoreDisplay />
            </div>
            <div className="card-area">
                <NTIQuestionCard />
            </div>
            <div className="button-container">
                <Button value="1">1</Button>
                <Button value="2">b2</Button>
                <Button value="3">2</Button>
                <Button value="4">b3</Button>
                <Button value="5">3</Button>
                <Button value="6">4</Button>
                <Button value="7">b5</Button>
                <Button value="8">5</Button>
                <Button value="9">b6</Button>
                <Button value="10">6</Button>
                <Button value="11">b7</Button>
                <Button value="12">7</Button>


            </div>
        </div>



    )


};
export default NTIGame;