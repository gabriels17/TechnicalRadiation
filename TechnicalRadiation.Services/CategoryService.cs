using System;
using System.Collections.Generic;
using TechnicalRadiation.Models.DTOs;

namespace TechnicalRadiation.WebApi.Controllers
{
    public class CategoryService
    {
        private CategoryRepo _categoryRepo;

        public CategoryService()
        {
            _categoryRepo = new CategoryRepo();
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