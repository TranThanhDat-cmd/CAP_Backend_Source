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
        public List<Category> GetAllCategory()
        {
            List<Category> listCategoris = dbContext.Categories.ToList();
            return listCategoris;
        }

        public Category CreateCategory(CreateCategoryRequest request)
        {
            if(request.Name == null || request.Name == "")
            {
                return null;
            }
            var category = new Category()
            {
                CategoryName = request.Name
            };
            dbContext.Categories.Add(category);
            dbContext.SaveChanges();
            return category;
        }

        public Category EditCategory(int id, EditCategoryRequest request)
        {
            if (request.Name == null || request.Name == "")
            {
                return null;
            }
            var _category = dbContext.Categories.SingleOrDefault(c => c.CategoryId == id);
            if(_category == null)
            {
                return null;
            }
            _category.CategoryName = request.Name;
            dbContext.SaveChanges();
            return _category;
        }

        public String DeleteCategory(int id)
        {
            var _category = dbContext.Categories.SingleOrDefault(c => c.CategoryId == id);
            if (_category == null)
            {
                return null;
            }
            dbContext.Categories.Remove(_category);
            dbContext.SaveChanges();
            return "Successful Delete";
        }
    }
}