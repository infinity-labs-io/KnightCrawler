using System;
using System.Runtime.Serialization;

namespace InfinityLabs.KnightCrawler.Library.Exceptions
{
    [Serializable]
    public class NoLinksFoundException : Exception
    {
        public NoLinksFoundException()
        {
        }

        public NoLinksFoundException(string message) : base(message)
        {
        }

        public NoLinksFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NoLinksFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}