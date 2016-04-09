using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ActiveEdge.Models
{
  public class SoapNoteModel
  {
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public int ClientId { get; set; }
    public string ClientName { get; set; }
    public string Feedback { get; set; }
    public string GoalOrExpectations { get; set; }
    public string ContributingFactorsToCondition { get; set; }
    public string PreMassagePalpatation { get; set; }
    public string PressureScaleRequired { get; set; }
    public string SessionPlan { get; set; }
    public List<SessionNoteModel> SessionNotes { get; set; } 
  }

  public class SessionNoteModel
  {
    public int Id { get; set; }
    public string PositionAreaMuscle { get; set; }
    public string Techniques { get; set; }
    public string Findings { get; set; }
  }
}