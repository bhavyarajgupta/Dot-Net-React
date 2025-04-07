using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    [Table("BasketItems")] // This is the name of the table in the database , 
    // another way to do this is to use the DbSet<BasketItem> in the StoreContext.cs
    public class BasketItem
    {
        public int Id { get; set; }
        public int Quantity { get; set; }

        // Navigation properties
        public int ProductId { get; set; }
        // The product associated with this basket item
        public Product Product { get; set; } 

        // ENTITY FRAMEWORK CONVENTION , TO CREATE MIGRATION AND DATABASE
        //dotnet ef migrations add BasketEntityAdded

        public int BasketId { get; set; }
        // The basket associated with this basket item
        public Basket Basket { get; set; }
    }
}

// Understanding the relationship between the Basket and BasketItem entities
// The Basket entity has a collection of BasketItem entities. This is a one-to-many relationship.
// The BasketItem entity has a reference to the Basket entity. This is a many-to-one relationship.
// The BasketItem entity has a reference to the Product entity. This is a many-to-one relationship.

//Hence we added the following properties to the BasketItem entity:
// public int ProductId { get; set; }
// public Product Product { get; set; }
// public int BasketId { get; set; }
// public Basket Basket { get; set; }

// The ProductId property is a foreign key that references the Product entity.
// The Product property is a navigation property that references the Product entity.
// The BasketId property is a foreign key that references the Basket entity.
// The Basket property is a navigation property that references the Basket entity.
// The BasketItem entity is now complete. We can now create a migration and update the database.


















// apply migration dotnet watch run