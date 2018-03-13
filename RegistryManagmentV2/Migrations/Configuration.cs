using System.Collections.Generic;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using RegistryManagmentV2.Models;
using RegistryManagmentV2.Models.Domain;

namespace RegistryManagmentV2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            if (!System.Diagnostics.Debugger.IsAttached)
                System.Diagnostics.Debugger.Launch();
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));
            //var userManager = IdentityConfig.C
            foreach (UserRole role in Enum.GetValues(typeof(UserRole)))
            {
                //if (roleManager.RoleExists(role.ToString()))
                //{
                    roleManager.Create(new IdentityRole(role.ToString()));
                //}
            }

            var password = "123456";
            var user1 = new ApplicationUser()
            {
                Email = "test_user@test.com",
                UserName = "JohnDoe",
                AccountStatus = AccountStatus.Approved
            };
            var user2 = new ApplicationUser()
            {
                Email = "test_user2@test.com",
                UserName = "JimGarham",
                AccountStatus = AccountStatus.PendingApproval
            };
            var admin = new ApplicationUser
            {
                Email = "test_user3@test.com",
                UserName = "BradMadox",
                AccountStatus = AccountStatus.Approved
            };

            //var claim1 = new IdentityUserClaim { ClaimType = "accountStatus", ClaimValue = user1.AccountStatus.ToString() };
            //user1.Claims.Add(claim1);
            //var claim2 = new IdentityUserClaim { ClaimType = "accountStatus", ClaimValue = user2.AccountStatus.ToString() };
            //user1.Claims.Add(claim2);
            //var claim3 = new IdentityUserClaim { ClaimType = "accountStatus", ClaimValue = admin.AccountStatus.ToString() };
            //user1.Claims.Add(claim3);

            var status = userManager.Create(user1, password);
            userManager.Create(user2, password);
            userManager.Create(admin, password);

            userManager.AddToRole(user1.Id, UserRole.User.ToString());
            userManager.AddToRole(user2.Id, UserRole.User.ToString());
            userManager.AddToRole(admin.Id, UserRole.Admin.ToString());

            base.Seed(context);
        }
    }
}
