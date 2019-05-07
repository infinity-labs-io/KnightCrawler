using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfinityLabs.KnightCrawler.Library.Traversers;
using static System.Environment;

namespace InfinityLabs.KnightCrawler.Library.NodeWriters
{
    public class HtmlNodeWriter : INodeWriter
    {
        private readonly Stream _stream;

        public HtmlNodeWriter(Stream stream)
        {
            _stream = stream;
        }

        public async Task WriteAsync(ILinkNode node)
        {
            var content = buildList(node);
            var html = buildHtml(content);
            using (var writer = new StreamWriter(_stream))
            {
                await writer.WriteAsync(html);
            }
        }
        private string buildList(ILinkNode node)
        {
            var header = buildRow(node.Link.ToString());
            var hasChildren = node.Children.Count > 0;
            if (hasChildren)
            {
                var children = string.Join("", node.Children
                    .Select(buildList));
                children = buildRow(buildElement("ul", children));
                return header + children;
            }
            return header;
        }

        private string buildHtml(string content)
        {
            return $@"
            <!doctype html>
            <html>
            <head>
            </head>
            <body>
            <ul>
            {content}
            </ul>
            </body>
            </html>
            ";
        }

        private string buildRow(string content)
        {
            return buildElement("li", content);
        }

        private string buildElement(string element, string content)
        {
            return $"<{element}>{content}</{element}>";
        }

        public void Dispose()
        {
            _stream?.Dispose();
        }
    }
}