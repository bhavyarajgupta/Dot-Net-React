import { useState, useEffect } from "react";
import Product from "../model/Product";
import Catalog from "../../features/catalog/catalog";
import { Typography } from "@mui/material";
import agent from "../api/agent";
import LoadingComponent from "./LoadingComponent";

function Client() {
  const [products, setProducts] = useState<Product[]>([]);
  const [loading, setLoading] = useState(true);
  useEffect(() => {
    agent.Catalog.list()
      //.then((res) => res.json()) // Convert the response to JSON
      .then((data) => {
        setProducts([...products, ...data]); // Assuming the API returns an array of products
      })
      .catch((error) => console.error("Error fetching data:", error)) // Catch any errors
      .finally(() => setLoading(false)); // Set loading to false when the request is done
  }, []);

  if (loading) return <LoadingComponent message="Loading products..." />;

  return (
    <>
      {/* <Typography variant="h1">Client</Typography> */}
      <Catalog
        products={products}
        // addProduct={addProduct}
      />
    </>
  );
}

export default Client;
