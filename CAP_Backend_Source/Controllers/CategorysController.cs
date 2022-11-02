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

        [HttpPost]
        [Route("create")]
        public IHttpActionResult Create(CreateCategoryRequest request)
        {
            return Ok(categoryService.CreateCategory(request));
        }
    }
}
