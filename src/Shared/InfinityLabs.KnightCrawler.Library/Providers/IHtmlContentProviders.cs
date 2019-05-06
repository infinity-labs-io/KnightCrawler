using System;
using System.Threading.Tasks;

namespace InfinityLabs.KnightCrawler.Library.Providers
{
    public interface IHtmlContentProvider
    {
        Task<string> GetHtmlContentAsync(Uri url);
    }
}