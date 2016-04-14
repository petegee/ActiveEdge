using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using ActiveEdge.Models;
using Domain;
using Microsoft.AspNet.Identity.EntityFramework;
using MySql.Data.Entity;

namespace ActiveEdge.Database
{
  public class DatabaseInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
  {
    /// <summary>
    /// A method that should be overridden to actually add data to the context for seeding.
    ///             The default implementation does nothing.
    /// </summary>
    /// <param name="context">The context to seed. </param>
    protected override void Seed(ApplicationDbContext context)
    {
      
      context.Clients.Add(new Domain.Client
      {
        FirstName = "Stuart",
        LastName = "Clark",
        DateOfBirth = new DateTime(1976, 6, 10),
        AddressLine1 = "12 Wattle Grove",
        Suburb = "Maungaraki",
        City = "Lower Hutt",
        ContactNumber = "021509357",
        Email = "sjclark76@gmail.com",
        ExcerciseFrequency = ExcerciseFrequency.FiveTimesAWeek,
        Gender = Gender.Male,
        ContraIndications = new ContraIndications(),
        TermsAndConditions = new TermsAndConditions()
      });

      context.Clients.Add(new Domain.Client
      {
        FirstName = "Joann ",
        LastName = "Clark",
        DateOfBirth = new DateTime(1979, 5, 23),
        AddressLine1 = "12 Wattle Grove",
        Suburb = "Maungaraki",
        City = "Lower Hutt",
        ContactNumber = "022409357",
        Email = "joclark@gmail.com",
        ExcerciseFrequency = ExcerciseFrequency.FiveTimesAWeek,
        Gender = Gender.Female,
        ContraIndications = new ContraIndications(),
        TermsAndConditions = new TermsAndConditions()
      });
    }
  }
  public interface IApplicationDbContext: IDisposable
  {
    DbSet<Domain.Client> Clients { get; set; }
    System.Data.Entity.DbSet<ActiveEdge.Models.SoapNoteModel> SoapNoteModels { get; set; }

    int SaveChanges();

    DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
  }

  [DbConfigurationType(typeof(MySqlEFConfiguration))]
  public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
  {
    // ApplicationDbContext()
    //{
      
    //  //System.Data.Entity.Database.SetInitializer(new  MigrateDatabaseToLatestVersion<ApplicationDbContext, Migrations.Configuration>("DefaultConnection"));
    //  //System.Data.Entity.Database.SetInitializer(new MySqlInitializer());
    //  // System.Data.Entity.Database.SetInitializer(new ActiveEdgeInitializer());
    //}

    public ApplicationDbContext()
      : base("DefaultConnection")
    {
     // System.Data.Entity.Database.SetInitializer(new DatabaseInitializer());
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

    public System.Data.Entity.DbSet<ActiveEdge.Models.SoapNoteModel> SoapNoteModels { get; set; }
  }
}