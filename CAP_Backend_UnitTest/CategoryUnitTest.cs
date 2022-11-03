using CAP_Backend_Source.Models;
using CAP_Backend_Source.Modules.Category.Request;
using CAP_Backend_Source.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAP_Backend_UnitTest
{
    [TestClass]
    public class CategoryUnitTest : BaseService
    {
        private CategoryService categoryService = new CategoryService();
        #region Get All
        [TestMethod]
        public void GetAll_Success()
        {
             var response = categoryService.GetAllCategory();

             List<Category> check = dbContext.Categories.ToList();
             Assert.AreEqual(response.Count(), check.Count());
        }
        #endregion

        #region Create Category
        [TestMethod]
        public void Create_Success()
        {
            var response = categoryService.CreateCategory(new CreateCategoryRequest() {
                Name = "Unit Test of Create Category"
            });
            Assert.AreEqual(response.CategoryName, "Unit Test of Create Category");
            Assert.IsInstanceOfType(response, typeof(Category));
        }

        [TestMethod]
        public void Create_Fail_NameIsNull()
        {
            var response = categoryService.CreateCategory(new CreateCategoryRequest()
            {
                Name = ""
            });
            Assert.AreEqual(response, null);
        }
        #endregion

        #region Edit Category
        [TestMethod]
        public void Edit_Success()
        {
            var _category = dbContext.Categories.First(c => c.CategoryName == "Unit Test of Create Category");

            var response = categoryService.EditCategory(_category.CategoryId, new EditCategoryRequest()
            {
                Name = "Unit Test of Edit Category"
            });
            Assert.AreEqual(response.CategoryName, "Unit Test of Edit Category");
            Assert.IsInstanceOfType(response, typeof(Category));
        }

        [TestMethod]
        public void Edit_Fail_NameIsNull()
        {
            var response = categoryService.EditCategory(1, new EditCategoryRequest()
            {
                Name = ""
            });
            Assert.AreEqual(response, null);
        }

        [TestMethod]
        public void Edit_Fail_IdDoesNotExist()
        {
            var response = categoryService.EditCategory(999, new EditCategoryRequest()
            {
                Name = "Unit Test of Edit Category"
            });
            Assert.AreEqual(response, null);
        }
        #endregion

        #region Delete Category
        [TestMethod]
        public void Delete_Success()
        {
            var _category = dbContext.Categories.Single(c => c.CategoryName == "Unit Test of Edit Category");
            var response = categoryService.DeleteCategory(_category.CategoryId);

            Assert.AreEqual(response, "Successful Delete");
        }

        [TestMethod]
        public void Delete_Fail_IdDoesNotExist()
        {
            var response = categoryService.DeleteCategory(999);

            Assert.AreEqual(response, null);
        }
        #endregion

    }
}
