using System;
using Marten.Schema;

namespace ActiveEdge.Read.Model.Search
{
    public class City
    {
        public Guid Id { get; set; }

        [DuplicateField]
        public string Name { get; set; }
    }
}