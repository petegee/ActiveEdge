using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace ActiveEdge.Helpers
{
  public static class HtmlBuilder
  {
    public static MvcHtmlString FormGroupEditorFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression)
    {
      /*
        <div class="form-group">
          @Html.LabelFor(model => model.FirstName)
          @Html.EditorFor(model => model.FirstName, new { @class = "form-control" })
        </div>
      */
      
      var div = new FluentTagBuilder("div")
        .AddCssClass("form-group");

      div.InnerHtml = @html.LabelFor(expression).ToString() +  @html.EditorFor(expression, new {@class = "form-control"});

      return new MvcHtmlString(div.ToString());
    }

    public static MvcHtmlString FormGroupEnumDropDownListFor<TModel, TValue>(this HtmlHelper<TModel> html,
      Expression<Func<TModel, TValue>> expression)
    {
      var div = new FluentTagBuilder("div")
        .AddCssClass("form-group");

      div.InnerHtml = @html.LabelFor(expression).ToString() + @html.EnumDropDownListFor(expression, new { @class = "form-control" });

      return new MvcHtmlString(div.ToString());
    }
    public static MvcHtmlString FormGroupCheckBoxFor<T>(this HtmlHelper<T> html, Expression<Func<T, bool>> expression)
    {
      var label = new TagBuilder("label")
        .InnerHtml = html.CheckBoxFor(expression, new {@class = "i-checks"}) + "  " + html.DisplayNameFor(expression);


      var div = new FluentTagBuilder("div")
        .AddCssClass("form-group");

      div.InnerHtml = label;

      return new MvcHtmlString(div.ToString());
    }
  }
}