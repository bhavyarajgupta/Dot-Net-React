using System.Collections.Generic;  // List<T>

namespace API.Entities
{
    public class Basket
    {
        public int Id { get; set; }
        public string BuyerId { get; set; }

        public List<BasketItem> Items { get; set; } = new List<BasketItem>();

        public void AddItem(Product product, int quantity)
        {
            if(Items.All(i => i.ProductId != product.Id))
            {
                Items.Add(new BasketItem { ProductId = product.Id, Quantity = quantity });
                
            }

            // If the item already exists in the basket, increment the quantity
            //ifordefault returns the first element of the sequence that satisfies a condition or a default value if no such element is found.
            var existingItem = Items.FirstOrDefault(i => i.ProductId == product.Id);
            if(existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
        }

        public void RemoveItem(int productId , int quantity){
            var existingItem=Items.FirstOrDefault(i => i.ProductId == productId);
            if(existingItem==null) return;
            if(existingItem.Quantity>quantity)
              existingItem.Quantity -= quantity;
            else
             Items.Remove(existingItem);
        }
    }

}