using System.Collections.Generic;
using TechnicalRadiation.Models.DTOs;
using TechnicalRadiation.Repositories;
using TechnicalRadiation.Models.InputModels;
using AutoMapper;
using TechnicalRadiation.Models.Extensions;
using System.Linq;
using System;
using TechnicalRadiation.Models.Exceptions;

namespace TechnicalRadiation.Services
{
    public class AuthorService
    {
        private AuthorRepo _authorRepo;
        private NewsRepo _newsRepo;

        public AuthorService(IMapper mapper)
        {
            _authorRepo = new AuthorRepo(mapper);
            _newsRepo = new NewsRepo(mapper);
        }

        private AuthorDto AddAuthorDtoLinks(AuthorDto author)
        {
            author.Links.AddReference("edit", $"api/authors/{author.Id}");
            author.Links.AddReference("delete", $"api/authors/{author.Id}");
            author.Links.AddReference("self", $"api/authors");
            author.Links.AddReference("newsItems", $"api/authors/{author.Id}/newsItems");
            author.Links.AddListReference("newsItemsDetailed", _authorRepo.GetNewsItemsByAuthor(author.Id)
                .Select(n => new { href = $"api/{n.Id}" }));
            return author;
        }

        private AuthorDetailDto AddAuthorDetailDtoLinks(AuthorDetailDto author)
        {
            author.Links.AddReference("edit", $"api/authors/{author.Id}");
            author.Links.AddReference("delete", $"api/authors/{author.Id}");
            author.Links.AddReference("self", $"api/authors");
            author.Links.AddReference("newsItems", $"api/authors/{author.Id}/newsItems");
            author.Links.AddListReference("newsItemsDetailed", _authorRepo.GetNewsItemsByAuthor(author.Id)
                .Select(n => new { href = $"api/{n.Id}" }));
            return author;
        }

        public List<AuthorDto> GetAllAuthors()
        {
            var authors = _authorRepo.GetAllAuthors();
            foreach (var a in authors)
            {
                AddAuthorDtoLinks(a);
            }
            return authors;
        }

        public AuthorDetailDto GetAuthorById(int id)
        {
            if (id < 1) { throw new ArgumentOutOfRangeException("Id should not be lower than 1"); }
            var author = _authorRepo.GetAuthorById(id);
            if (author == null) { throw new ResourceNotFoundException($"Author with id {id} was not found"); }
            AddAuthorDetailDtoLinks(author);
            return author;
        }

        public void LinkNewsItemToAuthorById(int aid, int nid)
        {
            if (aid < 1) { throw new ArgumentOutOfRangeException("Id should not be lower than 1"); }
            var author = _authorRepo.GetAuthorById(aid);
            if (author == null) { throw new ResourceNotFoundException($"Category with id {aid} was not found"); }
            
            if (nid < 1) { throw new ArgumentOutOfRangeException("Id should not be lower than 1"); }
            var newsItem = _newsRepo.GetNewsById(nid);
            if (newsItem == null) { throw new ResourceNotFoundException($"Category with id {nid} was not found"); }
            

            _authorRepo.LinkNewsItemToAuthorById(aid, nid);
        }

        public List<NewsItemDto> GetNewsItemsByAuthor(int id)
        {
            if (id < 1) { throw new ArgumentOutOfRangeException("Id should not be lower than 1"); }
            var author = _authorRepo.GetAuthorById(id);
            if (author == null) { throw new ResourceNotFoundException($"Category with id {id} was not found"); }

            var newsItems = _authorRepo.GetNewsItemsByAuthor(id);
            foreach (var n in newsItems)
            {
                n.Links.AddReference("edit", $"api/{n.Id}");
                n.Links.AddReference("self", $"api/{n.Id}");
                n.Links.AddReference("delete", $"api/{n.Id}");
                n.Links.AddListReference("authors", _newsRepo.GetAuthorsByNewsItemId(n.Id)
                    .Select(a => new { href = $"api/authors/{id}"}));
                n.Links.AddListReference("categories", _newsRepo.GetCategoriesByNewsItemId(n.Id)
                    .Select(c => new { href = $"api/categories/{c.Id}"}));
            }
            return newsItems;
        }

        public AuthorDto CreateAuthor(AuthorInputModel author)
        {
            return _authorRepo.CreateAuthor(author);
        }

        public void UpdateAuthorById(AuthorInputModel author, int id)
        {
            if (id < 1) { throw new ArgumentOutOfRangeException("Id should not be lower than 1"); }
            if (FakeDatabase.Authors.Count < id) { throw new ResourceNotFoundException($"News item with id {id} was not found"); }
            _authorRepo.UpdateAuthorById(author, id);
        }

        public void DeleteAuthorById(int id)
        {
            _authorRepo.DeleteAuthorById(id);
        }
    }
}