using System.Collections.Generic;

namespace Shared
{
    public interface IBus
    {
        int ExecuteCommand(ICommand command);
        IList<TResponse> ExecuteQuery<TResponse>(IQuery<TResponse> query);
        TResponse ExecuteQuery<TResponse>(IQueryForSingleOrDefault<TResponse> query);
        void PublishDomainEvent(IDomainEvent domainEvent);
    }
}