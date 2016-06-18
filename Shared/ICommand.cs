using MediatR;

namespace Shared
{
    public interface ICommand : IRequest<int>
    {
    }
}