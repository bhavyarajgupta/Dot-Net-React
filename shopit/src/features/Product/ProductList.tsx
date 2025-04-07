import { Grid, List } from "@mui/material";
import Product from "../../app/model/Product";
import ProductCards from "./ProductCards";

interface Props {
  products: Product[];
}

function ProductList({ products }: Props) {
  return (
    <>
      <Grid container spacing={4}>
        {products?.map((product) => (
          <Grid item xs={4} key={product.id}>
            <ProductCards product={product}></ProductCards>
          </Grid>
        ))}
      </Grid>
    </>
  );
}

export default ProductList;
