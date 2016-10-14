using System;

namespace Domain
{
    public interface IAmAuditable
    {
        DateTime CommandDate { get; set; }

        string UserId { get; set; }

        string UserName { get; set; }
    }
}