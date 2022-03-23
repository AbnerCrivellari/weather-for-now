import React from "react";
import styled from "styled-components";
import { getIconByType } from '../../utils/utils'


const Card = styled.div`
  width: 100%;
  margin-top: 10px;
  border-radius: 10px;
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
  height: 47%;
`;

const Wrapper = styled.div`
  width: 14%;
  span{
    h2{
      text-align: left;
    }
  }
`;

const Icon = styled.img`
  margin-top: 10px;
  width: 30%;
`;

const Line = styled.div`
  width: auto;
  height: 1px;
 border: 1px solid red;
`;

const CardComponent = ({ forecastByDay }) => {
  debugger;
  return (
    <Wrapper>
      <h2>{forecastByDay[0].dayName}</h2>
      <Card className="cardColor" key={forecastByDay[0].dayName}>
        <Div>
          <h2>{forecastByDay[0].temperature}° <span>{forecastByDay[0].temperatureUnit}</span></h2>
          <Icon src={getIconByType(forecastByDay[0].type, forecastByDay[0].isDay)}></Icon>
          <p>{forecastByDay[0].type}</p>
          {/* <p>{Details}</p> */}
        </Div>
        {forecastByDay[1] &&
          <>
            <Line />
            <Div>
              <h2>{forecastByDay[1].temperature}° <span>{forecastByDay[1].temperatureUnit}</span></h2>
              <Icon src={getIconByType(forecastByDay[1].type, forecastByDay[1].isDay)}></Icon>
              <p>{forecastByDay[1].type}</p>
              {/* <p>{Details}</p> */}
            </Div>
          </>
        }
      </Card>
    </Wrapper>
  )
}

export default CardComponent;