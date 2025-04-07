import { Button, Container, Divider, Paper, Typography } from "@mui/material";
import { Link } from "react-router-dom";

export default function NotFound() {
  return (
    <Container
      component={Paper}
      sx={{
        display: "flex",
        direction: "column",
        //justifyContent: "center",
        //alignItems: "center",
      }}
    >
      <h1>404 Not Found</h1>
      <Typography gutterBottom variant="h2">
        Oops - we could not found the page you are looking for..
      </Typography>
      <Divider />
      <Button fullWidth component={Link} to="/catalog" variant="contained">
        {" "}
        Goback to Home
      </Button>
    </Container>
  );
}
