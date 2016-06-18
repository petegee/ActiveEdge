using MediatR;

namespace Shared
{
    public interface ICommandHandler<in TCommand> : IRequestHandler<TCommand, int> where TCommand : IRequest<int>
    {
        
    }
}