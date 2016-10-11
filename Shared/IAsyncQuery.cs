using System.Collections.Generic;
using MediatR;

namespace Shared
{
    public interface IAsyncQuery<TResponse> : IAsyncRequest<IList<TResponse>>
    {
    }
}