using System.ComponentModel.DataAnnotations;

namespace Domain.Model
{
    public class Clinic : Entity
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

        public Address Address { get; set; }
    }
}