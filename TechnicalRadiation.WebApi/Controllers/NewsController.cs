using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechnicalRadiation.Services;
using TechnicalRadiation.Models.InputModels;

namespace TechnicalRadiation.WebApi.Controllers
{
    [Route("api/")]
    [ApiController]
    public class NewsController : Controller
    {
        private NewsService _newsService;

        public NewsController()
        {
            _newsService = new NewsService();
        }

        // GET /api
        [HttpGet]
        [Route("")]
        // TODO: Change return value to NewsItemInputModel
        public IActionResult GetAllNews([FromQuery] int pageSize, [FromQuery] int pageNumber)
        {
            var news = _newsService.GetAllNews().GetRange(0, pageSize);
            return Ok(news);
        }

        // GET /api/5
        [HttpGet]
        [Route("{id:int}")]
        public ActionResult<string> GetNewsById(int id)
        {
            var news = _newsService.GetNewsById(id);
            if (news == null)
            {
                return NotFound();
            }
            return Ok(news);
        }

        // POST api/news
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/news/5
        [Route("{id:int}")]
        [HttpPut]
        public IActionResult UpdateNewsById([FromBody] NewsItemInputModel news, int id)
        {
            if (!ModelState.IsValid) { return BadRequest("Model is not properly formatted.");}
            _newsService.UpdateNewsById(news, id);
            return NoContent();
        }

        // DELETE api/news/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            
        }
    }
}
