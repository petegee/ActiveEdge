using System.Web.Mvc;

namespace ActiveEdge.Read.Model.Shared
{
    public class InfoMessage : Message
    {
        /// <summary>Initializes a new instance of the <see cref="T:System.Object" /> class.</summary>
        public InfoMessage(string text) : base(new MvcHtmlString(text))
        {
        }

        /// <summary>Initializes a new instance of the <see cref="T:System.Object" /> class.</summary>
        public InfoMessage(MvcHtmlString text) : base(text)
        {
        }

        public override string Css => "alert alert-info";
    }
}