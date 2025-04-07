import { Backdrop, Box, CircularProgress } from "@material-ui/core";
import { Typography } from "@mui/material";

interface Props {
  message?: string;
}

export default function LoadingComponent({ message = "Loading..." }: Props) {
  return (
    <Backdrop open={true} invisible={true}>
      <Box
        display="flex"
        flexDirection="column"
        justifyContent="center"
        alignItems="center"
        height="100vh"
      >
        <CircularProgress color="primary" size={100} />
        <Typography
          variant="h4"
          sx={{
            justifyContent: "center",
            position: "fixed",
            top: "60%",
            alignItems: "center",
          }}
        >
          {message}
        </Typography>
      </Box>
    </Backdrop>
  );
}
