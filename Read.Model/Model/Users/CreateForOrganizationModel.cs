using System;
using System.ComponentModel.DataAnnotations;

namespace ActiveEdge.Read.Model.Users
{
    public class CreateForOrganizationModel
    {
        [EmailAddress]
        public string EmailAddress { get; set; }

        public Guid OrganizationId { get; set; }
    }
}