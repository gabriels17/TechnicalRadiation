using System.Collections.Generic;
using AutoMapper;
using TechnicalRadiation.Models.DTOs;

namespace TechnicalRadiation.WebApi.Controllers
{
    public class CategoryService
    {
        private CategoryRepo _categoryRepo;

        public CategoryService(IMapper mapper)
        {
            _categoryRepo = new CategoryRepo(mapper);
        }

        public List<CategoryDto> GetAllCategories()
        {
            return _categoryRepo.GetAllCategories();
        }

        public CategoryDetailDto GetCategoryById(int id)
        {
            return _categoryRepo.GetCategoryById(id);
        }
    }
}