using System.ComponentModel.DataAnnotations;

namespace Domain.Model
{
    public class Clinic : Entity
    {
        [Required]
        public string ClinicName { get; set; }

        public Address Address { get; set; }

        public virtual Organization Organization { get; set; }

        public int OrganizationId { get; set; }
    }
}