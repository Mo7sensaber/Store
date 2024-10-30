using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Store.Core.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repositorty.Identity.Contexts
{
    public class StoreIdentityDbContext : IdentityDbContext<AppUser>
    {
        public StoreIdentityDbContext(DbContextOptions<StoreIdentityDbContext> options) : base(options)
        {

        }

        public static async Task SeedAppUserAsync(UserManager<AppUser> userManager)
        {
            // تحقق إذا كان هناك أي مستخدمين موجودين بالفعل
            if (!userManager.Users.Any())
            {
                // إنشاء مستخدم جديد
                var user = new AppUser
                {
                    DisplayName = "Admin",
                    UserName = "admin",
                    Email = "admin@store.com",
                    EmailConfirmed = true,
                    
                };

                // إضافة المستخدم إلى قاعدة البيانات
                await userManager.CreateAsync(user, "Admin@123");

                // يمكنك أيضًا إضافة أدوار إذا كنت تستخدم الأدوار
                // مثل هذا:
                // await userManager.AddToRoleAsync(user, "Admin");
            }
        }

    }

}

