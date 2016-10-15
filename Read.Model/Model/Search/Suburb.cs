using System;
using Marten.Schema;

namespace ActiveEdge.Read.Model.Search
{
    public class Suburb
    {
        public Guid Id { get; set; }

        [DuplicateField]
        public string Name { get; set; }
    }
}