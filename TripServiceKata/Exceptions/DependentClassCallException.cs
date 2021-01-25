using System;
using System.Runtime.Serialization;

namespace TripServiceKata.Exceptions
{
    [Serializable]
    public class DependentClassCallException : System.Exception
    {
        public DependentClassCallException() : base() { }

        public DependentClassCallException(string message, System.Exception innerException) : base(message, innerException) { }

        public DependentClassCallException(string message) : base(message) { }

        private DependentClassCallException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
