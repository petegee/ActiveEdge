using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Model
{
    public class Organization: Entity
    {
        [Required]
        public string OrganizationName { get; set; }

        [Required]
        public string ContactPerson { get; set; }

        [Required]
        public string ContactPhoneNumber { get; set; }

        [EmailAddress]
        [Required]
        public string ContactEmailAddress { get; set; }

        public virtual List<Clinic> Clinics { get; set; }

        public virtual List<ApplicationUser> Users { get; set; }

    }
}
