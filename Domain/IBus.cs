using System.Linq;
using MediatR;

namespace Domain
{
    public interface ICommandHandler<in TCommand> : IRequestHandler<TCommand, int> where TCommand : IRequest<int>
    {
        
    }

    public interface IQueryForSingleHandler<in TQuery, out TDomain> : IRequestHandler<TQuery, TDomain>
        where TQuery : IRequest<TDomain>
    {
    }

    public interface IQueryHandler<in TQuery, out TDomain> : IRequestHandler<TQuery, IQueryable<TDomain>>
        where TQuery : IRequest<IQueryable<TDomain>>
    {
    }


    public interface ICommand : IRequest<int>
    {
    }

    public interface IQueryForSingleOrDefault<out TResponse> : IRequest<TResponse>
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
        TResponse ExecuteQuery<TResponse>(IQueryForSingleOrDefault<TResponse> query);
        void PublishDomainEvent(IDomainEvent domainEvent);
    }
}