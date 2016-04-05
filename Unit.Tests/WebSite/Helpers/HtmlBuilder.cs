using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ActiveEdge.Helpers;
using ActiveEdge.Models;
using Xunit;

namespace Unit.Tests.WebSite.Helpers
{
  public class HtmlBuilderFacts
  {
    [Fact]
    public void FormGroupCheckBoxForShouldRenderTheCorrectHtml()
    {
      var vc = new ViewContext();
      vc.HttpContext = new FakeHttpContext();
      vc.HttpContext.Items.Add(Guid.NewGuid(), "foo");
      HtmlHelper<ActiveEdge.Models.Client> html = new HtmlHelper<Client>(vc, new FakeViewDataContainer());

      //var htmlString = html.FormGroupCheckBoxFor(client => client.IsSmoker);

      //Coknsole.WriteLine(htmlString);
    }
  }

  class FakeHttpContext : HttpContextBase
  {
    private Dictionary<object, object> _items = new Dictionary<object, object>();
    public override IDictionary Items { get { return _items; } }
  }

  class FakeViewDataContainer : IViewDataContainer
  {
    private ViewDataDictionary _viewData = new ViewDataDictionary();
    public ViewDataDictionary ViewData { get { return _viewData; } set { _viewData = value; } }
  }
}
