namespace API.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long Price { get; set; }
        public string ProductType { get; set; }
        public string ProductBrand { get; set; }
        public int QuantityInStock { get; set; }
        public ICollection<ProductPicture> Pictures { get; set; }
    }
}