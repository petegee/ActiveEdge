using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    public class BusinessRuleException : Exception
    {
        public BusinessRuleException(IEnumerable<string> messages)
        {
            Errors = messages.ToArray();
        }

        public BusinessRuleException(string message) : base(message)
        {
            Errors = new[] {message};
        }

        public string[] Errors { get; private set; }
    }
}