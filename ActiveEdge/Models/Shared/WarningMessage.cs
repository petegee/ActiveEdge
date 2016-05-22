namespace ActiveEdge.Models.Shared
{
    public class WarningMessage : Message
    {
        /// <summary>Initializes a new instance of the <see cref="T:System.Object" /> class.</summary>
        public WarningMessage(string text) : base(text)
        {
        }

        public override string Css => "alert alert-warning";
    }
}