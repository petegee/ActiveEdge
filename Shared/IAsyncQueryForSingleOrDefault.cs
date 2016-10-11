using MediatR;

namespace Shared
{
    public interface IAsyncQueryForSingleOrDefault<out TResponse> : IAsyncRequest<TResponse>
    {

    }
}