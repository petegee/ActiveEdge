using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace ActiveEdge.Database
{
  public class ReadModelDbContext : DbContext
  {
    /// <summary>
    /// Constructs a new context instance using conventions to create the name of the database to
    ///             which a connection will be made.  The by-convention name is the full name (namespace + class name)
    ///             of the derived context class.
    ///             See the class remarks for how this is used to create a connection.
    /// </summary>
    protected ReadModelDbContext() : base("DefaultConnection")
    {
    }

  }
}