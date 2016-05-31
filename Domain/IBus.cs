using System.Linq;
using MediatR;

namespace Domain
{
    public interface ICommandHandler<in TCommand> : IRequestHandler<TCommand, int> where TCommand : IRequest<int>
    {
        
    }
    

    public interface IQueryHandler<in TQuery, out TDomain> : IRequestHandler<TQuery, IQueryable<TDomain>>
        where TQuery : IRequest<IQueryable<TDomain>>
    {
    }


    public interface ICommand : IRequest<int>
    {
    }

    public interface IQuery<out TResponse> : IRequest<IQueryable<TResponse>>
    {
    }

    public interface IDomainEvent : INotification
    {
    }

    public interface IBus
    {
        int ExecuteCommand(ICommand command);
        IQueryable<TResponse> ExecuteQuery<TResponse>(IQuery<TResponse> query);
        void PublishDomainEvent(IDomainEvent domainEvent);
    }

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

        public void PublishDomainEvent(IDomainEvent domainEvent)
        {
            _mediator.Publish(domainEvent);
        }
    }
}