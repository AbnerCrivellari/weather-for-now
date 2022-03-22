import React from "react";
import CardComponent from "../Card/cardComponent";
import styled from "styled-components";
import { useGlobalContext } from '../../state/GlobalState';

export const CardsList = styled.div`
  z-index: 0;
  width: 90%;
  display: flex;
  justify-content: space-around;
  margin: 0 auto;
  flex-wrap: wrap;
  overflow-y: scroll;
  ::-webkit-scrollbar {
      display: none;
  }
`;


export const CardsComponent = () => {
  const [state] = useGlobalContext();
  return (
    <CardsList>
      {
        state && state.listForecastByDay && state.listForecastByDay.map((p) =>
        (
          <CardComponent forecastByDay={p.forecast}/>
        ))
      }

    </CardsList>
  )
}
