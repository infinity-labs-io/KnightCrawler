using System;
using InfinityLabs.KnightCrawler.ConsoleApp.Configuration.Enums;

namespace InfinityLabs.KnightCrawler.ConsoleApp.Configuration
{
    public class Parameters
    {
        public Uri Url { get; set; }

        public int Depth { get; set; }

        public Format OutputFormat { get; set; }
    }
}