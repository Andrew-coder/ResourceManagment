using System.Collections.Generic;
using System.Linq;
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
                roleManager.Create(new IdentityRole(role.ToString()));
            }

            var password = "123456";

            var teachersGroup = new UserGroup { Id = 1, Name = "викладачі" };
            var assistanceGroup = new UserGroup { Id = 2, Name = "асистенти" };

            var userGroups = new List<UserGroup> { teachersGroup, assistanceGroup };
            var user1 = new ApplicationUser()

            {
                Email = "test_user@test.com",
                UserName = "JohnDoe",
                AccountStatus = AccountStatus.Approved,
                UserGroup = teachersGroup
            };
            var user2 = new ApplicationUser()
            {
                Email = "test_user2@test.com",
                UserName = "JimGarham",
                AccountStatus = AccountStatus.PendingApproval,
                UserGroup = assistanceGroup
            };
            var admin = new ApplicationUser
            {
                Email = "test_user3@test.com",
                UserName = "BradMadox",
                AccountStatus = AccountStatus.Approved
            };
            var emails = new List<string> {user1.Email, user2.Email, admin.Email};
            if (!context.Users.Any(user => emails.Contains(user.Email)))
            {
                userManager.Create(user1, password);
                userManager.Create(user2, password);
                userManager.Create(admin, password);

                userManager.AddToRole(user1.Id, UserRole.User.ToString());
                userManager.AddToRole(user2.Id, UserRole.User.ToString());
                userManager.AddToRole(admin.Id, UserRole.Admin.ToString());
            }
            
            var parentCatalog = new Catalog() { Id=1, Name = "ректорський контроль", SecurityLevel = 5, UserGroups = new List<UserGroup> { teachersGroup} };
            var childCatalog1 = new Catalog() { Id=2, Name = "план", SuperCatalog = parentCatalog, SecurityLevel = 5, UserGroups = new List<UserGroup> { teachersGroup}};
            var childCatalog2 = new Catalog() { Id=3, Name = "оцінки", SuperCatalog = parentCatalog, SecurityLevel = 5, UserGroups = new List<UserGroup> { teachersGroup, assistanceGroup } };

            //teachersGroup.Catalogs = new List<Catalog>{parentCatalog, childCatalog1, childCatalog2};
            //assistanceGroup.Catalogs = new List<Catalog> {childCatalog2};
            userGroups.ForEach(userGroup => context.UserGroups.AddOrUpdate(userGroup));

            new List<Catalog> { parentCatalog, childCatalog1, childCatalog2 }
            .ForEach(catalog => context.Catalogs.AddOrUpdate(catalog));
            //context.Catalogs.AddRange(new List<Catalog> {parentCatalog, childCatalog1, childCatalog2});

            base.Seed(context);
        }
    }
}
