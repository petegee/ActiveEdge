using System.Linq;
using MediatR;

namespace Domain
{
    public class Bus : IBus
    {
        private readonly IMediator _mediator;

        /// <summary>Initializes a new instance of the <see cref="T:System.Object" /> class.</summary>
        public Bus(IMediator mediator)
        {
            _mediator = mediator;
        }

        public int ExecuteCommand(ICommand command)
        {
            return  _mediator.Send(command);
        }


        public IQueryable<TResponse> ExecuteQuery<TResponse>(IQuery<TResponse> query)
        {
            return _mediator.Send(query);
        }

        public TResponse ExecuteQuery<TResponse>(IQueryForSingleOrDefault<TResponse> query)
        {
            return _mediator.Send(query);
        }

        public void PublishDomainEvent(IDomainEvent domainEvent)
        {
            _mediator.Publish(domainEvent);
        }
    }
}