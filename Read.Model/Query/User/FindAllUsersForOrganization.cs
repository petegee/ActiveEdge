﻿using Domain.Model;
using Shared;

namespace ActiveEdge.Read.Query.User
{
    public class FindAllUsersForOrganization : IQuery<ApplicationUser>
    {
        /// <summary>Initializes a new instance of the <see cref="T:System.Object" /> class.</summary>
        public FindAllUsersForOrganization(int organizationId)
        {
            OrganizationId = organizationId;
        }

        public int OrganizationId { get; set; }
    }
}