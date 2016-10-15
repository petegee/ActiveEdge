using System;
using System.Collections.Generic;
using System.Linq;
using ActiveEdge.Read.Model;
using ActiveEdge.Read.Model.Client;
using Domain.Command.Client;
using Domain.Command.Organization;
using Domain.Command.Session;
using Domain.Context;
using Domain.Model;
using Marten;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Shared;
using Clinic = Domain.Command.Organization.Clinic;

namespace ActiveEdge.Infrastructure
{
    public class DatabaseInitializer
    {
        private readonly IBus _bus;
        private readonly IDocumentSession _session;
        private readonly UserManager<ApplicationUser> _userManager;
        private ApplicationUser _adminUser;

        /// <summary>Initializes a new instance of the <see cref="T:System.Object" /> class.</summary>
        public DatabaseInitializer(IDocumentSession session, UserManager<ApplicationUser> userManager, IBus bus)
        {
            _session = session;
            _userManager = userManager;
            _bus = bus;
        }


        public void Seed()
        {
            if (_session.Query<ApplicationUser>().Any(u => u.UserName == "sjclark76@gmail.com"))
                return;

            _session.Store(new IdentityRole {Name = Roles.SystemAdministrator});
            _session.Store(new IdentityRole {Name = Roles.OrganizationAdministrator});
            _session.Store(new IdentityRole {Name = Roles.Therapist});

            _adminUser = new ApplicationUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "sjclark76@gmail.com",
                FirstName = "Stuart",
                LastName = "Clark",
                PhoneNumber = "021509357"
            };

            _userManager.Create(_adminUser, "ridgeback");
            _userManager.AddToRole(_adminUser.Id, Roles.SystemAdministrator);

            AddOrganization();
            AddClients();
            AddSessions();

            AddUsers();

            _session.SaveChanges();
        }

        private void AddOrganization()
        {
            _bus.ExecuteAsyncCommand(new CreateNewOrganization
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
                            AddressLine1 = "24 Johnston Street",
                            AddressLine2 = "Address line2",
                            City = "Wellington",
                            PostCode = "6011",
                            Suburb = "Wellington Central"
                        }
                    }
                })
                .Wait();

            _bus.ExecuteAsyncCommand(new CreateNewOrganization
                {
                    OrganizationName = "Habit",
                    ContactPerson = "Dr Habit",
                    ContactEmailAddress = "Dr@habit.co.nz",
                    ContactPhoneNumber = "01702 712202",
                    Clinics = new List<Clinic>
                    {
                        new Clinic
                        {
                            ClinicName = "Featherston Street"
                        }
                    }
                })
                .Wait();

            _session.SaveChanges();
        }

        private void AddSessions()
        {
            var organization = _session.Query<Organization>().First();
            var client = _session.Query<ClientModel>().First();

            var id = _bus.ExecuteAsyncCommand(new CreateNewSession
            {
                Date = DateTime.Today.Date,
                ClientId = client.Id,
                ClientFullName = client.FullName,
                Feedback = "It was absolutely fantastic",
                GoalOrExpectations = "get fitter & stronger",
                OrganizationId = organization.Id,
                CommandDate = DateTime.Now,
                UserId = _adminUser.Id,
                UserName = _adminUser.UserName
            }).Result;

            _bus.ExecuteAsyncCommand(new AddPlanToSession
            {
                Id = id,
                ContributingFactorsToCondition = "Fell Off a roof",
                Hypothesis = "broken leg",
                PreMassagePalpation = "bone sticking out",
                SessionPlan = "don nothing",
                TreatmentNotes = "I think i made it worse",
                CommandDate = DateTime.Now,
                UserId = _adminUser.Id,
                UserName = _adminUser.UserName
            }).Wait();

            _session.SaveChanges();
        }

        private void AddClients()
        {
            var organization = _session.Query<Organization>().First();

            _bus.ExecuteAsyncCommand(new RegisterNewClient
            {
                OrganizationId = organization.Id,
                FirstName = "Stuart",
                LastName = "Clark",
                DateOfBirth = new DateTime(1976, 6, 10),
                AddressLine1 = "12 Wattle Grove",
                Suburb = "Maungaraki",
                City = "Lower Hutt",
                ContactNumber = "021509357",
                Email = "sjclark76@gmail.com",
                ExcerciseFrequency = ExcerciseFrequency.FiveTimesAWeek,
                Gender = Gender.Male
            }).Wait();

            _bus.ExecuteAsyncCommand(new RegisterNewClient
            {
                OrganizationId = organization.Id,
                FirstName = "Joanne",
                LastName = "Clark",
                DateOfBirth = new DateTime(1979, 5, 23),
                AddressLine1 = "12 Wattle Grove",
                Suburb = "Maungaraki",
                City = "Lower Hutt",
                ContactNumber = "021509357",
                Email = "joclark@gmail.com",
                ExcerciseFrequency = ExcerciseFrequency.FiveTimesAWeek,
                Gender = Gender.Female
            }).Wait();

            _bus.ExecuteAsyncCommand(new RegisterNewClient
            {
                OrganizationId = organization.Id,
                FirstName = "Zoe",
                LastName = "Clark",
                DateOfBirth = new DateTime(2013, 5, 23),
                AddressLine1 = "12 Wattle Grove",
                Suburb = "Maungaraki",
                City = "Lower Hutt",
                ContactNumber = "021509357",
                Email = "zclark@gmail.com",
                ExcerciseFrequency = ExcerciseFrequency.Never,
                Gender = Gender.Female
            }).Wait();


            _bus.ExecuteAsyncCommand(new RegisterNewClient
            {
                OrganizationId = organization.Id,
                FirstName = "Jessiah",
                LastName = "Clark",
                DateOfBirth = new DateTime(2012, 1, 13),
                AddressLine1 = "12 Wattle Grove",
                Suburb = "Maungaraki",
                City = "Lower Hutt",
                ContactNumber = "021509357",
                Email = "jesseclark@gmail.com",
                ExcerciseFrequency = ExcerciseFrequency.Never,
                Gender = Gender.Female
            }).Wait();
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