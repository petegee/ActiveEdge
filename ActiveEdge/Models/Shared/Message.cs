namespace ActiveEdge.Models.Shared
{
    public abstract class Message
    {
        public string Text { get; set; }

        /// <summary>Initializes a new instance of the <see cref="T:System.Object" /> class.</summary>
        protected Message(string text)
        {
            Text = text;
        }

        public abstract string Css { get; }
    }
}