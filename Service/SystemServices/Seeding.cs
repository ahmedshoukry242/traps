using Core.Constants;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.SystemServices
{
    public class Seeding
    {
        private readonly RoleManager<IdentityRole<Guid>> _roleManager;
        public Seeding(RoleManager<IdentityRole<Guid>> roleManager)
        {
            _roleManager = roleManager;
        }
        public async Task SeedRoles()
        {
            List<string> roles = [RoleName.Superadmin, RoleName.User, RoleName.UserChild, RoleName.SuperVisor];
           
            foreach(var role in roles)
            {
                var isExist = await _roleManager.RoleExistsAsync(role);
                if (!isExist)
                    await _roleManager.CreateAsync(new IdentityRole<Guid> { Name = role });
            }
        }
    }
}
