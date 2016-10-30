﻿using System;
using Shared;

namespace Domain.Event.User
{
    public class UserCreated : IDomainEvent, IAmAuditable, IAmLinkedToAnOrganization
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsAdministrator { get; set; }
        public DateTime CommandDate { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public Guid OrganizationId { get; set; }
    }
}