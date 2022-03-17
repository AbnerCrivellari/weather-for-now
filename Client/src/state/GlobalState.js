import React, { createContext, useState, useContext } from 'react';

export const GlobalContext = createContext();

export const GlobalProvider = ({ children }) => {
  const [state, setResult] = useState({});
  return (
    <GlobalContext.Provider value={[state, setResult]}>
      {children}
    </GlobalContext.Provider>
  )
}

export const useGlobalContext = () => useContext(GlobalContext);