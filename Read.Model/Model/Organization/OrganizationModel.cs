using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace ActiveEdge.Read.Model.Organization
{
    public class OrganizationModel
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [Required]
        [DisplayName("Organization Name")]
        [JsonProperty(PropertyName = "organizationName")]
        public string OrganizationName { get; set; }

        [DisplayName("Contact Name")]
        [Required]
        [JsonProperty(PropertyName = "contactPerson")]
        public string ContactPerson { get; set; }

        [DisplayName("Contact Number")]
        [Required]
        [JsonProperty(PropertyName = "contactPhoneNumber")]
        public string ContactPhoneNumber { get; set; }

        [DisplayName("Contact Email Address")]
        [EmailAddress]
        [Required]
        [JsonProperty(PropertyName = "contactEmailAddress")]
        public string ContactEmailAddress { get; set; }

        [JsonProperty(PropertyName = "clinics")]
        public List<ClinicModel> Clinics { get; set; }
    }
}