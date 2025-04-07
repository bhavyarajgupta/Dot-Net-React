
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{

    public class ProductsController : BaseApiController
    {
        //define cunstructor by ctor
        // storecontext is the class that we created in the data folder to connect to the database and get the data 
        private readonly StoreContext _context;

        // ProductController(StoreContext context) is the constructor that will be called when the controller is created
        public ProductsController(StoreContext context)
        {
            //for private field _context we are assigning the context that we are getting from the constructor  
            _context = context;
            //this.context = context;
            
        }
        
        //define end point method

        // making async to make it more efficient and handle concurrent requests 
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var products = await _context.Products.ToListAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            
            if(product == null) return NotFound();

            return Ok(product);
        }
        
    }
}