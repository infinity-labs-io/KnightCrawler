using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using InfinityLabs.KnightCrawler.Library.Traversers;
using Newtonsoft.Json;

namespace InfinityLabs.KnightCrawler.Library.NodeWriters
{
    public class JsonNodeWriter : NodeStreamWriterBase
    {
        public JsonNodeWriter(Stream stream) : base(stream)
        {
        }

        protected override string GetStreamContent(ILinkNode node)
        {
            return JsonConvert.SerializeObject(toDictionary(node));
        }

        private Dictionary<string, List<object>> toDictionary(ILinkNode node)
        {
            var dictionary = new Dictionary<string, List<object>>();
            if (node.Children.Count == 0)
            {
                dictionary.Add(node.Link.ToString(), new List<object>());
                return dictionary;
            }
            dictionary.Add(node.Link.ToString(), node.Children
                .Select(c => toDictionary(c))
                .Cast<object>()
                .ToList());
            return dictionary;
        }
    }
}