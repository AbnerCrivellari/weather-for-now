import React from "react";
import styled from "styled-components";


const Card = styled.div`
  width: 49%;
  margin-top: 10px;
  background-color: #586574;
  height: 38vh;
  min-height: 300px;
  max-width: 240px;
  max-height: 350px;
  border-bottom: 1px solid #dfe3e6;
  box-shadow: 0 1px 1px rgba(0,0,0,0.1),
    0 2px 2px rgba(0,0,0,0.1),
    0 4px 4px rgba(0,0,0,0.1),
    0 8px 8px rgba(0,0,0,0.1);
  p {
    margin: top;
  }
`;
const Div = styled.div`
  height: 45%;
`;

const CardComponent = ({ Temperature, TemperatureUnit, DayName,IconUrl, Details }) => {
  return (
    <Card>
      <h2>{DayName}</h2>
      <Div>
        <h4>{Temperature}° {TemperatureUnit}</h4>
        <img src={IconUrl}></img>
        <p>{Details}</p>
      </Div>
    </Card>
  )
}

export default CardComponent;