using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ActiveEdge.Read.Model.Client;
using Domain.Event.Session;
using Marten;
using Marten.Events;
using Marten.Events.Projections;
using Marten.Events.Projections.Async;

namespace ActiveEdge.Read.Projections
{
    public class SessionCountProjection : IProjection
    {
        public SessionCountProjection()
        {

            Consumes = new[]
            {
                typeof(SessionCreated)
            };

            Produces = typeof(ClientModel);
        }

        public void Apply(IDocumentSession session, EventStream[] streams)
        {
            foreach (var stream in streams)
                foreach (var @event in stream.Events.OfType<Event<SessionCreated>>())
                {
                    var sessionCreated = @event.Data;

                    var clientModel = session.Load<ClientModel>(sessionCreated.ClientId);

                    clientModel.Apply(sessionCreated);
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