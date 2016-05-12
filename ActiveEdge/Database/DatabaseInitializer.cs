using System;
using System.Data.Entity;
using Domain;
using Domain.Model;

namespace ActiveEdge.Database
{
  public class DatabaseInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
  {
    /// <summary>
    ///   A method that should be overridden to actually add data to the context for seeding.
    ///   The default implementation does nothing.
    /// </summary>
    /// <param name="context">The context to seed. </param>
    protected override void Seed(ApplicationDbContext context)
    {
      AddClients(context);
      AddSessions(context);
    }

    private static void AddSessions(ApplicationDbContext context)
    {
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
      });
    }

    private static void AddClients(ApplicationDbContext context)
    {
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
        TermsAndConditions = new TermsAndConditions()
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
        TermsAndConditions = new TermsAndConditions()
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
        TermsAndConditions = new TermsAndConditions()
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
        TermsAndConditions = new TermsAndConditions()
      });
    }
  }
}