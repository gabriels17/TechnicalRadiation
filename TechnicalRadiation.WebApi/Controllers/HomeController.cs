﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechnicalRadiation.Services;

namespace TechnicalRadiation.WebApi.Controllers
{
    [Route("api/")]
    [ApiController]
    public class HomeController : Controller
    {
        // GET api/home
        [HttpGet]
        [Route("")]
        // TODO: Change return value to NewsItemInputModel
        public IActionResult GetAllNews()
        {
            var news = NewsService.NewsItems.GetRange(0, 25);
            return Ok(news);
        }

        // GET api/home/5
        [HttpGet]
        [Route("{id:int}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/home
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/home/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/home/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
