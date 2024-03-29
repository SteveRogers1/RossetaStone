﻿using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using RossetaStone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RossetaStone.Data
{
    public static class SeedData
    {
        public static async Task EnsureSeedData(IServiceProvider provider)
        {
            var roleMgr = provider.GetRequiredService<RoleManager<IdentityRole>>();
            foreach (var roleName in Role.AllRoles)
            {
                var role = roleMgr.FindByNameAsync(roleName).Result;

                if (role == null)
                {
                    var result = roleMgr.CreateAsync(new IdentityRole { Name = roleName }).Result;
                    if (!result.Succeeded) throw new Exception(result.Errors.First().Description);
                }
            }

            var userMgr = provider.GetRequiredService<UserManager<IdentityUser>>();

            var adminResult = await userMgr.CreateAsync(DefaultUsers.Administrator,  "User123!");
            var userResult = await userMgr.CreateAsync(DefaultUsers.User, "User123!");

            if (adminResult.Succeeded || userResult.Succeeded)
            {

                var adminUser = await userMgr.FindByEmailAsync(DefaultUsers.Administrator.Email);
                var commonUser = await userMgr.FindByEmailAsync(DefaultUsers.User.Email);

                await userMgr.AddToRoleAsync(adminUser, Role.Administrator);
                await userMgr.AddToRoleAsync(commonUser, Role.User);
            }
        }
    }

    public static class DefaultUsers
    {

        public static readonly IdentityUser Administrator = new IdentityUser
        {
            Email = "Admin@gmail.com",
            EmailConfirmed = true,
            UserName = "Admin@gmail.com"
        };

        public static readonly IdentityUser User = new IdentityUser
        {
            Email = "User@gmail.com",
            EmailConfirmed = true,
            UserName = "User@gmail.com",
        };

        public static IEnumerable<IdentityUser> AllUsers
        {
            get
            {
                yield return Administrator;
                yield return User;
            }
        }
    }
}
