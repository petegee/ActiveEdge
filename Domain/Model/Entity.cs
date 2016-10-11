using System;

namespace Domain.Model
{
    public abstract class Entity
    {
        public Guid Id { get; set; }
    }
}