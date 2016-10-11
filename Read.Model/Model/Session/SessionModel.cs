using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ActiveEdge.Read.Model.Session.Validators;
using Domain.Event;
using Domain.Model;
using FluentValidation.Attributes;

namespace ActiveEdge.Read.Model.Session
{
    [Validator(typeof(SessionModelValidator))]
    public class SessionModel: IAmLinkedToAnOrganization
    {
        public Guid Id { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime? Date { get; set; }

        public Guid ClientId { get; set; }

        [Required]
        [AdditionalHtml(PlaceHolder = "Search")]
        [DisplayName("Client Name")]
        public string ClientFullName { get; set; }

        [DisplayName("Feedback From Last Session")]
        public string Feedback { get; set; }

        [DisplayName("Goal Or Expectations")]
        public string GoalOrExpectations { get; set; }

        [DisplayName("Areas of Discomfort")]
        public string AreasOfDiscomfort { get; set; }

        [DisplayName("Contributing Factors To Condition")]
        public string ContributingFactorsToCondition { get; set; }

        [DisplayName("Hypothesis")]
        public string Hypothesis { get; set; }

        [DisplayName("Pre-Massage Palpation")]
        public string PreMassagePalpation { get; set; }

        [DisplayName("Session Plan")]
        [UIHint("Summernote")]
        public string SessionPlan { get; set; }

        [DisplayName("Treatment")]
        [UIHint("Summernote")]
        public string TreatmentNotes { get; set; }
        
        public List<string> ContraIndications { get; set; }

        public void Apply(SessionCreated domainEvent)
        {
            OrganizationId = domainEvent.OrganizationId;
            Date = domainEvent.Date;
            ClientId = domainEvent.ClientId;
            Feedback = domainEvent.Feedback;
            GoalOrExpectations = domainEvent.GoalOrExpectations;
            AreasOfDiscomfort = domainEvent.AreasOfDiscomfort;
            ContraIndications = domainEvent.ContraIndications;
        }

        public Guid OrganizationId { get; set; }
    }
}