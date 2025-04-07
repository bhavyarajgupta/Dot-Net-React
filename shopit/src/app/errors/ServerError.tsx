import { Container, Divider, Paper, Typography } from "@mui/material";
import { useLocation } from "react-router-dom";

export default function ServerError() {
  const { state } = useLocation(); //useLocation is a hook from react-router-dom
  // uselocation returns an object with pathname, search, hash, state, key

  return (
    <Container component={Paper}>
      {state?.error && (
        <>
          <Typography variant="h1" align="center" gutterBottom>
            {state.error.title}
          </Typography>
          <Divider />
          <Typography variant="h6" gutterBottom>
            {state.error.detail || "Server Error"}
          </Typography>
        </>
      )}
    </Container>
  );
}
