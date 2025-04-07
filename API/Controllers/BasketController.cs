using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace API.Controllers
{
    public class BasketController : BaseApiController
    {
        //define cunstructor by ctor
        // storecontext is the class that we created in the data folder to connect to the database and get the data

        //Field Definition: private readonly StoreContext _context;

        // This defines a private, read-only field named _context of type StoreContext.

    // StoreContext is a class that connects to the database to retrieve data.
        private readonly StoreContext _context;

        public BasketController(StoreContext context){
            _context = context;
        }

        //define end point method
        // name the method as getbasket
        // return type is async task of action result of basketdto
        [HttpGet(Name = "GetBasket")]
        public async Task<ActionResult<BasketDto>> GetBasket()
        {
            var basket = await RetriveBasket();

            if (basket == null) return NotFound();
            return MapBasketToDto(basket);
        }

        

        private async Task<Basket> RetriveBasket()
        {
            return await _context.Baskets
                        .Include(i => i.Items)
                        .ThenInclude(p => p.Product)
                        .FirstOrDefaultAsync(x => x.BuyerId == Request.Cookies["buyerId"]);
        }

        [HttpPost] // api/basket?productId=1&qty=5
        public async Task<ActionResult> AddItemToBasket(int productId , int qty){
            // getbasket || create basket

            var basket = await RetriveBasket();
            if(basket == null){
               basket = CreateBasket();
            }
            
            //get product
            var product = await _context.Products.FindAsync(productId);
            if(product == null) return NotFound();

            // add item to basket
            basket.AddItem(product,qty);     
             
            var result = await _context.SaveChangesAsync() > 0;
            if(!result) return StatusCode(500,"Problem adding item to basket");
            // save basket

            if(result) return CreatedAtRoute("GetBasket",MapBasketToDto(basket)); // Return a success response

            return BadRequest(new ProblemDetails{Title= "Problem saving item to basket"});
        }


        [HttpDelete]
        public async Task<ActionResult> RemoveItemFromBasket(int productId , int qty){
            // getbasket

           var basket = await RetriveBasket();
            if(basket == null) return NotFound();
            // remove item from basket or reduce qty

        //    var productItem = basket.Items.FirstOrDefault(x => x.ProductId == productId);
        //    if(productItem == null) return NotFound();

           //basket.RemoveItem(productItem.ProductId,qty);
         basket.RemoveItem(productId,qty);
            // save basket
              
            var result = await _context.SaveChangesAsync() > 0;
            if(!result) return StatusCode(500,"Problem removing item to basket");

            if(result) return CreatedAtRoute("GetBasket",MapBasketToDto(basket)); // Return a success response

            return BadRequest(new ProblemDetails{Title= "Problem removing item to basket"});
        }
         

         // create basket
         private Basket CreateBasket()
        {
            var buyerId = Guid.NewGuid().ToString(); //unique key
            var cookieOptions = new CookieOptions
            {
                IsEssential = true,
                Expires = DateTime.Now.AddDays(30)
               
            };
             Response.Cookies.Append("buyerId",buyerId,cookieOptions);
            var basket = new Basket
            {
                BuyerId = buyerId
            };
            _context.Baskets.Add(basket);  // entuty framework will track this
            return basket;
        }

        private BasketDto MapBasketToDto(Basket basket)
{
    return new BasketDto
    {
        Id = basket.Id,
        buyerId = basket.BuyerId,
        Items = basket.Items.Select(item => new BasketItemDto
        {
            ProductId = item.Product.Id,
            ProductName = item.Product.Name,
            ProductPrice = item.Product.Price,
            Quantity = item.Quantity,
            PictureUrl = item.Product.Pictures.Select(p => p.Url).ToList(), // Get all picture URLs
            Brand = item.Product.ProductBrand,
            Type = item.Product.ProductType
        }).ToList()
    };
}

    }
}



// Constructor: public BasketController(StoreContext context)

// This is a constructor method that initializes the BasketController class.

// It takes a StoreContext object as a parameter and assigns it to the _context field.

// This ensures that the controller has access to the database context when handling requests.