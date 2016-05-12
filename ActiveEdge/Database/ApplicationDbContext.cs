using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using ActiveEdge.Models;
using Domain;
using Domain.Model;
using Microsoft.AspNet.Identity.EntityFramework;
using MySql.Data.Entity;

namespace ActiveEdge.Database
{
  public interface IApplicationDbContext: IDisposable
  {
    DbSet<Client> Clients { get; set; }
    System.Data.Entity.DbSet<Session> Sessions { get; set; }

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

    /// <summary>
    /// Maps table names, and sets up relationships between the various user entities
    /// </summary>
    /// <param name="modelBuilder"/>
    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
     // modelBuilder.Entity<Domain.Client>().ToTable("Customer");
      base.OnModelCreating(modelBuilder);
    }

    public System.Data.Entity.DbSet<Session> Sessions { get; set; }
  }
}