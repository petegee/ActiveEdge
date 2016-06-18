using MediatR;

namespace Shared
{
    public interface IQueryForSingleHandler<in TQuery, out TDomain> : IRequestHandler<TQuery, TDomain>
        where TQuery : IRequest<TDomain>
    {
    }
}