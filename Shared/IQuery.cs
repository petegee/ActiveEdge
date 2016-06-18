using System.Collections.Generic;
using MediatR;

namespace Shared
{
    public interface IQuery<TResponse> : IRequest<IList<TResponse>>
    {
    }
}