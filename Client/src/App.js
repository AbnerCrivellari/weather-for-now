import React from "react";
// Styles
import "fontsource-roboto";
import { darkTheme,lightTheme } from "./styles/theme";
import  GlobalStyles  from "./styles/globalStyles";
// ROUTER
import { BrowserRouter } from "react-router-dom";
import { RouterConfig } from "./routes/RouterConfig";

import { ThemeProvider } from "styled-components";
import { GlobalProvider } from './state/GlobalState';

function App() {
  return (
    <>
     <ThemeProvider theme={darkTheme}>
        <GlobalStyles />
        <GlobalProvider>
          <BrowserRouter>
            <RouterConfig />
          </BrowserRouter>
        </GlobalProvider>
     </ThemeProvider>
    </>
  );
}

export default App;
