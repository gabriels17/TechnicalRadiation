using System;
using System.Collections.Generic;
using System.Linq;
using TechnicalRadiation.Models.DTOs;
using TechnicalRadiation.Models.Entities;

namespace TechnicalRadiation.WebApi.Controllers
{
  public class CategoryRepo
  {
    public List<CategoryDto> GetAllCategories()
    {
        var categories = (from c in FakeDatabase.Categories
                          select new CategoryDto
                          {
                              Id = c.Id,
                              Name = c.Name,
                              Slug = c.Slug
                          }).ToList();
            return categories;
    }

        public CategoryDetailDto GetCategoryById(int id)
        {
            var category = (from c in FakeDatabase.Categories
                            where c.Id == id
                            select new CategoryDetailDto
                            {
                                Id = c.Id,
                                Name = c.Name,
                                Slug = c.Slug,
                                NumberOfNewsItems = (from news in FakeDatabase.NewsItems
                                                     join newscategories in FakeDatabase.NewsItemCategories on news.Id equals newscategories.NewsItemId
                                                     join categories in FakeDatabase.Categories on newscategories.CategoryId equals categories.Id
                                                     where categories.Id == id
                                                     select news).Count()
                            }).FirstOrDefault();

            return category;
        }
    }
}