using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
  public class SoapNote
  {
    public int Id { get; set; }

    public DateTime Date { get; set; }

    public int ClientId { get; set; }

    public Client Client { get; set; }

    public string Feedback { get; set; }

    public string GoalOrExpectations { get; set; }

    public string ContributingFactorsToCondition { get; set; }

    public string PreMassagePalpatation { get; set; }

    public string PressureScaleRequired { get; set; }

    public string SessionPlan { get; set; }

    public string SessionNotesPosition { get; set; }

    public string SessionNotesTechniques { get; set; }

    public string SessionNotesFindings { get; set; }
  }
}
