using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Fclp;
using InfinityLabs.KnightCrawler.ConsoleApp.Configuration;
using InfinityLabs.KnightCrawler.ConsoleApp.Configuration.Enums;
using InfinityLabs.KnightCrawler.Library.Crawlers;
using InfinityLabs.KnightCrawler.Library.NodeWriters;
using InfinityLabs.KnightCrawler.Library.Parsers;
using InfinityLabs.KnightCrawler.Library.Providers;
using InfinityLabs.KnightCrawler.Library.Traversers;

namespace InfinityLabs.KnightCrawler.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var parameters = new Parameters();

            var parser = new FluentCommandLineParser();
            parser.Setup<string>('u', "url")
                .Callback(p => parameters.Url = new Uri(p))
                .Required();

            parser.Setup<int>('d', "depth")
                .Callback(p => parameters.Depth = p)
                .SetDefault(1);

            var folder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            parser.Setup<string>('p', "path")
                .Callback(p => parameters.OutputPath = p)
                .SetDefault(folder);

            parser.Setup<Format>('o', "output")
                .Callback(p => parameters.OutputFormat = p)
                .SetDefault(Format.HTML);

            parser
                .Setup<bool>('t', "trace")
                .Callback(p => parameters.Trace = p)
                .SetDefault(false);

            var result = parser.Parse(args);

            if(!result.HasErrors)
            {
                RunAsync(parameters).Wait(Timeout.Infinite);
            }
            Console.WriteLine(result.ErrorText);

            Console.WriteLine("Done. Press any key to quit.");
            Console.ReadLine();
        }

        static async Task RunAsync(Parameters parameters)
        {
            var contentProvider = new WebHtmlContentProvider(parameters);
            var crawler = new LinkCrawler(parameters, contentProvider, new LinkDiscovery());
            var traverser = new LinkTraverser(crawler); 
            var results = await traverser.Traverse(parameters.Url, parameters.Depth);

            var extension = parameters.OutputFormat == Format.HTML ? ".html" : ".csv";
            var path = Path.Combine(parameters.OutputPath, "results" + extension);
            using (var file = File.Open(path, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None))
            using (var writer = new HtmlNodeWriter(file))
            {
                await writer.WriteAsync(results);
            }
        }
    }
}
