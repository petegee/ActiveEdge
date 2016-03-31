using System.Web.Mvc;

namespace ActiveEdge.Helpers
{
  /// <summary>
  /// Wrapper for <see cref="TagBuilder"/> that makes
  /// it a fluent API.
  /// </summary>
  public class FluentTagBuilder
  {
    private readonly TagBuilder _mBuilder;

    public FluentTagBuilder(string tagName)
    {
      _mBuilder = new TagBuilder(tagName);
    }

    public FluentTagBuilder MergeAttribute(string key, string value)
    {
      _mBuilder.MergeAttribute(key, value);

      return this;
    }

    public FluentTagBuilder AddCssClass(string cssClass)
    {
      _mBuilder.AddCssClass(cssClass);

      return this;
    }

    public string InnerHtml
    {
      get
      {
        return _mBuilder.InnerHtml;
      }
      set
      {
        _mBuilder.InnerHtml = value;
      }
    }

    public override string ToString()
    {
      return _mBuilder.ToString();
    }
  }
}