import React, { useState, useCallback, useContext } from "react";
import Logo from "../../assets/Logo/weather.svg";
import styled from 'styled-components';
import { useForm } from "react-hook-form";
import { CardsComponent } from "../../components/cards/cardsComponent"
import { GetForecastByAddress } from "../../services/forecastServices";
import ReactLoading from 'react-loading';
import { useGlobalContext } from '../../state/GlobalState';

const MainContainer = styled.div`
  position: relative;
  text-align: center;
  margin:0 auto;
  &.loading{
    margin: 0 auto;
  }
`;

const Title = styled.h1`
  text-align: center;
  margin: 5px;
`;

const LogoWrapper = styled.div`
  margin-top: 20vh;
  width: 100vw; // 100% view width
  justify-content:center; // centers in the flex direction and the default flex-direction is row
  align-items:center; // centers perpendicular to the flex direction
  img {
    width: 200px;
    /* max-width: 100px;
    max-height: 100px; */
  }
`;

const Div = styled.div`
    width: 10vw; /* Can be in percentage also. */
    margin: 0 auto;
    position: relative;
`;

const InputWrapper = styled.div`
  display: inline-block;
  position: relative;
  label{
    display: flex; 
    position: relative; 
    text-align: left;

  }
`;
const TextInputField = styled.input`
  display: flex;
  vertical-align: top;
  width: 30vw;
  background: white;
  border: 2px solid #dfe3e6;
  margin-right: 15px;
  border-radius: 4px;
  color: black,;
  line-height: 20px;
  font-size: 1em;
  padding: 15px;
  height: 40px;
  transition: all 0.45s ease-out;
  &.error{
    border: 2px solid red;
  }
  &:focus {
    background-color: #f6f7fb;
    border: 2px solid #5b6871;
  }
  @media only screen and (max-width: 335px) {
    width: 220px;
  }
  &.city{
    width: 10vw;
  }
`;
const Button = styled.button`
  background-color: #4CAF50; /* Green */
  border: none;
  color: white;
  padding: 15px 32px;
  text-align: center;
  text-decoration: none;
  display: inline-block;
  font-size: 16px;
  border-radius: 4px;
  vertical-align: bottom;
`;

const Form = styled.form`
  margin-top: 10px;
  height: 100px;
`;

export function HomeContainer() {
  const { register, handleSubmit, getValues, formState: { errors } } = useForm();
  const [isSending, setIsSending] = useState(false);
  const [showError, setShowError] = useState(false);
  const [state, setResult] = useGlobalContext();

  const sendRequest = useCallback(async () => {
    if (isSending) return
    setIsSending(true)
    try {
      let response = await GetForecastByAddress(getValues("Address"));
      setResult(response);
      if(!response){
        setShowError(true);
      }
      setIsSending(false)
    } catch (ex) {
      setShowError(true)
      setIsSending(false)
    }
  }, [])

  return (
    <MainContainer>
      <LogoWrapper>
        <img src={Logo} alt="logo" />
      </LogoWrapper>
      <Title>Let me know the weather for....</Title>
      <Form >
        <InputWrapper>
          <label>Address</label>
          <TextInputField className={errors.Address ? "error" : null} name="Address" placeholder="123 Sesame Street" {...register("Address", { required: "Required", })}></TextInputField>
        </InputWrapper>
        <Button onClick={handleSubmit(sendRequest)}>Search</Button>
      </Form>
      {state ?
        <CardsComponent /> :
        showError && <h2>Address was not found!!</h2>
      }
      {
        isSending && <Div>
          <ReactLoading type={"cylon"} color={"white"} height={300} width={150} />
        </Div>
      }
    </MainContainer>
  );
}
