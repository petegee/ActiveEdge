using System;

namespace Shared
{
    public interface IAmAuditable
    {
        DateTime CommandDate { get; set; }

        string UserId { get; set; }

        string UserName { get; set; }
    }
}