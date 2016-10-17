using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Domain.Event.Organization;
using Newtonsoft.Json;

namespace ActiveEdge.Read.Model.Organization
{
    public class OrganizationModel
    {
        public OrganizationModel()
        {
            Clinics = new List<ClinicModel>();
        }

        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }

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

        public void Apply(OrganizationCreated domainEvent)
        {
            OrganizationName = domainEvent.OrganizationName;
            ContactPerson = domainEvent.ContactPerson;
            ContactPhoneNumber = domainEvent.ContactPhoneNumber;
            ContactEmailAddress = domainEvent.ContactEmailAddress;

            foreach (var clinic in domainEvent.Clinics)
                Clinics.Add(new ClinicModel
                {
                    Id = clinic.Id,
                    ClinicName = clinic.ClinicName,
                    AddressLine1 = clinic.AddressLine1,
                    AddressLine2 = clinic.AddressLine2,
                    Suburb = clinic.Suburb,
                    City = clinic.City,
                    PostCode = clinic.PostCode,
                    PhoneNumber = clinic.PhoneNumber
                });
        }

        public void Apply(OrganizationUpdated domainEvent)
        {
            OrganizationName = domainEvent.OrganizationName;
            ContactPerson = domainEvent.ContactPerson;
            ContactPhoneNumber = domainEvent.ContactPhoneNumber;
            ContactEmailAddress = domainEvent.ContactEmailAddress;

            Clinics.Clear();
            foreach (var clinic in domainEvent.Clinics)
                Clinics.Add(new ClinicModel
                {
                    ClinicName = clinic.ClinicName,
                    AddressLine1 = clinic.AddressLine1,
                    AddressLine2 = clinic.AddressLine2,
                    Suburb = clinic.Suburb,
                    City = clinic.City,
                    PostCode = clinic.PostCode,
                    PhoneNumber = clinic.PhoneNumber
                });
        }

        
    }
}