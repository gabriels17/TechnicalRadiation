using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using TechnicalRadiation.Models.DTOs;

namespace TechnicalRadiation.WebApi.Controllers
{
    public class CategoryRepo
    {
        private IMapper _mapper;

        public CategoryRepo(IMapper mapper)
        {
            _mapper = mapper;
        }

        public List<CategoryDto> GetAllCategories()
        {
            return _mapper.Map<List<CategoryDto>>(FakeDatabase.Categories);
            // var categories = (from c in FakeDatabase.Categories
            //                   select new CategoryDto
            //                   {
            //                       Id = c.Id,
            //                       Name = c.Name,
            //                       Slug = c.Slug
            //                   }).ToList();
            //     return categories;
        }

        private int GetNumberOfNewsItemsByCategoryId(int id)
        {
            int NumberOfNewsItems = (from news in FakeDatabase.NewsItems
                                 join newscategories in FakeDatabase.NewsItemCategories on news.Id equals newscategories.NewsItemId
                                 join categories in FakeDatabase.Categories on newscategories.CategoryId equals categories.Id
                                 where categories.Id == id
                                 select news).Count();
            return NumberOfNewsItems;
        }

        public CategoryDetailDto GetCategoryById(int id)
        {
            var category = FakeDatabase.Categories.FirstOrDefault(c => c.Id == id);
            var categoryDto = _mapper.Map<CategoryDetailDto>(category);
            categoryDto.NumberOfNewsItems = GetNumberOfNewsItemsByCategoryId(id);
            return categoryDto;
        }
    }
}