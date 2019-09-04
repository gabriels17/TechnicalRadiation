using System;
using System.Collections.Generic;
using System.Linq;
using TechnicalRadiation.Models.DTOs;

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
  }
}