using System;
using System.Collections.Generic;
using System.Linq;
using TechnicalRadiation.Models.DTOs;
using TechnicalRadiation.Models.Entities;
using TechnicalRadiation.Models.InputModels;

namespace TechnicalRadiation.Repositories
{
    public class NewsRepo
    {
        public List<NewsItemDto> GetAllNews()
        {
            var news = (from n in FakeDatabase.NewsItems
                        orderby n.PublishDate descending
                        select new NewsItemDto
                        {
                            Id = n.Id,
                            Title = n.Title,
                            ImgSource = n.ImgSource,
                            ShortDescription = n.ShortDescription
                        }).ToList();
            return news;
        }

        public NewsItemDetailsDto GetNewsById(int id)
        {
            var news = (from n in FakeDatabase.NewsItems
                        where n.Id == id
                        select new NewsItemDetailsDto
                        {
                            Id = n.Id,
                            Title = n.Title,
                            ImgSource = n.ImgSource,
                            ShortDescription = n.ShortDescription,
                            LongDescription = n.LongDescription,
                            PublishDate = n.PublishDate
                        }).SingleOrDefault();

            return news;
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
            if (entity == null) { return; /*henda villu baeta vid seinna*/}

            //Update properties
            entity.Title = news.Title;
            entity.ImgSource = news.ImgSource;
            entity.ShortDescription = news.ShortDescription;
            entity.LongDescription = news.LongDescription;
            entity.PublishDate = news.PublishDate;
            entity.PublishDate = news.PublishDate;
        }

        public void DeleteNewsById(int id)
        {
            var entity = FakeDatabase.NewsItems.FirstOrDefault(n => n.Id == id);
            if (entity == null) { return; /*Throw exception */}
            FakeDatabase.NewsItems.Remove(entity);
        }
    }
}