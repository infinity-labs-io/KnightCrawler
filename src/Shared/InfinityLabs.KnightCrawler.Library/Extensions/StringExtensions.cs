using System.Linq;

namespace InfinityLabs.KnightCrawler.Library.Extensions
{
    public static class StringExtensions
    {
        public static bool StartsWithAny(this string input, params string[] compareTo)
        {
            return compareTo.Any(s => input.StartsWith(s));
        }
    }
}