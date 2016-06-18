using ActiveEdge.Read.Model.Organization;
using MediatR;
using Shared;

namespace ActiveEdge.Read.Query.Organization
{
    public class GetOrganization : IQueryForSingleOrDefault<OrganizationModel>
    {
        /// <summary>Initializes a new instance of the <see cref="T:System.Object" /> class.</summary>
        public GetOrganization(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}