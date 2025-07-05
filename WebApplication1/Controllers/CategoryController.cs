using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.DTO;
using WebApplication1.Migrations;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        ApplicationDbContext context = new ApplicationDbContext();

        [HttpGet("")]
        public IActionResult Index()
        {
            //var categories = context.categories.ToList();
            //var CategoryDTO = new List<CategoryDTO>();
            //foreach(var item in categories)
            //{
            //    CategoryDTO.Add(new CategoryDTO() { Name = item.Name, Id = item.Id });
            //}

            //var CategoryDTO = context.categories.Select(category => new CategoryDTO() { Id = category.Id, Name = category.Name });
            var CategoryDTO = context.categories.ToList().Adapt<List<CategoryDTO>>();
            return Ok(CategoryDTO);
        }

        [HttpGet("{id}")]
        public IActionResult get(int id)
        {
            var category = context.categories.Find(id);
            return Ok(category);
        }
        [HttpPost]
        public IActionResult Create(CreateCategoriesDTO requist)
        {

            //var cat = new Category()
            //{
            //    Name = requist.Name,
            //    Discription = requist.Discription

            //};

            var cat = requist.Adapt<Category>();
            context.categories.Add(cat);
            context.SaveChanges();
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Delette(int id)
        {
            var category = context.categories.Find(id);
            context.categories.Remove(category);
            context.SaveChanges();
            return Ok();
        }
        [HttpPatch("")]
        public IActionResult Update(Category requist, int id)
        {
            var category = context.categories.Find(id);
            category.Name = requist.Name;
            category.Discription = requist.Discription;
            context.SaveChanges();
            return Ok();
        }
    }
}
