using System.Collections.Generic;
using TechnicalRadiation.Models.DTOs;
using TechnicalRadiation.Repositories;
using TechnicalRadiation.Models.InputModels;
using AutoMapper;
using System;

namespace TechnicalRadiation.Services
{
    public class AuthorService
    {
        private AuthorRepo _authorRepo;

        public AuthorService(IMapper mapper)
        {
            _authorRepo = new AuthorRepo(mapper);
        }

        public List<AuthorDto> GetAllAuthors()
        {
            var author = _authorRepo.GetAllAuthors();
            return author;
        }

        public AuthorDetailDto GetAuthorById(int id)
        {
            var author = _authorRepo.GetAuthorById(id);
            return author;
        }

        public List<NewsItemDto> GetNewsItemsByAuthor(int id)
        {
            var newsItems = _authorRepo.GetNewsItemsByAuthor(id);
            return newsItems;
        }

        public AuthorDto CreateAuthor(AuthorInputModel author)
        {
            return _authorRepo.CreateAuthor(author);
        }

        public void UpdateAuthorById(AuthorInputModel author, int id)
        {
            _authorRepo.UpdateAuthorById(author, id);
        }
    }
}