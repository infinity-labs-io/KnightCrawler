using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using InfinityLabs.KnightCrawler.Library.Exceptions;

namespace InfinityLabs.KnightCrawler.Library.Parsers
{
    public class LinkDiscovery : ILinkDiscovery
    {
        private const string PATTERN = "<a.*?href=\\\"(?<url>[^\"]*)\\\"";
        
        public List<string> GetLinks(string content)
        {
            var regex = new Regex(PATTERN);
            var matches = regex.Matches(content);
            if (matches.Count > 0)
            {
                return matches
                    .Cast<Match>()
                    .Select(m => m.Groups["url"].Value)
                    .ToList();
            }
            // TODO: Throw error
            throw new NoLinksFoundException("No links found in the provided HTML.");
        }
    }
}
