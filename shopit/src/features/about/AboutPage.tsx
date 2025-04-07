import {
  Alert,
  AlertTitle,
  Button,
  List,
  ListItem,
  ListItemText,
  Typography,
} from "@mui/material";
import agent from "../../app/api/agent";
import { error } from "console";
import { useState } from "react";

export default function AboutPage() {
  const [validationErrors, setValidationErrors] = useState<string[]>([]);

  function getValidationErrors(error: any) {
    agent.testErrors
      .getValidationError()
      .then((response) => {
        console.log("should not see this");
      })
      .catch((error) => setValidationErrors(error));
  }
  return (
    <>
      <Button
        onClick={() =>
          agent.testErrors.get400Error().catch((error) => console.error(error))
        }
      >
        {" "}
        Test Error 400 error
      </Button>
      <Button
        onClick={() =>
          agent.testErrors.get401Error().catch((error) => console.error(error))
        }
      >
        {" "}
        Test Error 401 error
      </Button>
      <Button
        onClick={() =>
          agent.testErrors.get404Error().catch((error) => console.error(error))
        }
      >
        {" "}
        Test Error 404 error
      </Button>
      <Button
        onClick={() =>
          agent.testErrors.get500Error().catch((error) => console.error(error))
        }
      >
        {" "}
        Test Error 500 error
      </Button>
      <Button onClick={getValidationErrors}>
        {" "}
        Test Error Validation error
      </Button>
      {validationErrors.length > 0 && (
        <Alert severity="error">
          <AlertTitle>Validation Error</AlertTitle>
          <List>
            {validationErrors.map((error, i) => (
              <ListItem key={i}>
                <ListItemText>{error}</ListItemText>
              </ListItem>
            ))}
          </List>
        </Alert>
      )}
      <Typography variant="h2" component="h2"></Typography>
      <Typography variant="h2">About page</Typography>
    </>
  );
}
