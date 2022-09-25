using System;
using System.Runtime.Serialization;

[Serializable]
internal class LastEventResultUndefinedException : Exception
{
    public LastEventResultUndefinedException()
    {
    }

    public LastEventResultUndefinedException(string message) : base(message)
    {
    }

    public LastEventResultUndefinedException(string message, Exception innerException) : base(message, innerException)
    {
    }

    protected LastEventResultUndefinedException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}