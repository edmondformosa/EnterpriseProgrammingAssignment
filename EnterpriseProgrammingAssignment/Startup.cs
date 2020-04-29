using EnterpriseProgrammingAssignment.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using System;
using System.Data.Entity;

[assembly: OwinStartupAttribute(typeof(EnterpriseProgrammingAssignment.Startup))]
namespace EnterpriseProgrammingAssignment
{
    public partial class Startup : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            SeedDb();
        }

        private void SeedDb()
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                using (RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context)))
                {
                    if (!roleManager.RoleExists("Admin"))
                    {

                        IdentityRole role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                        role.Name = "Admin";
                        roleManager.Create(role);

                    }

                }
                using (UserManager<ApplicationUser> UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context)))
                {
                    if (UserManager.FindByName("administrator@gmail.com") == null)
                    {
                        ApplicationUser newAdmin = new ApplicationUser();
                        newAdmin.UserName = "administrator@gmail.com";
                        newAdmin.Email = "administrator@gmail.com";

                        string pass = "Admin1234%";
                        IdentityResult userRole = UserManager.Create(newAdmin, pass);

                        if (userRole.Succeeded)
                        {
                            IdentityResult ckRole = UserManager.AddToRole(newAdmin.Id, "Admin");
                            if (!userRole.Succeeded)
                            {
                                Console.Error.WriteLine("An error occured! Admin user not available.");
                            }
                        }
                    }
                    else
                    {
                        Console.Error.WriteLine("An error occured! Admin user not available.");

                    }
                }
            }
        }

       
    }
}
