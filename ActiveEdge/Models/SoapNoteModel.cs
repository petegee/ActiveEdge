using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ActiveEdge.Models
{
  public class SoapNoteModel
  {
    public int Id { get; set; }

    [Required]
    [DisplayFormat(DataFormatString = "{0:d/MM/yyyy}")]
    public DateTime Date { get; set; }

    public int ClientId { get; set; }

    [Required]
    [DisplayName("Client Name")]
    public string ClientFullName { get; set; }
    
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
  }
}