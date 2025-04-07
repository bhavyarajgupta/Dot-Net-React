import { Box, Typography } from "@mui/material";

import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import Product from "../../app/model/Product";

import agent from "../../app/api/agent";
import NotFound from "../../app/errors/NotFound";
import LoadingComponent from "../../app/layout/LoadingComponent";

export default function ProductDetails() {
  let { id } = useParams<{ id: string }>();

  const [product, setProduct] = useState<Product | null>(null);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    id && //checks if the is not null
      agent.Catalog.Details(parseInt(id))
        .then((response) => {
          setProduct(response);
        })
        .catch((error) => console.log(error))
        .finally(() => setLoading(false));
  }, [id]); //add dependency for id only once for id when the compoenent mounts

  if (loading) return <LoadingComponent message="Loading productDetails..." />;

  if (!product) return <NotFound />;

  return (
    <>
      <Box display="flex" flexDirection={{ xs: "column", md: "row" }} gap={2}>
        <Box flex={1}>
          <img
            src={product?.pictureUrl}
            alt={product?.name}
            style={{
              width: "100%",
              maxWidth: "500px",
              borderRadius: "8px",
              height: "100%",
              maxHeight: "600px",
            }}
          />
        </Box>
        <Box flex={1}>
          <Typography variant="h4">{product?.name}</Typography>
          <Typography variant="h6" color="textSecondary">
            {product?.description}
          </Typography>
        </Box>
      </Box>
    </>
  );
}
