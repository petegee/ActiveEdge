using System.Web.Mvc;

namespace ActiveEdge.Read.Model.Shared
{
    public abstract class Message
    {
        public MvcHtmlString Text { get; set; }

        /// <summary>Initializes a new instance of the <see cref="T:System.Object" /> class.</summary>
        protected Message()
        {
        }

        /// <summary>Initializes a new instance of the <see cref="T:System.Object" /> class.</summary>
        protected Message(MvcHtmlString text)
        {
            Text = text;
        }

        public abstract string Css { get; }
    }
}