using Microsoft.AspNetCore.Mvc;
using TechnicalRadiation.Models;
using TechnicalRadiation.Models.DTOs;
using TechnicalRadiation.Services;
using TechnicalRadiation.Models.InputModels;
using AutoMapper;

namespace TechnicalRadiation.WebApi.Controllers
{
    [Route("api/")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private NewsService _newsService;

        public NewsController(IMapper mapper)
        {
            _newsService = new NewsService(mapper);
        }

        // GET /api
        [HttpGet]
        [Route("")]
        public IActionResult GetAllNews([FromQuery] int pageSize, [FromQuery] int pageNumber)
        {
            if (pageSize == 0) { pageSize = 25; }
            var news = new Envelope<NewsItemDto>(pageNumber, pageSize, _newsService.GetAllNews());
            return Ok(news);
        }

        // GET /api/5
        [HttpGet]
        [Route("{id:int}", Name = "GetNewsById")]
        public ActionResult<string> GetNewsById(int id)
        {
            var news = _newsService.GetNewsById(id);
            if (news == null)
            {
                return NotFound();
            }
            return Ok(news);
        }

        // POST /api
        [Route("")]
        [HttpPost]
        public IActionResult CreateNews([FromBody] NewsItemInputModel news)
        {
            if (Request.Headers["Authorization"] != FakeDatabase.AuthToken) { return Unauthorized(); }
            if (!ModelState.IsValid) { return BadRequest("Model is not properly formatted."); }
            var entity = _newsService.CreateNews(news);
            return CreatedAtAction("GetNewsById", new { id = entity.Id }, null);
        }

        // PUT api/news/5
        [Route("{id:int}")]
        [HttpPut]
        public IActionResult UpdateNewsById([FromBody] NewsItemInputModel news, int id)
        {
            if (Request.Headers["Authorization"] != FakeDatabase.AuthToken) { return Unauthorized(); }
            if (!ModelState.IsValid) { return BadRequest("Model is not properly formatted."); }
            _newsService.UpdateNewsById(news, id);
            return NoContent();
        }

        // DELETE api/news/5
        [Route("{id:int}")]
        [HttpDelete]
        public IActionResult DeleteNewsById(int id)
        {
            if (Request.Headers["Authorization"] != FakeDatabase.AuthToken) { return Unauthorized(); }
            _newsService.DeleteNewsById(id);
            return NoContent();
        }
    }
}

