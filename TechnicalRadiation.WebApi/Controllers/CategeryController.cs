using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace TechnicalRadiation.WebApi.Controllers
{
  [Route("api/")]
    public class CategoryController : ControllerBase
    {
        private CategoryService _categoryService;

        public CategoryController(IMapper mapper)
        {
            _categoryService = new CategoryService(mapper);
        }

        // GET /api/categories
        [HttpGet]
        [Route("categories")]
        public IActionResult GetAllCategories()
        {
            var categories = _categoryService.GetAllCategories();
            return Ok(categories);
        }

        // GET /api/categories/5
        [HttpGet]
        [Route("categories/{id:int}", Name = "GetCategoryById")]
        public ActionResult<string> GetCategoryById(int id)
        {
            var category = _categoryService.GetCategoryById(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        // POST /api
        /*[Route("")]
        [HttpPost]
        public IActionResult CreateCategory([FromBody] CategoryInputModel category)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest("Model is not properly formatted.");
            }
            return CreatedAtAction("GetCategoryById", new {}, null);
        }*/

        // PUT api/category/5
        /*[Route("{id:int}")]
        [HttpPut]
        public IActionResult UpdateCategoryById([FromBody] NewsItemInputModel category, int id)
        {
            if (!ModelState.IsValid) { return BadRequest("Model is not properly formatted.");}
            _categoryService.UpdateCategoryById(category, id);
            return NoContent();
        }*/

        // DELETE api/category/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            
        }
    }
}
