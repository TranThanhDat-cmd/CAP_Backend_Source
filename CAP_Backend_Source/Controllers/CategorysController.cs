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
    [RoutePrefix("api/categoris")]
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
            var response = categoryService.CreateCategory(request);
            if(response == null)
            {
                return BadRequest();
            }
            return Ok(response);
        }

        [Route("edit/{id}")]
        [HttpPut]
        public IHttpActionResult Edit(int id, EditCategoryRequest request)
        {
            var response = categoryService.EditCategory(id, request);
            if (response == null)
            {
                return BadRequest();
            }
            return Ok(response);
        }

        [Route("delete/{id}")]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var response = categoryService.DeleteCategory(id);
            if (response == null)
            {
                return BadRequest();
            }
            return Ok(response);
        }
    }
}
