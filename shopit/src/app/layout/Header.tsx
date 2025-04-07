import { ShoppingCart } from "@mui/icons-material";
import {
  AppBar,
  Badge,
  Box,
  IconButton,
  List,
  ListItem,
  Switch,
  Toolbar,
  Typography,
} from "@mui/material";
import { NavLink } from "react-router-dom";

import brandicontemp from "../../asset/BrandIconTemp.jpeg";

interface Props {
  DarkMode: boolean;
  handleThemeChange: () => void;
}

const midLinks = [
  { title: "Catalog", path: "/catalog" },
  { title: "About", path: "/about" },
  { title: "Contact", path: "/contact" },
];

const rightLinks = [
  { title: "Login", path: "/login" },
  { title: "Register", path: "/register" },
];

function Header({ DarkMode, handleThemeChange }: Props) {
  return (
    <>
      <AppBar position="static" sx={{ mb: 4 }}>
        <Toolbar
          sx={{
            display: "flex",
            justifyContent: "space-between",
            alignItems: "center",
          }}
        >
          <Box>
            <Typography
              //variant="h6"
              component={NavLink}
              to="/"
              sx={{ flexGrow: 1, textDecoration: "none" }}
              color="inherit"
              //noWrap
              // component="div"
              // sx={{ flexGrow: 1 }}
              //position="static"
            >
              <img
                src={`${brandicontemp}`}
                style={{
                  width: "45px",
                  height: "46px",
                  marginTop: "10px",
                }}
                alt="Brand Icon"
              />
            </Typography>
          </Box>
          <Box>
            <List sx={{ display: "flex" }}>
              {midLinks.map(({ title, path }) => (
                <ListItem
                  component={NavLink}
                  to={path}
                  key={path}
                  sx={{
                    color: "inherit",
                    typography: "h6",
                  }}
                >
                  {title.toUpperCase()}
                </ListItem>
              ))}
            </List>
          </Box>
          <Box display="flex" alignItems="center">
            <List sx={{ display: "flex" }}>
              {rightLinks.map(({ title, path }) => (
                <ListItem
                  component={NavLink}
                  to={path}
                  key={path}
                  sx={{ color: "inherit", typography: "h6" }}
                >
                  {title.toUpperCase()}
                </ListItem>
              ))}
            </List>

            <Switch
              checked={DarkMode}
              onChange={handleThemeChange}
              edge="end"
              //sx={{ ml: 93 }}
            />
            <IconButton size="large" edge="end" color="inherit" sx={{ mr: 2 }}>
              <Badge badgeContent="4" color="secondary">
                <ShoppingCart />
              </Badge>
            </IconButton>
          </Box>
        </Toolbar>
      </AppBar>
    </>
  );
}

export default Header;
