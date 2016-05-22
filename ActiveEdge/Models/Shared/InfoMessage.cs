namespace ActiveEdge.Models.Shared
{
    public class InfoMessage : Message
    {
        /// <summary>Initializes a new instance of the <see cref="T:System.Object" /> class.</summary>
        public InfoMessage(string text) : base(text)
        {
        }

        public override string Css => "alert alert-info";
    }
}