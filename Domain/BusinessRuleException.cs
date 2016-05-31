using System;

namespace Domain
{
    public class BusinessRuleException : ApplicationException
    {
        public BusinessRuleException(string message) : base(message)
        {
        }
    }
}