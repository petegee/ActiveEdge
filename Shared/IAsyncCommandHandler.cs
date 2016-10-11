using System;
using MediatR;

namespace Shared
{
    public interface IAsyncCommandHandler<in TCommand> : IAsyncRequestHandler<TCommand, Guid> where TCommand : IAsyncCommand
    {

    }
}