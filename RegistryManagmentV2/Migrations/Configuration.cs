using RegistryManagmentV2.Models;

namespace RegistryManagmentV2.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<RegistryManagmentV2.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(RegistryManagmentV2.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.Users.AddOrUpdate(
                new User
                {
                    Id = 1,
                    Email = "test_user@test.com",
                    Name = "John Doe",
                    Password = "12345",
                    UserRole = UserRole.User.ToString()
                },
                new User
                {
                    Id = 2,
                    Email = "test_user2@test.com",
                    Name = "Jim Garham",
                    Password = "12345",
                    UserRole = UserRole.User.ToString()
                },
                new User
                {
                    Id = 3,
                    Email = "test_user3@test.com",
                    Name = "Brad Madox",
                    Password = "12345",
                    UserRole = UserRole.Admin.ToString()
                });
        }
    }
}
