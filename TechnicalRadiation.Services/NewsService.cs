using System.Collections.Generic;
using TechnicalRadiation.Models.DTOs;
using TechnicalRadiation.Repositories;

namespace TechnicalRadiation.Services
{
    public class NewsService
    {
        private NewsRepo _newsRepo;  

        public NewsService()
        {
            _newsRepo = new NewsRepo();
        }

        public List<NewsItemDto> GetAllNews()
        {
            var news = _newsRepo.GetAllNews();
            return news;
        }

        public NewsItemDetailsDto GetNewsById(int id)
        {
            var news = _newsRepo.GetNewsById(id);
            return news;
        }
    }
}