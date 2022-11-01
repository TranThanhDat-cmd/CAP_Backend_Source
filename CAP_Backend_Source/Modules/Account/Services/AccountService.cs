using CAP_Backend_Source.Models;
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
            return await dbContext.Accounts
                .Where(x => x.Email == email && x.Password == password)
                .Include(x=>x.Role)
                .FirstOrDefaultAsync();
        }
        public Account Create(CreateAccountRequest request)
        {
            var acc = new Account()
            {
                Address = request.Address,
                Email = request.Email,
                FullName = request.Name,
                Password = request.Password,
                RoleId = request.RoleId,
            };
            dbContext.Accounts.Add(acc);
            dbContext.SaveChanges();
            return acc;
        }
    }
}