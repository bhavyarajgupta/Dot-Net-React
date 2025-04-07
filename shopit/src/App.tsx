import React, { useState } from "react";
import Client from "./app/layout/client";
import "@fontsource/roboto/300.css";
import "@fontsource/roboto/400.css";
import "@fontsource/roboto/500.css";
import "@fontsource/roboto/700.css";
import Header from "./app/layout/Header";
import { Container, CssBaseline } from "@material-ui/core";
import { createTheme, ThemeProvider } from "@mui/material";
import { Outlet } from "react-router-dom";
import { ToastContainer } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";

const App: React.FC = () => {
  const [thememode, setThemeMode] = useState(false);
  const themeType = thememode ? "dark" : "light";

  const theme = createTheme({
    palette: {
      mode: themeType,
      background: { default: themeType === "light" ? "#eaeaea" : "#121212" },
    },
  });

  function handleThemeChange() {
    setThemeMode(!thememode);
  }
  return (
    <ThemeProvider theme={theme}>
      <ToastContainer position="bottom-right" hideProgressBar theme="colored" />
      <CssBaseline></CssBaseline>
      <Header DarkMode={thememode} handleThemeChange={handleThemeChange} />
      <Container>
        {/* <Client /> */}
        <Outlet />
        {/* Outlet will get swapped with whatever component it is coming from react router dom */}
      </Container>
    </ThemeProvider>
  );
};

export default App;
