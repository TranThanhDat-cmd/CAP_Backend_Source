using CAP_Backend_Source.Controllers.Common;
using CAP_Backend_Source.Models;
using CAP_Backend_Source.Modules.Account.Request;
using CAP_Backend_Source.Services;
using CAP_Backend_Source.Services.User.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace CAP_Backend_Source.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/Accounts")]
    public class AccountsController : ApiController
    {
        AccountService accountService = new AccountService();

        [HttpPost]
        //[Authorize(Roles = "Admin")]
        public IHttpActionResult Create(CreateAccountRequest request)
        {
            return Ok(accountService.Create(request));
        }

        [HttpGet]
        [Route("search")]
        public async Task<IHttpActionResult> SearchAsync()
            => Ok(await accountService.SearchAsync());

        [HttpGet]
        [Route("{id}")]
        public async Task<IHttpActionResult> GetDetailAsync(int id)
            => Ok(await accountService.GetDetailAsync(id));

        [HttpPut]
        [Route("{id}")]
        public async Task<IHttpActionResult> UpdateAsync(int id,[FromBody] UpdateAccountRequest request)
        { 
            var result = await accountService.UpdateAsync(id,request);
            if(result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }
            
    }
}
