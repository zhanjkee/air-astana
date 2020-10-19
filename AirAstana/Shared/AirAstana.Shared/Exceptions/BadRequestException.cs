using System;
using System.Runtime.Serialization;

namespace AirAstana.Shared.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException()
        {
        }

        public BadRequestException(string message, string key = "", object @params = null) : base(message)
        {
            Key = key;
            Params = @params;
        }

        public BadRequestException(string message, Exception innerException, string key = "", object @params = null) : base(message, innerException)
        {
            Key = key;
            Params = @params;
        }

        protected BadRequestException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public string Key { get; }
        public object Params { get; }
    }
}
