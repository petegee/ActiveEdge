using System.Web.Mvc;

namespace ActiveEdge.Read.Model.Shared
{
    public class DangerMessage : Message
    {
        public DangerMessage(MvcHtmlString htmlString) : base(htmlString)
        {
            
        }
        /// <summary>Initializes a new instance of the <see cref="T:System.Object" /> class.</summary>
        public DangerMessage(string text) : base(new MvcHtmlString(text))
        {
        }

        public override string Css => "alert alert-danger";
    }
}