﻿using CAP_Backend_Source.Models;
using CAP_Backend_Source.Services;
using CAP_Backend_Source.Services.User.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace CAP_Backend_Source.Controllers
{
    public class AccountsController : ApiController
    {
        AccountService accountService = new AccountService();

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IHttpActionResult Create(CreateAccountRequest request)
        {
            return Ok(accountService.Create(request));
        }
    }
}