using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using TechnicalRadiation.Models.DTOs;
using TechnicalRadiation.Models.Entities;
using TechnicalRadiation.Models.InputModels;

namespace TechnicalRadiation.Repositories
{
    public class NewsRepo
    {
        private IMapper _mapper;

        public NewsRepo(IMapper mapper)
        {
            _mapper = mapper;
        }

        public List<Author> GetAuthorsByNewsItemId(int id)
        {
            var authors = (from auth in FakeDatabase.Authors
                           join newsauthors in FakeDatabase.NewsItemAuthors on auth.Id equals newsauthors.AuthorId
                           join news in FakeDatabase.NewsItems on newsauthors.NewsItemId equals news.Id
                           where news.Id == id
                           select auth).ToList();
            return authors;
        }

        public List<Category> GetCategoriesByNewsItemId(int id)
        {
            var categories = (from c in FakeDatabase.Categories
                              join newscategories in FakeDatabase.NewsItemCategories on c.Id equals newscategories.CategoryId
                              join news in FakeDatabase.NewsItems on newscategories.NewsItemId equals news.Id
                              where news.Id == id
                              select c).ToList();
            return categories;
        }
        
        public List<NewsItemDto> GetAllNews()
        {
            return _mapper.Map<List<NewsItemDto>>(FakeDatabase.NewsItems);
        }

        public NewsItemDetailsDto GetNewsById(int id)
        {
            return _mapper.Map<NewsItemDetailsDto>(FakeDatabase.NewsItems.Where(n => n.Id == id).SingleOrDefault());
        }

        public NewsItemDto CreateNews(NewsItemInputModel news)
        {
            var nextId = FakeDatabase.NewsItems.OrderByDescending(n => n.Id).FirstOrDefault().Id + 1;
            var entity = new NewsItem
            {
                Id = nextId,
                Title = news.Title,
                ImgSource = news.ImgSource,
                ShortDescription = news.ShortDescription,
                LongDescription = news.LongDescription,
                PublishDate = news.PublishDate,
                ModifiedBy = "TechnicalRadiationAdmin",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };
            FakeDatabase.NewsItems.Add(entity);
            return new NewsItemDto
            {
                Id = entity.Id,
                Title = entity.Title,
                ImgSource = entity.ImgSource,
                ShortDescription = entity.ShortDescription
            };
        }
        public void UpdateNewsById(NewsItemInputModel news, int id)
        {
            var entity = FakeDatabase.NewsItems.FirstOrDefault(n => n.Id == id);

            //Update properties
            entity.Title = news.Title;
            entity.ImgSource = news.ImgSource;
            entity.ShortDescription = news.ShortDescription;
            entity.LongDescription = news.LongDescription;
            entity.PublishDate = news.PublishDate;
            entity.ModifiedDate = DateTime.Now;
            entity.ModifiedBy = "TechnicalRadiationAdmin";
        }

        public void DeleteNewsById(int id)
        {
            var entity = FakeDatabase.NewsItems.FirstOrDefault(n => n.Id == id);
            if (entity == null) { return; /*Throw exception */}
            FakeDatabase.NewsItems.Remove(entity);
        }
    }
}