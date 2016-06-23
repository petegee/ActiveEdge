using System.Threading;
using FluentValidation;

namespace ActiveEdge.Read.Model.Session.Validators
{
    public class SessionModelValidator : AbstractValidator<SessionModel>
    {
        public SessionModelValidator()
        {
            RuleFor(model => model.ClientFullName).Must(HaveAValidClient).WithMessage("Invalid Client");
        }

        private static bool HaveAValidClient(SessionModel session, string arg2)
        {
            return session.ClientId > 0;
        }
    }
}