using CAP_Backend_Source.Models;
using CAP_Backend_Source.Modules.Account.Enum;
using CAP_Backend_Source.Services;
using CAP_Backend_Source.Services.User.Request;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data.Entity.Validation;
using System.Threading.Tasks;

namespace CAP_Backend_UnitTest
{
    [TestClass]
    public class AccountUnitTest
    {
        [TestMethod]
        public async Task Get_Success()
        {
            AccountService accountService = new AccountService();
            var acc = await accountService.GetAsync("Admin@gmail.com", "Admin");

            Assert.IsNotNull(acc);
        }

        [TestMethod]
        public async Task Get_Fail()
        {
            AccountService accountService = new AccountService();
            var acc = await accountService.GetAsync("fghshdgjhd", "Admin");

            Assert.IsNull(acc);
        }

        [TestMethod]
        [ExpectedException(typeof(DbEntityValidationException))]
        public async Task Create_Fail()
        {
            AccountService accountService = new AccountService();
            accountService.Create(new CreateAccountRequest()
            {
                RoleId = 1,
                Address = "Test",
                Name = "Test",
                Password = "Test"
            });
            Assert.Fail();
        }

        [TestMethod]
        public async Task Create_Success()
        {
            AccountService accountService = new AccountService();
            var acc = accountService.Create(new CreateAccountRequest()
            {
                RoleId = 2,
                Address = "Test",
                Name = "Test",
                Email = "Test@gmail.com",
                Password = "Test"
            });
            Assert.IsInstanceOfType(acc,typeof(Account));
        }
    }
}
