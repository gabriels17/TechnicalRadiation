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
            //var entity = _mapper.Map<NewsItem>(news);
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
            // return _mapper.Map<NewsItemDto>(entity);
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