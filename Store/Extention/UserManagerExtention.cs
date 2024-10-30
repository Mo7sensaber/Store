using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Store.Core.Entities.Identity;
using Store.Error;
using System.Security.Claims;

namespace Store.Extention
{
    public static class UserManagerExtention
    {
        public static async Task<AppUser> FindByEmailWithAddressAsync(this UserManager<AppUser> userManager, ClaimsPrincipal User)
        {
            var userEmail = User.FindFirstValue(ClaimTypes.Email);
            if (userEmail is null) return null;

            var user=await userManager.Users.Include(x => x.Address).FirstOrDefaultAsync(x => x.Email == userEmail);
            if (user is null) return null;

            return user;
        }
    }
}
