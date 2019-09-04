using System;
using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using TechnicalRadiation.Models.Entities;
using TechnicalRadiation.Models;
using TechnicalRadiation.Models.DTOs;
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
            if (pageSize == 0) { pageSize = 25; }
            var news = new Envelope<NewsItemDto>(pageNumber, pageSize, _newsService.GetAllNews());
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

        // POST /api
        [Route("")]
        [HttpPost]
        public IActionResult CreateNew([FromBody] NewsItem news)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Model is not properly formatted.");
            }
            return Created("Created", news);
        }

        // PUT api/news/5
        [Route("{id:int}")]
        [HttpPut]
        public IActionResult UpdateNewsById([FromBody] NewsItemInputModel news, int id)
        {
            if (!ModelState.IsValid) { return BadRequest("Model is not properly formatted."); }
            _newsService.UpdateNewsById(news, id);
            return NoContent();
        }

        // DELETE api/news/5
        [Route("{id:int}")]
        [HttpDelete]
        public IActionResult DeleteNewsById(int id)
        {
            _newsService.DeleteNewsById(id);
            return NoContent();
        }
    }
}

