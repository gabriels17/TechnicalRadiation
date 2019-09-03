using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechnicalRadiation.Services;

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
        public IActionResult GetAllNews()
        {
            var news = _newsService.GetAllNews().GetRange(0, 25);
            return Ok(news);
        }

        // GET /api/5
        [HttpGet]
        [Route("{id:int}")]
        public ActionResult<string> GetNewsById(int id)
        {
            var news = _newsService.GetAllNews().Find(n => n.Id == id);
            if(news == null)
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
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/news/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
