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

        public List<NewsItemDetailsDto> GetAllNews()
        {
            var news = _newsRepo.GetAllNews();
            return news;
        }
    }
}