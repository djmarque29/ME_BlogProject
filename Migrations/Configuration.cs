namespace ME_BlogProject.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using ME_BlogProject.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    internal sealed class Configuration : DbMigrationsConfiguration<ME_BlogProject.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "ME_BlogProject.Models.ApplicationDbContext";
        }

        protected override void Seed(ME_BlogProject.Models.ApplicationDbContext context)
        {

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            //Admin Role
            if (!context.Roles. Any(r => r.Name =="Admin"))
            {
                roleManager.Create(new IdentityRole { Name = "Admin" });
            }

            //Moderator Role
            if (!context.Roles.Any(r => r.Name == "Moderator"))
            {
                roleManager.Create(new IdentityRole { Name = "Moderator" });
            }

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            //Adding Admin
            if(!context.Users.Any(u => u.Email == "mellis@email.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "mellis@email.com",
                    Email = "mellis@email.com",
                    FirstName = "Marc",
                    LastName = "Ellis",
                    DisplayName = "GoDj"
                }, "Abc&123!");
            }

            var userId = userManager.FindByEmail("mellis@email.com").Id;
            userManager.AddToRole(userId, "Admin");

            //Adding Moderator
            if (!context.Users.Any(u => u.Email == "moderator@email.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "moderator@email.com",
                    Email = "moderator@email.com",
                    FirstName = "Dj",
                    LastName = "Marque",
                    DisplayName = "Drum and Bass"
                }, "Abc&123!");
            }

            userId = userManager.FindByEmail("moderator@email.com").Id;
            userManager.AddToRole(userId, "Moderator");

        }
    }
}
