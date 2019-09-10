using System;
using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using TechnicalRadiation.Models.Entities;
using TechnicalRadiation.Models;
using TechnicalRadiation.Models.DTOs;
using TechnicalRadiation.Services;
using TechnicalRadiation.Models.InputModels;
using AutoMapper;

namespace TechnicalRadiation.WebApi.Controllers
{
    [Route("api/")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private AuthorService _authorService;

        public AuthorController(IMapper mapper)
        {
            _authorService = new AuthorService(mapper);
        }

        // GET /api/authors
        [HttpGet]
        [Route("authors")]
        public IActionResult GetAllAuthors()
        {
            var authors = _authorService.GetAllAuthors();
            return Ok(authors);
        }

        // GET /api/authors/5
        [HttpGet]
        [Route("authors/{id:int}", Name = "GetAuthorById")]
        public IActionResult GetAuthorById(int id)
        {
            var author = _authorService.GetAuthorById(id);
            if (author == null)
            {
                return NotFound();
            }
            return Ok(author);
        }

        // GET /api/authors/5/newsItems
        [HttpGet]
        [Route("authors/{id:int}/newsItems")]
        public IActionResult GetNewsItemsByAuthor(int id)
        {
            var newsItems = _authorService.GetNewsItemsByAuthor(id);
            if(newsItems.Count == 0)
            {
                return NotFound();
            }
            return Ok(newsItems);
        }

        // POST /api/authors
        [Route("authors")]
        [HttpPost]
        public IActionResult CreateAuthor([FromBody] AuthorInputModel author)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Model is not properly formatted.");
            }
            var entity = _authorService.CreateAuthor(author);
            return CreatedAtAction("GetAuthorById", new { id = entity.Id }, null);
        }

/*
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
        }*/
    }
}

