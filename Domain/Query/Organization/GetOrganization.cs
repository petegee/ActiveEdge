namespace Domain.Query.Organization
{
    public class GetOrganization : IQuery<Model.Organization>
    {
        /// <summary>Initializes a new instance of the <see cref="T:System.Object" /> class.</summary>
        public GetOrganization(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}