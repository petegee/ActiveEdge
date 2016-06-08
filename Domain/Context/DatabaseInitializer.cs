using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Domain.Model;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Domain.Context
{
    public class Roles
    {
        public const string SystemAdministrator = "SystemAdministrator";
        public const string OrganizationAdministrator = "OrganizationAdministrator";
        public const string Therapist = "Therapist";
    }

    public class DatabaseInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        /// <summary>
        ///     A method that should be overridden to actually add data to the context for seeding.
        ///     The default implementation does nothing.
        /// </summary>
        /// <param name="context">The context to seed. </param>
        protected override void Seed(ApplicationDbContext context)
        {
            var orgAdmin = new IdentityRole {Name = Roles.SystemAdministrator};
            context.Roles.Add(new IdentityRole { Name = Roles.OrganizationAdministrator });
            context.Roles.Add(orgAdmin);
            context.Roles.Add(new IdentityRole { Name = Roles.Therapist });

            if (!context.Users.Any(u => u.UserName == "sjclark76@gmail.com"))
            {
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                var userToInsert = new ApplicationUser {UserName = "sjclark76@gmail.com", PhoneNumber = "021509357"};

                userManager.Create(userToInsert, "ridgeback");
                userManager.AddToRole(userToInsert.Id, Roles.SystemAdministrator);
            }

            AddOrganization(context);
            AddClients(context);
            AddSessions(context);
        }

        private void AddOrganization(ApplicationDbContext context)
        {

            context.Organizations.Add(new Organization
            {
                OrganizationName = "Capital Sports",
                ContactPerson = "Dr Zeuss",
                ContactEmailAddress = "Dr@capitalsports.com",
                ContactPhoneNumber = "01702 712202",
                Clinics = new List<Clinic> { new Clinic { ClinicName = "Lambton Quay"} }
            });

            context.SaveChanges();
        }

        private static void AddSessions(ApplicationDbContext context)
        {
            var organization = context.Organizations.First();


            context.Sessions.Add(new Session
            {
                Date = DateTime.Today.Date,
                ClientId = 1,
                Feedback = "It was absolutely fantastic",
                GoalOrExpectations = "get fitter & stronger",
                ContributingFactorsToCondition = "training like a beast",
                SessionPlan = "Go hard or go home",
                SessionNotesFindings = "this guy is beast",
                SessionNotesPosition = "&lt;p&gt;everything&amp;nbsp;&amp;nbsp;&amp;nbsp;&amp;nbsp;&lt;/p&gt;",
                SessionNotesTechniques = "everywhere",
                PreMassagePalpatation = "nope",
                OrganizationId = organization.Id
            });
        }

        private static void AddClients(ApplicationDbContext context)
        {
            var organization = context.Organizations.First();

            context.Clients.Add(new Client
            {
                FirstName = "Stuart",
                LastName = "Clark",
                DateOfBirth = new DateTime(1976, 6, 10),
                AddressLine1 = "12 Wattle Grove",
                Suburb = "Maungaraki",
                City = "Lower Hutt",
                ContactNumber = "021509357",
                Email = "sjclark76@gmail.com",
                ExcerciseFrequency = ExcerciseFrequency.FiveTimesAWeek,
                Gender = Gender.Male,
                ContraIndications = new ContraIndications(),
                TermsAndConditions = new TermsAndConditions(),
                OrganizationId = organization.Id
            });

            context.Clients.Add(new Client
            {
                FirstName = "Joanne",
                LastName = "Clark",
                DateOfBirth = new DateTime(1979, 5, 23),
                AddressLine1 = "12 Wattle Grove",
                Suburb = "Maungaraki",
                City = "Lower Hutt",
                ContactNumber = "022409357",
                Email = "joclark@gmail.com",
                ExcerciseFrequency = ExcerciseFrequency.FiveTimesAWeek,
                Gender = Gender.Female,
                ContraIndications = new ContraIndications(),
                TermsAndConditions = new TermsAndConditions(),
                OrganizationId = organization.Id
            });

            context.Clients.Add(new Client
            {
                FirstName = "Zoe",
                LastName = "Clark",
                DateOfBirth = new DateTime(2013, 9, 22),
                AddressLine1 = "12 Wattle Grove",
                Suburb = "Maungaraki",
                City = "Lower Hutt",
                ContactNumber = "022409357",
                Email = "zclark@gmail.com",
                ExcerciseFrequency = ExcerciseFrequency.Never,
                Gender = Gender.Female,
                ContraIndications = new ContraIndications(),
                TermsAndConditions = new TermsAndConditions(),
                OrganizationId = organization.Id
            });

            context.Clients.Add(new Client
            {
                FirstName = "Jessiah",
                LastName = "Clark",
                DateOfBirth = new DateTime(2012, 1, 13),
                AddressLine1 = "12 Wattle Grove",
                Suburb = "Maungaraki",
                City = "Lower Hutt",
                ContactNumber = "022409357",
                Email = "jesseclark@gmail.com",
                ExcerciseFrequency = ExcerciseFrequency.FiveTimesAWeek,
                Gender = Gender.Female,
                ContraIndications = new ContraIndications(),
                TermsAndConditions = new TermsAndConditions(),
                OrganizationId = organization.Id
            });
        }
    }
}