using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InfinityLabs.KnightCrawler.Library.Parsers
{
    public interface ILinkDiscovery
    {
        List<string> GetLinks(string content);
    }
}
