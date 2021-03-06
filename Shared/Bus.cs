using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;

namespace Shared
{
    public class Bus : IBus
    {
        private readonly IMediator _mediator;

        /// <summary>Initializes a new instance of the <see cref="T:System.Object" /> class.</summary>
        public Bus(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Guid  ExecuteCommand(ICommand command)
        {
            return _mediator.Send(command);
        }

        public Task<Guid> ExecuteAsyncCommand(IAsyncCommand command)
        {
            return _mediator.SendAsync(command);
        }


        public IList<TResponse> ExecuteQuery<TResponse>(IQuery<TResponse> query)
        {
            return _mediator.Send(query);
        }

        public Task<IList<TResponse>> ExecuteAsyncQuery<TResponse>(IAsyncQuery<TResponse> query)
        {
            return _mediator.SendAsync(query);
        }

        public TResponse ExecuteQuery<TResponse>(IQueryForSingleOrDefault<TResponse> query)
        {
            return _mediator.Send(query);
        }

        public Task<TResponse> ExecuteAsyncQuery<TResponse>(IAsyncQueryForSingleOrDefault<TResponse> query)
        {
            return _mediator.SendAsync(query);
        }

        public void PublishDomainEvent(IDomainEvent domainEvent)
        {
            _mediator.Publish(domainEvent);
        }

        public Task PublishAsyncDomainEvent(IAsyncDomainEvent domainEvent)
        {
            return _mediator.PublishAsync(domainEvent);
        }
    }
}