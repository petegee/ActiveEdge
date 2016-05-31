using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Domain.Model;
using MediatR;

namespace Domain
{
    public interface IQueryHandler<in TQuery, out TDomain> : IRequestHandler<TQuery, IQueryable<TDomain>> where TQuery : IRequest<IQueryable<TDomain>>
    {

    }

    
    public interface ICommand : IRequest
    {
        
    }
    public interface ICommand<out TResponse> : IRequest<TResponse>
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
        void ExecuteCommand(ICommand command);
        void ExecuteCommand(ICommand<int> command);
        IQueryable<TResponse> ExecuteQuery<TResponse>(IQuery<TResponse> query);
        void PublishDomainEvent(IDomainEvent domainEvent);
    }
    public class Bus :IBus
    {
        private readonly IMediator _mediator;

        /// <summary>Initializes a new instance of the <see cref="T:System.Object" /> class.</summary>
        public Bus(IMediator mediator)
        {
            _mediator = mediator;
        }

        public void ExecuteCommand(ICommand command)
        {
            _mediator.Send(command);
        }

        public void ExecuteCommand(ICommand<int> command)
        {
            _mediator.Send(command);
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
