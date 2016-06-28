using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace ActiveEdge.Read.Model.Organization
{
    public class ClinicModel
    {
        [DisplayName("Clinic Name")]
        [Required]
        [JsonProperty(PropertyName = "clinicName")]
        public string ClinicName { get; set; }

        [DisplayName("Address Line 1")]
        [Required]
        [JsonProperty(PropertyName = "addressLine1")]
        public string AddressLine1 { get; set; }

        [DisplayName("Address Line 2")]
        [JsonProperty(PropertyName = "addressLine2")]
        public string AddressLine2 { get; set; }

        [DisplayName("Suburb")]
        [Required]
        [JsonProperty(PropertyName = "suburb")]
        public string Suburb { get; set; }

        [DisplayName("City")]
        [Required]
        [JsonProperty(PropertyName = "city")]
        public string City { get; set; }

        [StringLength(10)]
        [JsonProperty(PropertyName = "postCode")]
        public string PostCode { get; set; }

        [StringLength(50)]
        [JsonProperty(PropertyName = "contactPhoneNumber")]
        public string PhoneNumber { get; set; }

    }
}