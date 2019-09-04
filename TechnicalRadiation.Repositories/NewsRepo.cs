using System.Collections.Generic;
using System.Linq;
using TechnicalRadiation.Models.DTOs;
using TechnicalRadiation.Models.InputModels;

namespace TechnicalRadiation.Repositories
{
    public class NewsRepo
    {
        public List<NewsItemDetailsDto> GetAllNews()
        {
            var news = (from n in FakeDatabase.NewsItems
                        orderby n.PublishDate descending
                        select new NewsItemDetailsDto
                        {
                            Id = n.Id,
                            Title = n.Title,
                            ImgSource = n.ImgSource,
                            ShortDescription = n.ShortDescription,
                            LongDescription = n.LongDescription,
                            PublishDate = n.PublishDate
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

        public void UpdateNewsById(NewsItemInputModel news, int id)
        {
            var entity = FakeDatabase.NewsItems.FirstOrDefault(n => n.Id == id);
            if(entity == null){return; /*henda villu baeta vid seinna*/}

            //Update properties
            entity.Title = news.Title;
            entity.ImgSource = news.ImgSource;
            entity.ShortDescription = news.ShortDescription;
            entity.LongDescription = news.LongDescription;
            entity.PublishDate = news.PublishDate;
            entity.PublishDate = news.PublishDate;

        }
    }
}