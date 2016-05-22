namespace ActiveEdge.Models.Shared
{
    public class DangerMessage : Message
    {
        /// <summary>Initializes a new instance of the <see cref="T:System.Object" /> class.</summary>
        public DangerMessage(string text) : base(text)
        {
        }

        public override string Css => "alert alert-danger";
    }
}