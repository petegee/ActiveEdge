using System.Collections.Generic;

namespace ActiveEdge.Infrastructure.Extensions
{
    public static class StringExtensions
    {
        public static string ToCommaDelimited(this IEnumerable<string> strings)
        {
            return string.Join(", ", strings);
        }
    }
}