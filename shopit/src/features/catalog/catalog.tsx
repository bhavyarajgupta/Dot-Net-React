import React from "react";
import Product from "../../app/model/Product";
import ProductList from "../Product/ProductList";
//defining props interface

interface Props {
  products: Product[];
  //addProduct: () => void;
}

// function Catalog(props: Props) {
//   return (
//     <>
//       <h1>Catalog</h1>
//       <ul>
//         {props.products?.map((product) => (
//           <li key={product.id}>
//             {product?.name} - {product?.price}
//           </li>
//         ))}
//       </ul>

//       <br />
//       <button onClick={props.addProduct}> addProduct </button>
//     </>
//   );
// }
// empty <> is a fragment

//props : any , can help not to specify the type during development

// Destructuring the props
function Catalog({
  products, //addProduct
}: Props) {
  return (
    <>
      <ProductList products={products} />
      {/* <Button variant="contained" onClick={addProduct}>
        {" "}
        addProduct{" "}
      </Button> */}
    </>
  );
}

export default Catalog;
