using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ActiveEdge.Infrastructure
{
  [AttributeUsage(AttributeTargets.Property)]
  public class PlaceHolderAttribute: Attribute
  {
  }
}