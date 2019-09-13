using System;
using System.Collections.Generic;
using AutoMapper;
using TechnicalRadiation.Models.DTOs;
using TechnicalRadiation.Models.Exceptions;
using TechnicalRadiation.Models.Extensions;
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
            var categories = _categoryRepo.GetAllCategories();
            foreach (var c in categories)
            {
                c.Links.AddReference("edit", $"api/categories/{c.Id}");
                c.Links.AddReference("self", $"api/categories/{c.Id}");
                c.Links.AddReference("delete", $"api/categories/{c.Id}");
            }
            return categories;
        }

        public CategoryDetailDto GetCategoryById(int id)
        {
            if (id < 1) { throw new ArgumentOutOfRangeException("Id should not be lower than 1"); }
            var category = _categoryRepo.GetCategoryById(id);
            if (category == null) { throw new ResourceNotFoundException($"Category with id {id} was not found"); }
            category.NumberOfNewsItems = _categoryRepo.GetNumberOfNewsItemsByCategoryId(id);
            category.Links.AddReference("edit", $"api/categories/{category.Id}");
            category.Links.AddReference("self", $"api/categories/{category.Id}");
            category.Links.AddReference("delete", $"api/categories/{category.Id}");
            return category;
        }

        public void LinkNewsItemToCategoryById(int cid, int nid)
        {
            _categoryRepo.LinkNewsItemToCategoryById(cid, nid);
        }

        public CategoryDto CreateCategory(CategoryInputModel category)
        {
            return _categoryRepo.CreateCategory(category);
        }

        public void UpdateCategoryById(CategoryInputModel category, int id)
        {
            if (id < 1) { throw new ArgumentOutOfRangeException("Id should not be lower than 1"); }
            if (FakeDatabase.Categories.Count < id) { throw new ResourceNotFoundException($"Category with id {id} was not found"); }
            _categoryRepo.UpdateCategoryById(category, id);
        }

        public void DeleteCategoryById(int id)
        {
            _categoryRepo.DeleteCategoryById(id);
        }
    }
}