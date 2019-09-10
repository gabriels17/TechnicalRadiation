using System.Collections.Generic;
using AutoMapper;
using TechnicalRadiation.Models.DTOs;
using TechnicalRadiation.Models.InputModels;
using TechnicalRadiation.Repositories;

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

        public CategoryDto CreateCategory(CategoryInputModel category)
        {
            return _categoryRepo.CreateCategory(category);
        }

        public void UpdateCategoryById(CategoryInputModel category, int id)
        {
            _categoryRepo.UpdateCategoryById(category, id);
        }

        public void DeleteCategoryById(int id)
        {
            _categoryRepo.DeleteCategoryById(id);
        }
    }
}