using CAP_Backend_Source.Models;
using CAP_Backend_Source.Modules.Account.Request;
using CAP_Backend_Source.Services.User.Request;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CAP_Backend_Source.Services
{
    public class AccountService : BaseService
    {
        public async Task<Account> GetAsync(string email, string password)
        {
            return  dbContext.Accounts
                .Where(x => x.Email == email && x.Password == password)
                .Include(x=>x.Role)
                .FirstOrDefault();
        }
        public  Account Create(CreateAccountRequest request)
        {
            var acc = new Account()
            {

                Email = request.Email,
            };
            dbContext.Accounts.Add(acc);
            dbContext.SaveChanges();
            return acc;
        }

        public async Task<List<Account>> SearchAsync()
        {
            return  dbContext.Accounts
                .ToList();
        }

        public async Task<Account> GetDetailAsync(int id)
        {
            return  dbContext.Accounts
                .Where(x => x.AccountId == id)
                .Include(x=>x.Role)
                .FirstOrDefault();
        }

        public async Task<Account> UpdateAsync(int accountId, UpdateAccountRequest request)
        {
            var acc =  dbContext.Accounts
                .Where(x => x.AccountId == accountId)
                .Include(x => x.Role)
                .FirstOrDefault();
            if (acc == null)
            {
                return null;
            }

            if ( dbContext.Roles
                .Where(x => x.RoleId == request.RoleId)
                .FirstOrDefault() == null)
            {
                return null;
            }

            acc.RoleId = request.RoleId;
             dbContext.SaveChanges();
            return acc;

        }
    }
}