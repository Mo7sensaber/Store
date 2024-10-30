using Microsoft.AspNetCore.Identity;
using Store.Core.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repositorty.Identity
{
    public static class StoreIdentityDbContextSeed
    {
        public static async Task SeedAppUserAsync(UserManager<AppUser> _userManager)
        {
            if (_userManager.Users.Count() == 0)
            {
                var user = new AppUser()
                {
                    Email = "mohsensaber001@gmail.com",
                    DisplayName = "Mohsen Saber",
                    UserName = "mohsen.saber",
                    PhoneNumber = "01032999016",
                    Address = new Address()
                    {
                        FName = "Mohsen",
                        LName = "Saber",
                        City = "Giza",
                        Country = "Egypt",
                        Street = "Elshabab"
                    }
                };
                await _userManager.CreateAsync(user, "Mohsen1234#");
            }
        }
    }
}
