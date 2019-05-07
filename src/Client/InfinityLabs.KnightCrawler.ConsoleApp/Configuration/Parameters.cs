using System;
using InfinityLabs.KnightCrawler.ConsoleApp.Configuration.Enums;
using InfinityLabs.KnightCrawler.Library.Configuration;

namespace InfinityLabs.KnightCrawler.ConsoleApp.Configuration
{
    public class Parameters : ICrawlerConfiguration
    {
        public Uri Url { get; set; }

        public int Depth { get; set; }

        public Format OutputFormat { get; set; }
        
        public bool Trace { get; set; }
        
        public string OutputPath { get; internal set; }
    }
}