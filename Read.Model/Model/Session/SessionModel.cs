using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ActiveEdge.Read.Model.Session.Validators;
using Domain;
using Domain.Event.Session;
using Domain.Model;
using FluentValidation.Attributes;
using Shared;

namespace ActiveEdge.Read.Model.Session
{
    [Validator(typeof(SessionModelValidator))]
    public class SessionModel : SessionPlanModel, IAmLinkedToAnOrganization
    {
        public SessionModel()
        {
            ContraIndications = new List<string>();
        }

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

        public List<string> ContraIndications { get; private set; }

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

            AddHistory(domainEvent, "Session Created");
        }

        private void AddHistory(IAmAuditable domainEvent, string description)
        {
            History.Add(new SessionHistory
            {
                Date = domainEvent.CommandDate,
                UserId = domainEvent.UserId,
                UserName = domainEvent.UserName,
                Description = description
            });
        }

        public void Apply(PlanAddedToSession domainEvent)
        {
            ContributingFactorsToCondition = domainEvent.ContributingFactorsToCondition;
            Hypothesis = domainEvent.Hypothesis;
            PreMassagePalpation = domainEvent.PreMassagePalpation;
            SessionPlan = domainEvent.SessionPlan;
            TreatmentNotes = domainEvent.TreatmentNotes;

            AddHistory(domainEvent, "Session Plan Added");
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

            AddHistory(domainEvent, "Session Updated");
        }
    }
}