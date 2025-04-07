// using API.Entities;

// namespace API.Data
// {
//     public static class DbInitialiser
//     {
//         public static void Initialize(StoreContext context){
            
//             //If there are any products in the database, return (Any method do this)
//             if(context.Products.Any()) return;

//             //If there are no products in the database, add some products then below query will not execute

//             var products = new List<Product>
//             {
//                 new Product
//                 {
//                     Name = "Product 1",
//                     Description = "Description of Product 1",
//                     Price = 100,
//                     PictureUrl = "https://via.placeholder.com/150",
//                     ProductType = "Type 1",
//                     ProductBrand = "Brand 1",
//                     QuantityInStock = 10
//                 },
//                 new Product
//                 {
//                     Name = "Product 2",
//                     Description = "Description of Product 2",
//                     Price = 200,
//                     PictureUrl = "https://via.placeholder.com/150",
//                     ProductType = "Type 2",
//                     ProductBrand = "Brand 2",
//                     QuantityInStock = 20
//                 },
//                 new Product
//                 {
//                     Name = "Product 3",
//                     Description = "Description of Product 3",
//                     Price = 300,
//                     PictureUrl = "https://via.placeholder.com/150",
//                     ProductType = "Type 3",
//                     ProductBrand = "Brand 3",
//                     QuantityInStock = 30
//                 },
//                 new Product
//                 {
//                     Name = "Product 4",
//                     Description = "Description of Product 4",
//                     Price = 400,
//                     PictureUrl = "https://via.placeholder.com/150",
//                     ProductType = "Type 4",
//                     ProductBrand = "Brand 4",
//                     QuantityInStock = 40
//                 },
//                 new Product
//                 {
//                     Name = "Product 5",
//                     Description = "Description of Product 5",
//                     Price = 500,
//                     PictureUrl = "https://via.placeholder.com/150",
//                     ProductType = "Type 5",
//                     ProductBrand = "Brand 5",
//                     QuantityInStock = 50
//                 },
//                 new Product
//                 {
//                     Name = "Product 6",
//                     Description = "Description of Product 6",
//                     Price = 600,
//                     PictureUrl = "https://via.placeholder.com/150",
//                     ProductType = "Type 6",
//                     ProductBrand = "Brand 6",
//                     QuantityInStock = 60
//                 },
//                 new Product
//                 {
//                     Name = "Product 7",
//                     Description = "Description of Product 7",
//                     Price = 700,
//                     PictureUrl = "https://via.placeholder.com/150",
//                     ProductType = "Type 7",
//                     ProductBrand = "Brand 7",
//                     QuantityInStock = 70
//                 },
//                 new Product
//                 {
//                     Name = "Product 8",
//                     Description = "Description of Product 8",
//                     Price = 800,
//                     PictureUrl = "https://via.placeholder.com/150",
//                     ProductType = "Type 8",
//                     ProductBrand = "Brand 8",
//                     QuantityInStock = 80
//                 },
//                 new Product
//                 {
//                     Name = "Product 9",
//                     Description = "Description of Product 9",
//                     Price = 900,
//                     PictureUrl = "https://via.placeholder.com/150",
//                     ProductType = "Type 9",
//                     ProductBrand = "Brand 9",
//                     QuantityInStock = 90
//                 },
//                 new Product
//                 {
//                     Name = "Product 10",
//                     Description = "Description of Product 10",
//                     Price = 1000,
//                     PictureUrl = "https://via.placeholder.com/150",
//                     ProductType = "Type 10",
//                     ProductBrand = "Brand 10",
//                     QuantityInStock = 100
//                 }
                
//             };

//             //context.Products.AddRange(products);

//             //Add the products to the database
//             foreach(var product in products)
//             {
//                 context.Products.Add(product);
//             }

//             context.SaveChanges();
//         }
//     }
// }
