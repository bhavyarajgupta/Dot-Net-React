import {
  Button,
  Card,
  CardActions,
  CardContent,
  CardMedia,
  Typography,
} from "@material-ui/core";

import Product from "../../app/model/Product";
import { Avatar, CardHeader } from "@mui/material";
import { Link } from "react-router-dom";

interface Props {
  product: Product;
}

function ProductCards({ product }: Props) {
  return (
    <>
      <Card style={{ maxWidth: 345 }}>
        <CardHeader
          avatar={<Avatar> {product.name.charAt(0).toUpperCase()} </Avatar>}
          title={product.name}
          titleTypographyProps={{
            sx: { fontWeight: "bold", color: "primary.main" },
          }}
        />

        <CardMedia
          key={product.id}
          component="img"
          alt="green iguana"
          height="140"
          sizes="contained"
          image={product.pictureUrl}
          title={product.name}
        />
        <CardContent>
          <Typography gutterBottom variant="h5" component="div">
            {product.price}
          </Typography>
        </CardContent>
        <CardContent>
          <Typography
            gutterBottom
            variant="h5"
            component="div"
            color="secondary"
          >
            {product.name}
          </Typography>
          <Typography
            gutterBottom
            variant="h6"
            component="div"
            color="textPrimary"
          >
            {product.brand} / {product.type}
          </Typography>
        </CardContent>
        <CardActions>
          <Button size="small">Add to Cart</Button>
          <Button size="small" component={Link} to={`/catalog/${product.id}`}>
            View
          </Button>
        </CardActions>
      </Card>
    </>
  );
}

export default ProductCards;
