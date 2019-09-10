using System.Collections.Generic;
using TechnicalRadiation.Models.DTOs;
using TechnicalRadiation.Repositories;
using TechnicalRadiation.Models.InputModels;
using AutoMapper;
using TechnicalRadiation.Models.Extensions;
using System.Linq;

namespace TechnicalRadiation.Services
{
    public class NewsService
    {
        private NewsRepo _newsRepo;
        private AuthorRepo _authorRepo;
        private CategoryRepo _categoryRepo;

        public NewsService(IMapper mapper)
        {
            _newsRepo = new NewsRepo(mapper);
            _authorRepo = new AuthorRepo(mapper);
            _categoryRepo = new CategoryRepo(mapper);
        }

        public List<NewsItemDto> GetAllNews()
        {
            var news = _newsRepo.GetAllNews();
            foreach (var n in news)
            {
                n.Links.AddReference("self", $"api/{n.Id}");
                n.Links.AddReference("edit", $"api/{n.Id}");
                n.Links.AddReference("delete", $"api/{n.Id}");
                // TODO: CHANGE VALUES BELOW TO CORRECT VALUES
                n.Links.AddListReference("authors", _authorRepo.GetAllAuthors()
                    .Select(a => new { href = $"api/authors/{a.Id}" }));
                n.Links.AddListReference("categories", _categoryRepo.GetAllCategories()
                    .Select(c => new { href = $"api/categories/{c.Id}" }));

                // r.Links.AddListReference("owners", _ownerRepository.GetOwnersByRentalId(r.Id)
                // .Select(o => new { href = $"/api/rentals/{r.Id}/owners/{o.Id}" }
            }
            return news;
        }

        public NewsItemDetailsDto GetNewsById(int id)
        {
            var news = _newsRepo.GetNewsById(id);
            return news;
        }

        public NewsItemDto CreateNews(NewsItemInputModel news)
        {
            return _newsRepo.CreateNews(news);
        }

        public void UpdateNewsById(NewsItemInputModel news, int id)
        {
            _newsRepo.UpdateNewsById(news, id);
        }

        public void DeleteNewsById(int id)
        {
            _newsRepo.DeleteNewsById(id);
        }
    }
}