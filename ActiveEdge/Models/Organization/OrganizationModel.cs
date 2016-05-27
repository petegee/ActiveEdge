using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ActiveEdge.Models.Organization
{
   

    public class OrganizationModel
    {
   
        public int Id { get; set; }

        [DisplayName("Clinic Name")]
        [Required]
        public string ClinicName { get; set; }

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

        public AddressModel Address { get; set; }

    }
}