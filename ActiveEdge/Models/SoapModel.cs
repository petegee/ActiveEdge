using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ActiveEdge.Models
{
  public class SoapNoteModel
  {
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public int ClientId { get; set; }

    [DisplayName("Client Name")]
    public string ClientName { get; set; }

    [DisplayName("Feedback From Last Session")]
    public string Feedback { get; set; }

    [DisplayName("Goal Or Expectations")]
    public string GoalOrExpectations { get; set; }

    [DisplayName("Contributing Factors To Condition")]
    public string ContributingFactorsToCondition { get; set; }

    [DisplayName("Pre-Massage Palpatation")]
    public string PreMassagePalpatation { get; set; }

    [DisplayName("Pressure Scale Required")]
    public string PressureScaleRequired { get; set; }

    [DisplayName("Session Plan")]
    [UIHint("Summernote")]
    public string SessionPlan { get; set; }

    [DisplayName("Position / area/ muscle")]
    [UIHint("Summernote")]
    public string SessionNotesPosition { get; set; }

    [DisplayName("Techniques")]
    [UIHint("Summernote")]
    public string SessionNotesTechniques { get; set; }

    [DisplayName("Findings")]
    [UIHint("Summernote")]
    public string SessionNotesFindings { get; set; }


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