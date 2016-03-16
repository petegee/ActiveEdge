using System;
using System.Linq;
using AutoMapper;

namespace ActiveEdge.Infrastructure.Mapping
{
  public static class AutomapperExtensions
  {
    public static void Unflatten<T>(this IMemberConfigurationExpression<T> config)
    {
      config.ResolveUsing((resolutionResult, source) =>
      {
        var prefix = resolutionResult.Context.MemberName;

        var resolvedObject =
          Activator.CreateInstance(resolutionResult.Context.DestinationType);

        var targetProperties = resolvedObject.GetType().GetProperties();

        foreach (var sourceMember in source.GetType().GetProperties())
        {
          // find the matching target property and populate it
          var matchedProperty = targetProperties
            .FirstOrDefault(p => sourceMember.Name == prefix + p.Name);

          matchedProperty?.SetValue(resolvedObject, sourceMember.GetValue(source));
        }

        return resolvedObject;
      });
    }
  }
}