using System;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using ActiveEdge.Read.Model;
using ActiveEdge.Read.Model.Client;
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
            var html = new HtmlHelper<ClientModel>(vc, new FakeViewDataContainer());

            //var htmlString = html.FormGroupCheckBoxFor(client => client.IsSmoker);

            //Coknsole.WriteLine(htmlString);
        }
    }

    internal class FakeHttpContext : HttpContextBase
    {
        private readonly Dictionary<object, object> _items = new Dictionary<object, object>();

        public override IDictionary Items
        {
            get { return _items; }
        }
    }

    internal class FakeViewDataContainer : IViewDataContainer
    {
        public ViewDataDictionary ViewData { get; set; } = new ViewDataDictionary();
    }
}