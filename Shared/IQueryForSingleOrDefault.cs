using MediatR;

namespace Shared
{
    public interface IQueryForSingleOrDefault<out TResponse> : IRequest<TResponse>
    {
        
    }
}