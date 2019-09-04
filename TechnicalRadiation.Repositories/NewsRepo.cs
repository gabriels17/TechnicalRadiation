using System.Collections.Generic;
using System.Linq;
using TechnicalRadiation.Models.DTOs;

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
    }
}