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
        public List<NewsItemDetailsDto> GetAllNews()
        {
            var news = FakeDatabase.NewsItems.Select(n => new NewsItemDetailsDto
            {
                Id = n.Id,
                Title = n.Title,
                ImgSource = n.ImgSource,
                ShortDescription = n.ShortDescription,
                LongDescription = n.LongDescription,
                PublishDate = n.PublishDate
            });
            return news.ToList();
        }

        public NewsItemDetailsDto GetNewsById(int id)
        {
            var news = FakeDatabase.NewsItems.Where(n => n.Id == id).Select(n => new NewsItemDetailsDto
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
    }
}