//using System.Data.Entity;
//using System.Data.Entity.ModelConfiguration.Conventions;
//using Domain;

//namespace ActiveEdge.Database
//{
//  public class ActiveEdgeInitializer : DropCreateDatabaseIfModelChanges<ActiveEdgeContext>
//  {
//    /// <summary>
//    /// Executes the strategy to initialize the database for the given context.
//    /// </summary>
//    /// <param name="context">The context. </param><exception cref="T:System.ArgumentNullException"><paramref name="context"/>
//    ///             is
//    ///             <c>null</c>
//    ///             .
//    ///             </exception>
//    public override void InitializeDatabase(ActiveEdgeContext context)
//    {
//      base.InitializeDatabase(context);
//    }
//  }
//  public class ActiveEdgeContext : DbContext
//  {
//    /// <summary>
//    /// Constructs a new context instance using the given string as the name or connection string for the
//    ///             database to which a connection will be made.
//    ///             See the class remarks for how this is used to create a connection.
//    /// </summary>
//    public ActiveEdgeContext() : base("DefaultConnection")
//    {
//    }

//    public DbSet<Client> Customers { get; set; }

//    /// <summary>
//    /// This method is called when the model for a derived context has been initialized, but
//    ///             before the model has been locked down and used to initialize the context.  The default
//    ///             implementation of this method does nothing, but it can be overridden in a derived class
//    ///             such that the model can be further configured before it is locked down.
//    /// </summary>
//    /// <remarks>
//    /// Typically, this method is called only once when the first instance of a derived context
//    ///             is created.  The model for that context is then cached and is for all further instances of
//    ///             the context in the app domain.  This caching can be disabled by setting the ModelCaching
//    ///             property on the given ModelBuidler, but note that this can seriously degrade performance.
//    ///             More control over caching is provided through use of the DbModelBuilder and DbContextFactory
//    ///             classes directly.
//    /// </remarks>
//    /// <param name="modelBuilder">The builder that defines the model for the context being created. </param>
//    protected override void OnModelCreating(DbModelBuilder modelBuilder)
//    {
//      modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
//    }
//  }
//}