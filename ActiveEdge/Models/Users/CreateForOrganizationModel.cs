using System.ComponentModel.DataAnnotations;

namespace ActiveEdge.Models.Users
{
    public class CreateForOrganizationModel
    {
        [EmailAddress]
        public string EmailAddress { get; set; }

        public int OrganizationId { get; set; }
    }
}