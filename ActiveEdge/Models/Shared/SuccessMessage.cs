using System.Web.Mvc;

namespace ActiveEdge.Models.Shared
{
    public class SuccessMessage : Message
    {
        /// <summary>Initializes a new instance of the <see cref="T:System.Object" /> class.</summary>
        public SuccessMessage(string text) : base(new MvcHtmlString(text))
        {
        }

        /// <summary>Initializes a new instance of the <see cref="T:System.Object" /> class.</summary>
        public SuccessMessage(MvcHtmlString text) : base(text)
        {
        }

        public override string Css => "alert alert-success";
    }
}