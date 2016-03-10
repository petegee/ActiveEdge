using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using ActiveEdge.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ActiveEdge.Database
{
  public interface IApplicationDbContext: IDisposable
  {
    DbSet<Domain.Client> Clients { get; set; }

    int SaveChanges();

    DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
  }

  public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
  {
    static ApplicationDbContext()
    {
      System.Data.Entity.Database.SetInitializer(new MySqlInitializer());
     // System.Data.Entity.Database.SetInitializer(new ActiveEdgeInitializer());
    }

    public ApplicationDbContext()
      : base("DefaultConnection")
    {
     
    }

    public DbSet<Domain.Client> Clients { get; set; }

    /// <summary>
    /// Maps table names, and sets up relationships between the various user entities
    /// </summary>
    /// <param name="modelBuilder"/>
    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
     // modelBuilder.Entity<Domain.Client>().ToTable("Customer");
      base.OnModelCreating(modelBuilder);
    }
  }
}