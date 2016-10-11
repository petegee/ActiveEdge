using System;
using MediatR;

namespace Shared
{
    public interface ICommand : IRequest<Guid>
    {
    }
}