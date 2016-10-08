using System.Web.Mvc;

namespace ActiveEdge.Read.Model.Shared
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

        /// <summary>Initializes a new instance of the <see cref="T:System.Object" /> class.</summary>
        public SuccessMessage()
        {
        }
        public override string Css => "alert alert-success";
    }
}