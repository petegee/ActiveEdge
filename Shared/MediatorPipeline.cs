using System;
using System.Threading.Tasks;
using MediatR;

namespace Shared
{
    public class MediatorPipeline<TRequest, TResponse>
        : IAsyncRequestHandler<TRequest, TResponse>
        where TRequest : IAsyncRequest<TResponse>
    {
        private readonly IAsyncRequestHandler<TRequest, TResponse> _inner;
        private readonly ILoggedOnUser _loggedOnUser;

        public MediatorPipeline(IAsyncRequestHandler<TRequest, TResponse> inner, ILoggedOnUser loggedOnUser)
        {
            _inner = inner;
            _loggedOnUser = loggedOnUser;
        }

        public Task<TResponse> Handle(TRequest message)
        {
            var auditableCommand = message as IAmAuditable;

            if (auditableCommand != null)
            {
                auditableCommand.CommandDate = DateTime.Now;
                auditableCommand.UserId = _loggedOnUser.Id;
                auditableCommand.UserName = _loggedOnUser.UserName;
            }

           var result = _inner.Handle(message);

            return result;
        }
    }
}