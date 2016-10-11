namespace Domain.Model
{
    public class RemedialSession : SessionBase
    {
        public string MainConcerns { get; set; }

        public string History { get; set; }

        public string Complications { get; set; }

        public string FunctionalLimitations { get; set; }

    }
}