using System.Web.Http.Dependencies;
using StructureMap;

namespace ActiveEdge.DependencyResolution
{
  public class StructureMapDependencyResolver : StructureMapDependencyScope, System.Web.Http.Dependencies.IDependencyResolver
  {
    public StructureMapDependencyResolver(IContainer container) : base(container)
    {
    }
    public IDependencyScope BeginScope()
    {
      IContainer child = this.Container.GetNestedContainer();
      return new StructureMapDependencyResolver(child);
    }
  }
}