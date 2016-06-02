using Domain.Model;

namespace Domain.Query.Clients
{
    public class GetAllClientsForOrganization : IQuery<Client>
    {
        /// <summary>Initializes a new instance of the <see cref="T:System.Object" /> class.</summary>
        public GetAllClientsForOrganization(int? organizationId)
        {
            OrganizationId = organizationId;
        }

        public int? OrganizationId { get; }
    }
}