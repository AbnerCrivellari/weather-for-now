import React, { useState } from "react";
// Styles
import "fontsource-roboto";
import { darkTheme, lightTheme } from "./styles/theme";
import GlobalStyles from "./styles/globalStyles";
// ROUTER
import { BrowserRouter } from "react-router-dom";
import { RouterConfig } from "./routes/RouterConfig";

import { ThemeProvider } from "styled-components";
import { GlobalProvider } from './state/GlobalState';
import DarkModeToggle from "react-dark-mode-toggle";

function App() {
  const [isDarkMode, setIsDarkMode] = useState(() => true);
  return (
    <>
      <div className="display-inline-block">
        <label className="labelToggle">Select your theme: </label>
        <DarkModeToggle onChange={setIsDarkMode} checked={isDarkMode} size={70} speed={10} className="toggleDarkMode"/>
      </div>
      <ThemeProvider theme={isDarkMode ? darkTheme : lightTheme}>
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
