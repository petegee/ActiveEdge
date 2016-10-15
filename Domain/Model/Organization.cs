using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.Event;
using Domain.Event.Organization;

namespace Domain.Model
{
    public class Organization: Entity
    {
        public Organization()
        {
            Clinics = new List<Clinic>();
        }

        [Required]
        public string OrganizationName { get; set; }

        [Required]
        public string ContactPerson { get; set; }

        [Required]
        public string ContactPhoneNumber { get; set; }

        [EmailAddress]
        [Required]
        public string ContactEmailAddress { get; set; }

        public virtual List<Clinic> Clinics { get; }
        
        public void Apply(OrganizationCreated domainEvent)
        {
            OrganizationName = domainEvent.OrganizationName;
            ContactPerson = domainEvent.ContactPerson;
            ContactPhoneNumber = domainEvent.ContactPhoneNumber;
            ContactEmailAddress = domainEvent.ContactEmailAddress;

            foreach (var clinic in domainEvent.Clinics)
            {
                Clinics.Add(new Clinic
                {
                    ClinicName = clinic.ClinicName,
                    Address = new Address
                    {
                        Line1 = clinic.AddressLine1,
                        Line2 = clinic.AddressLine2,
                        Suburb = clinic.Suburb,
                        City = clinic.City,
                        PostCode = clinic.PostCode,
                        PhoneNumber = clinic.PhoneNumber
                    }
                    
                });        
            }
        }

        public void Apply(OrganizationUpdated domainEvent)
        {
            OrganizationName = domainEvent.OrganizationName;
            ContactPerson = domainEvent.ContactPerson;
            ContactPhoneNumber = domainEvent.ContactPhoneNumber;
            ContactEmailAddress = domainEvent.ContactEmailAddress;

            foreach (var clinic in domainEvent.Clinics)
            {
                Clinics.Add(new Clinic
                {
                    ClinicName = clinic.ClinicName,
                    Address = new Address
                    {
                        Line1 = clinic.AddressLine1,
                        Line2 = clinic.AddressLine2,
                        Suburb = clinic.Suburb,
                        City = clinic.City,
                        PostCode = clinic.PostCode,
                        PhoneNumber = clinic.PhoneNumber
                    }

                });
            }
        }

    }
}
