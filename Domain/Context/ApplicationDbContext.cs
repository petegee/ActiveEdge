using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using ActiveEdge.Models;
using Domain.Model;
using Microsoft.AspNet.Identity.EntityFramework;
using MySql.Data.Entity;

namespace Domain.Context
{
    public interface IApplicationDbContext : IDisposable
    {
        DbSet<Client> Clients { get; set; }
        DbSet<Session> Sessions { get; set; }
        DbSet<Organization> Organizations { get; set; }
        DbSet<Address> Addresses { get; set; }
        int SaveChanges();

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }

    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<Client> Clients { get; set; }

        public DbSet<Session> Sessions { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Address> Addresses { get; set; }
        /// <summary>
        ///     Maps table names, and sets up relationships between the various user entities
        /// </summary>
        /// <param name="modelBuilder" />
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // modelBuilder.Entity<Domain.Client>().ToTable("Customer");
            base.OnModelCreating(modelBuilder);
        }
    }
}