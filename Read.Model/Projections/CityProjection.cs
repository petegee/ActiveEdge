using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ActiveEdge.Read.Model.Search;
using Domain.Event;
using Domain.Event.Organization;
using Marten;
using Marten.Events;
using Marten.Events.Projections;
using Marten.Events.Projections.Async;

namespace ActiveEdge.Read.Projections
{
    public class CityProjection : IProjection
    {
        public CityProjection()
        {
            Consumes = new[]
            {
                typeof(OrganizationCreated),
                typeof(OrganizationUpdated)
            };

            Produces = typeof(City);
        }

        public void Apply(IDocumentSession session, EventStream[] streams)
        {
            foreach (var stream in streams)
                foreach (var @event in stream.Events.Where(x => x.Data is IHaveCities))
                {

                    var organizationCreated = (IHaveCities)@event.Data;

                    foreach (var city in organizationCreated.Cities)
                    {
                        if (
                            !session.Query<City>()
                                .Any(c => c.Name.Equals(city, StringComparison.OrdinalIgnoreCase)))
                        {
                            session.Store(new City { Id = Guid.NewGuid(), Name = city });
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