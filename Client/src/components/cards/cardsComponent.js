import React from "react";
import CardComponent from "../Card/cardComponent";
import styled from "styled-components";
import { useGlobalContext } from '../../state/GlobalState';
import Carousel from 'react-elastic-carousel';

export const CardsList = styled.div`
  z-index: 0;
  width: 90%;
  display: flex;
  justify-content: space-around;
  margin: 0 auto;
  flex-wrap: wrap;
  /* overflow-y: scroll;
  ::-webkit-scrollbar {
      display: none;
  } */
`;

const breakPoints = [
  { width: 100, itemsToShow: 7 }
];

export const CardsComponent = () => {
  const [state] = useGlobalContext();
  return (
    // <Carousel breakPoints={breakPoints}>
      <CardsList>
        {
          state && state.listForecastByDay && state.listForecastByDay.map((p, key) =>
          (
            <CardComponent forecastByDay={p.forecast} key={key} />
          ))
        }
      </CardsList>
    // </Carousel>

  )
}
