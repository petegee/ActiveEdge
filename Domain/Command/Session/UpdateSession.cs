﻿using System;
using Shared;

namespace Domain.Command.Session
{
    public class UpdateSession : IAmAuditable, IAsyncCommand
    {
        public Guid Id { get; set; }

        public DateTime? Date { get; set; }

        public Guid ClientId { get; set; }

        public string ClientFullName { get; set; }

        public string Feedback { get; set; }

        public string GoalOrExpectations { get; set; }

        public string AreasOfDiscomfort { get; set; }

        public string ContributingFactorsToCondition { get; set; }

        public string Hypothesis { get; set; }

        public string PreMassagePalpation { get; set; }

        public string SessionPlan { get; set; }

        public string SessionNotesPosition { get; set; }

        public string SessionNotesTechniques { get; set; }

        public string SessionNotesFindings { get; set; }

        public string TreatmentNotes { get; set; }

        public DateTime CommandDate { get; set; }

        public string UserId { get; set; }

        public string UserName { get; set; }
    }
}