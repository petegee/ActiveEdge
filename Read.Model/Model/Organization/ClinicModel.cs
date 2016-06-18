using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ActiveEdge.Read.Model.Organization
{
    public class ClinicModel
    {
        [DisplayName("Clinic Name")]
        [Required]
        public string ClinicName { get; set; }

        [DisplayName("Address Line 1")]
        [Required]
        public string AddressLine1 { get; set; }

        [DisplayName("Address Line 2")]
        public string AddressLine2 { get; set; }

        [DisplayName("Suburb")]
        [Required]
        public string Suburb { get; set; }

        [DisplayName("City")]
        [Required]
        public string City { get; set; }

        [StringLength(10)]
        public string PostCode { get; set; }

        [StringLength(50)]
        public string PhoneNumber { get; set; }

    }
}