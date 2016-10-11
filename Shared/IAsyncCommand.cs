using System;
using MediatR;

namespace Shared
{
    public interface IAsyncCommand : IAsyncRequest<Guid>
    {
        
    }
}