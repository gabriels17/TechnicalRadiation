using System;
using System.Collections.Generic;
using System.Linq;
using TechnicalRadiation.Models.DTOs;
using TechnicalRadiation.Models.Entities;
using TechnicalRadiation.Models.InputModels;
using AutoMapper;

namespace TechnicalRadiation.Repositories
{
    public class AuthorRepo
    {
        private IMapper _mapper;
        public AuthorRepo(IMapper mapper)
        {
            _mapper = mapper;
        }

        public List<AuthorDto> GetAllAuthors()
        {
            return _mapper.Map<List<AuthorDto>>(FakeDatabase.Authors);
        }

        public AuthorDetailDto GetAuthorById(int id)
        {
            return _mapper.Map<AuthorDetailDto>(FakeDatabase.Authors.Where(a => a.Id == id).SingleOrDefault());
        }

        private List<NewsItem> GetNewsItemsByAuthorId(int id)
        {
            var newsItems = (from news in FakeDatabase.NewsItems
                                 join newsauthors in FakeDatabase.NewsItemAuthors on news.Id equals newsauthors.NewsItemId
                                 join authors in FakeDatabase.Authors on newsauthors.AuthorId equals authors.Id
                                 where authors.Id == id
                                 select news).ToList();
            return newsItems;
        }

        public List<NewsItemDto> GetNewsItemsByAuthor(int id)
        {
            List<NewsItemDto> NewsItemsDto = new List<NewsItemDto>();
            var newsItems = GetNewsItemsByAuthorId(id);
            foreach (var item in newsItems)
            {
                var newsItemDto = _mapper.Map<NewsItemDto>(item);
                NewsItemsDto.Add(newsItemDto);    
            }
            return NewsItemsDto;
        }
    }
}