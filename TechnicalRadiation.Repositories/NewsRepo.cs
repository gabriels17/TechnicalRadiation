using System.Collections.Generic;
using System.Linq;
using TechnicalRadiation.Models.DTOs;

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
    }
}