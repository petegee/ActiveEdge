using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Infrastructure.Interception;
using Domain.Model;
using EntityFramework.Filters;
using Microsoft.AspNet.Identity.EntityFramework;
using MySql.Data.Entity;
using Shared;

namespace Domain.Context
{
    public interface IApplicationDbContext : IDisposable
    {
        DbSet<Client> Clients { get; set; }
        DbSet<Session> Sessions { get; set; }
        DbSet<Organization> Organizations { get; set; }
        DbSet<Address> Addresses { get; set; }
        IDbSet<ApplicationUser> Users { get; set; }
        int SaveChanges();

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        void EnableOrganizationTenant();
        void DisableOrganizationTenant();
    }

    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
    {
        private readonly ILoggedOnUser _loggedOnUser;
        private const string FilterName = "OrganizationTenant";

        public ApplicationDbContext()
            : base("DefaultConnection")
        {
            _loggedOnUser = new LoggedOnUser();
        }

        public DbSet<Client> Clients { get; set; }

        public DbSet<Session> Sessions { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Address> Addresses { get; set; }

        public void EnableOrganizationTenant()
        {
            this.EnableFilter(FilterName)
                .SetParameter("organizationId", _loggedOnUser.OrganizationId); 
        }

        public void DisableOrganizationTenant()
        {
            this.DisableFilter(FilterName);
        }
        /// <summary>
        ///     Maps table names, and sets up relationships between the various user entities
        /// </summary>
        /// <param name="modelBuilder" />
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            DbInterception.Add(new FilterInterceptor());

            modelBuilder.Conventions.Add(FilterConvention.Create<IAmLinkedToAnOrganization, int>(FilterName, (entity, organizationId) => organizationId == 0 || entity.OrganizationId == organizationId));

            // modelBuilder.Entity<Domain.Client>().ToTable("Customer");
            base.OnModelCreating(modelBuilder);
        }
    }
}