using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shared
{
    public interface IBus
    {
        Guid ExecuteCommand(ICommand command);

        Task<Guid> ExecuteAsyncCommand(IAsyncCommand command);
        
        IList<TResponse> ExecuteQuery<TResponse>(IQuery<TResponse> query);

        Task<IList<TResponse>> ExecuteAsyncQuery<TResponse>(IAsyncQuery<TResponse> query);

        TResponse ExecuteQuery<TResponse>(IQueryForSingleOrDefault<TResponse> query);

        Task<TResponse> ExecuteAsyncQuery<TResponse>(IAsyncQueryForSingleOrDefault<TResponse> query);

        void PublishDomainEvent(IDomainEvent domainEvent);

        Task PublishAsyncDomainEvent(IAsyncDomainEvent domainEvent);
    }
}