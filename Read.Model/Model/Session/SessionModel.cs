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
    public class SessionModel : SessionPlanModel, IAmLinkedToAnOrganization
    {
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

        public List<string> ContraIndications { get; set; }

        public Guid OrganizationId { get; set; }

        public void Apply(SessionCreated domainEvent)
        {
            OrganizationId = domainEvent.OrganizationId;
            Date = domainEvent.Date;
            ClientId = domainEvent.ClientId;
            ClientFullName = domainEvent.ClientFullName;
            Feedback = domainEvent.Feedback;
            GoalOrExpectations = domainEvent.GoalOrExpectations;
            AreasOfDiscomfort = domainEvent.AreasOfDiscomfort;
            ContraIndications = domainEvent.ContraIndications;
        }

        public void Apply(PlanAddedToSession domainEvent)
        {
            ContributingFactorsToCondition = domainEvent.ContributingFactorsToCondition;
            Hypothesis = domainEvent.Hypothesis;
            PreMassagePalpation = domainEvent.PreMassagePalpation;
            SessionPlan = domainEvent.PreMassagePalpation;
            TreatmentNotes = domainEvent.TreatmentNotes;
        }

        public void Apply(SessionUpdated domainEvent)
        {

            Date = domainEvent.Date;
            ClientId = domainEvent.ClientId;
            ClientFullName = domainEvent.ClientFullName;
            Feedback = domainEvent.Feedback;
            GoalOrExpectations = domainEvent.GoalOrExpectations;
            AreasOfDiscomfort = domainEvent.AreasOfDiscomfort;
            ContraIndications = domainEvent.ContraIndications;
            ContributingFactorsToCondition = domainEvent.ContributingFactorsToCondition;
            Hypothesis = domainEvent.Hypothesis;
            PreMassagePalpation = domainEvent.PreMassagePalpation;
            SessionPlan = domainEvent.PreMassagePalpation;
            TreatmentNotes = domainEvent.TreatmentNotes;
        }
    }
}