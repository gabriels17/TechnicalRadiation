using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using TechnicalRadiation.Models.DTOs;
using TechnicalRadiation.Models.Entities;
using TechnicalRadiation.Models.InputModels;

namespace TechnicalRadiation.Repositories
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
            return _mapper.Map<CategoryDetailDto>(FakeDatabase.Categories.Where(c => c.Id == id).SingleOrDefault());
        }

        public CategoryDto CreateCategory(CategoryInputModel category)
        {
            var nextId = FakeDatabase.Categories.OrderByDescending(c => c.Id).FirstOrDefault().Id + 1;
            
            var entity = new Category
            {
                Id = nextId,
                Name = category.Name,
                ModifiedBy = "TechnicalRadiationAdmin",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };
            var slug = entity.Name.ToLower().Replace(' ', '-');
            entity.Slug = slug;
            FakeDatabase.Categories.Add(entity);
            return new CategoryDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Slug = entity.Slug
            };
        }
        public void UpdateCategoryById(CategoryInputModel category, int id)
        {
            var entity = FakeDatabase.Categories.FirstOrDefault(n => n.Id == id);

            // Update properties
            entity.Name = category.Name;
            entity.Slug = category.Name.ToLower().Replace(' ', '-');
            entity.ModifiedDate = DateTime.Now;
            entity.ModifiedBy = "TechnicalRadiationAdmin";
        }

        public void DeleteCategoryById(int id)
        {
            var entity = FakeDatabase.Categories.FirstOrDefault(c => c.Id == id);
            if (entity == null) { return; /* Throw some exception */}
            FakeDatabase.Categories.Remove(entity);
        }
    }
}