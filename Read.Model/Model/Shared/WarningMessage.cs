using System.Web.Mvc;

namespace ActiveEdge.Read.Model.Shared
{
    public class WarningMessage : Message
    {
        /// <summary>Initializes a new instance of the <see cref="T:System.Object" /> class.</summary>
        public WarningMessage(MvcHtmlString text) : base(text)
        {
        }

        public override string Css => "alert alert-warning";
    }
}