using System;
using System.Linq;
using System.Web.Mvc;
using ActiveEdge;
using Domain.Context;
using Domain.Model;
using Marten;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

//[assembly: OwinStartup(typeof(Startup))]
namespace ActiveEdge
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {

            ConfigureAuth(app);

            AddSystemAdmin();
        }

        private static void AddSystemAdmin()
        {
            var session = DependencyResolver.Current.GetService<IDocumentSession>();
            var userManager = DependencyResolver.Current.GetService<UserManager<ApplicationUser>>();

            if (!session.Query<IdentityRole>().Any() == false)
            {
                session.Store(new IdentityRole { Name = Roles.SystemAdministrator });
                session.Store(new IdentityRole { Name = Roles.OrganizationAdministrator });
                session.Store(new IdentityRole { Name = Roles.Therapist });
            }

            if (!session.Query<ApplicationUser>().Any(u => u.UserName == "sjclark76@gmail.com"))
            {
                var userToInsert = new ApplicationUser { Id = Guid.NewGuid().ToString(),  UserName = "sjclark76@gmail.com", PhoneNumber = "021509357" };
                
                userManager.Create(userToInsert, "ridgeback");
                userManager.AddToRole(userToInsert.Id, Roles.SystemAdministrator);
            }

            session.SaveChanges();
        }
    }
}
