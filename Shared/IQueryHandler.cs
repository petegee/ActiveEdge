using System.Collections.Generic;
using MediatR;

namespace Shared
{
    public interface IQueryHandler<in TQuery, TDomain> : IRequestHandler<TQuery, IList<TDomain>>
        where TQuery : IRequest<IList<TDomain>>
    {
    }
}