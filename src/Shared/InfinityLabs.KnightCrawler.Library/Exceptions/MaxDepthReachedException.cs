using System;
using System.Runtime.Serialization;

namespace InfinityLabs.KnightCrawler.Library.Exceptions
{
    [Serializable]
    internal class MaxDepthReachedException : Exception
    {
        public MaxDepthReachedException()
        {
        }

        public MaxDepthReachedException(string message) : base(message)
        {
        }

        public MaxDepthReachedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected MaxDepthReachedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}