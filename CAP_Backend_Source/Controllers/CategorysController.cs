using CAP_Backend_Source.Modules.Category.Request;
using CAP_Backend_Source.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CAP_Backend_Source.Controllers
{
    [RoutePrefix("api/categorys")]
    public class CategorysController : ApiController
    {
        CategoryService categoryService = new CategoryService();

        [Route("getall")]
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            return Ok(categoryService.GetAllCategory());
        }

        [Route("create")]
        [HttpPost]
        public IHttpActionResult Create(CreateCategoryRequest request)
        {
            return Ok(categoryService.CreateCategory(request));
        }

        [Route("edit/{id}")]
        [HttpPut]
        public IHttpActionResult Edit(int id, EditCategoryRequest request)
        {
            return Ok(categoryService.EditCategory(id, request));
        }

        [Route("delete/{id}")]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            return Ok(categoryService.DeleteCategory(id));
        }
    }
}
