using CAP_Backend_Source.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CAP_Backend_Source.Services
{
    public class BaseService
    {
        protected CP25Team02Entities dbContext;
        public BaseService()
        {
            dbContext = new CP25Team02Entities();
        }
    }
}