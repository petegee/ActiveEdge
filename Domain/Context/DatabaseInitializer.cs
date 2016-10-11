using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Model;
using Marten;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Domain.Context
{
    public class DatabaseInitializer
    {
        private readonly IDocumentSession _session;
        private readonly UserManager<ApplicationUser> _userManager;

        /// <summary>Initializes a new instance of the <see cref="T:System.Object" /> class.</summary>
        public DatabaseInitializer(IDocumentSession session, UserManager<ApplicationUser> userManager)
        {
            _session = session;
            _userManager = userManager;
        }


        public void Seed()
        {
            if (_session.Query<ApplicationUser>().Any(u => u.UserName == "sjclark76@gmail.com"))
                return;

            _session.Store(new IdentityRole {Name = Roles.SystemAdministrator});
            _session.Store(new IdentityRole {Name = Roles.OrganizationAdministrator});
            _session.Store(new IdentityRole {Name = Roles.Therapist});

            var userToInsert = new ApplicationUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "sjclark76@gmail.com",
                PhoneNumber = "021509357"
            };

            _userManager.Create(userToInsert, "ridgeback");
            _userManager.AddToRole(userToInsert.Id, Roles.SystemAdministrator);

            AddOrganization();
            AddClients();
            AddSessions();

            AddUsers();

            _session.SaveChanges();
        }

        private void AddOrganization()
        {
            _session.Store(new Organization
            {
                OrganizationName = "Capital Sports",
                ContactPerson = "Dr Zeuss",
                ContactEmailAddress = "Dr@capitalsports.com",
                ContactPhoneNumber = "01702 712202",
                Clinics = new List<Clinic>
                {
                    new Clinic
                    {
                        ClinicName = "Lambton Quay",
                        Address = new Address
                        {
                            Line1 = "24 Johnston Street",
                            Line2 = "Address line2",
                            City = "Wellington",
                            PostCode = "6011",
                            Suburb = "Wellington Central"
                        }
                    }
                }
            });

            _session.Store(new Organization
            {
                OrganizationName = "Habit",
                ContactPerson = "Dr Habit",
                ContactEmailAddress = "Dr@habit.co.nz",
                ContactPhoneNumber = "01702 712207",
                Clinics = new List<Clinic> {new Clinic {ClinicName = "Featherston Street"}}
            });

            _session.SaveChanges();
        }

        private void AddSessions()
        {
            var organization = _session.Query<Organization>().First();
            var user = _session.Query<Client>().First();

            _session.Store(new Session
            {
                Date = DateTime.Today.Date,
                ClientId = user.Id,
                ClientFullName = user.FullName,
                Feedback = "It was absolutely fantastic",
                GoalOrExpectations = "get fitter & stronger",
                ContributingFactorsToCondition = "training like a beast",
                SessionPlan = "Go hard or go home",
                PreMassagePalpatation = "nope",
                OrganizationId = organization.Id
            });

            _session.SaveChanges();
        }

        private void AddClients()
        {
            var organization = _session.Query<Organization>().First();

            _session.Store(new Client
            {
                FirstName = "Stuart",
                LastName = "Clark",
                DateOfBirth = new DateTime(1976, 6, 10),
                Address = new Address
                {
                    Line1 = "12 Wattle Grove",
                    Suburb = "Maungaraki",
                    City = "Lower Hutt"
                } ,
                
                ContactNumber = "021509357",
                Email = "sjclark76@gmail.com",
                ExcerciseFrequency = ExcerciseFrequency.FiveTimesAWeek,
                Gender = Gender.Male,
                ContraIndications = new ContraIndications(),
                TermsAndConditions = new TermsAndConditions(),
                OrganizationId = organization.Id
            });

            _session.Store(new Client
            {
                FirstName = "Joanne",
                LastName = "Clark",
                DateOfBirth = new DateTime(1979, 5, 23),
                Address = new Address
                {
                    Line1 = "12 Wattle Grove",
                    Suburb = "Maungaraki",
                    City = "Lower Hutt"
                },
                ContactNumber = "022409357",
                Email = "joclark@gmail.com",
                ExcerciseFrequency = ExcerciseFrequency.FiveTimesAWeek,
                Gender = Gender.Female,
                ContraIndications = new ContraIndications(),
                TermsAndConditions = new TermsAndConditions(),
                OrganizationId = organization.Id
            });

            _session.Store(new Client
            {
                FirstName = "Zoe",
                LastName = "Clark",
                DateOfBirth = new DateTime(2013, 9, 22),
                Address = new Address
                {
                    Line1 = "12 Wattle Grove",
                    Suburb = "Maungaraki",
                    City = "Lower Hutt"
                },
                ContactNumber = "022409357",
                Email = "zclark@gmail.com",
                ExcerciseFrequency = ExcerciseFrequency.Never,
                Gender = Gender.Female,
                ContraIndications = new ContraIndications(),
                TermsAndConditions = new TermsAndConditions(),
                OrganizationId = organization.Id
            });

            _session.Store(new Client
            {
                FirstName = "Jessiah",
                LastName = "Clark",
                DateOfBirth = new DateTime(2012, 1, 13),
                Address = new Address
                {
                    Line1 = "12 Wattle Grove",
                    Suburb = "Maungaraki",
                    City = "Lower Hutt"
                },
                ContactNumber = "022409357",
                Email = "jesseclark@gmail.com",
                ExcerciseFrequency = ExcerciseFrequency.FiveTimesAWeek,
                Gender = Gender.Female,
                ContraIndications = new ContraIndications(),
                TermsAndConditions = new TermsAndConditions(),
                OrganizationId = organization.Id
            });

            _session.SaveChanges();
        }

        private void AddUsers()
        {
            var organiation = _session.Query<Organization>().First();

            Action<string, string> createUser = (userName, role) =>
            {
                if (!_session.Query<ApplicationUser>().Any(u => u.UserName == userName))
                {
                    var userToInsert = new ApplicationUser
                    {
                        UserName = userName,
                        PhoneNumber = "021509317",
                        OrganizationId = organiation.Id
                    };

                    _userManager.Create(userToInsert, "ridgeback");
                    _userManager.AddToRole(userToInsert.Id, role);
                }
            };

            createUser("therapist@capital.co.nz", Roles.Therapist);
            createUser("orgadmin@capital.co.nz", Roles.OrganizationAdministrator);
        }
    }
}