using System.Web.Mvc;
using Domain.Context;
using Owin;
using DatabaseInitializer = ActiveEdge.Infrastructure.DatabaseInitializer;

//[assembly: OwinStartup(typeof(Startup))]

namespace ActiveEdge
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            SeedDatabase();
        }

        private static void SeedDatabase()
        {
            using (var databaseInitializer = DependencyResolver.Current.GetService<DatabaseInitializer>())
            {
                databaseInitializer.Seed().Wait();
            }


        }
    }
}