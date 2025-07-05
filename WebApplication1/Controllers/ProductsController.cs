using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.DTO;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        ApplicationDbContext context = new ApplicationDbContext();

        [HttpGet("")]
        public IActionResult Index()
        {
            var products = context.products.ToList();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult get(int id)
        {
            var product = context.products.Find(id);
            return Ok(product);
        }
        [HttpPost]
        public IActionResult Create(CreateProductDTO requist)
        {
            try
            {
                var product = requist.Adapt<Product>();
                context.products.Add(product);
                context.SaveChanges();
                return Ok();
            }
            catch(Exception error )
            {
                return StatusCode(500, new { message = "error equard"  , details = error.InnerException.Message });

            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delette(int id)
        {
            var product = context.products.Find(id);
            context.products.Remove(product);
            context.SaveChanges();
            return Ok();
        }
        [HttpPatch("")]
        public IActionResult Update(Product requist , int id)
        {
            var product = context.products.Find(id);
            product.Name = requist.Name;
            product.Discription = requist.Discription;
            context.SaveChanges();
            return Ok();
        }
    }
}
