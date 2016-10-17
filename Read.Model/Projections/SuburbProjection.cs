using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ActiveEdge.Read.Model.Search;
using Domain.Event.Organization;
using Marten;
using Marten.Events;
using Marten.Events.Projections;
using Marten.Events.Projections.Async;

namespace ActiveEdge.Read.Projections
{
    public class SuburbProjection : IProjection
    {
        public SuburbProjection()
        {
            Consumes = new[]
            {
                typeof(OrganizationCreated),
                typeof(OrganizationUpdated)
            };

            Produces = typeof(Suburb);
        }

        public void Apply(IDocumentSession session, EventStream[] streams)
        {
            foreach (var stream in streams)
                foreach (var @event in stream.Events.Where(x => x.Data is IOrganization))
                {
                   
                        IOrganization organizationCreated = (IOrganization)@event.Data;

                        foreach (var clinic in organizationCreated.Clinics)
                        {
                            if (
                                !session.Query<Suburb>()
                                    .Any(suburb => suburb.Name.Equals(clinic.Suburb, StringComparison.OrdinalIgnoreCase)))
                            {
                                session.Store(new Suburb { Id = Guid.NewGuid(), Name = clinic.Suburb });
                            }
                        }
                    
                   
                }
        }

        public Task ApplyAsync(IDocumentSession session, EventStream[] streams, CancellationToken token)
        {
            Apply(session, streams);

            return Task.CompletedTask;
        }

        public Type[] Consumes { get; }
        public Type Produces { get; }
        public AsyncOptions AsyncOptions { get; } = new AsyncOptions();
    }
}