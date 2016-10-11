using System;
using MediatR;

namespace Shared
{
    public interface ICommandHandler<in TCommand> : IRequestHandler<TCommand, Guid> where TCommand : IRequest<Guid>
    {
        
    }
}