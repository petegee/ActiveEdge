using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ActiveEdge.Read.Model.Organization
{
    public class OrganizationModel
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Organization Name")]
        public string OrganizationName { get; set; }

        [DisplayName("Contact Name")]
        [Required]
        public string ContactPerson { get; set; }

        [DisplayName("Contact Number")]
        [Required]
        public string ContactPhoneNumber { get; set; }

        [DisplayName("Contact Email Address")]
        [EmailAddress]
        [Required]
        public string ContactEmailAddress { get; set; }

        public List<ClinicModel> Clinics { get; set; }
    }
}