using CAP_Backend_Source.Models;
using CAP_Backend_Source.Modules.Category.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CAP_Backend_Source.Services
{
    public class CategoryService : BaseService
    {
        public Category CreateCategory(CreateCategoryRequest request)
        {
            var category = new Category()
            {
                CategoryName = request.Name
            };
            dbContext.Categories.Add(category);
            dbContext.SaveChanges();
            return category;
        }
    }
}