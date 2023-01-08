using System.Runtime.Serialization;

namespace BO;

[Serializable]
public class BlDoesNotExistException : Exception
{
    public BlDoesNotExistException() { }

    public BlDoesNotExistException(string? message) : base(message) { }

    public BlDoesNotExistException(string? message, Exception? innerException) : base(message, innerException) { }

    protected BlDoesNotExistException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}

[Serializable]
public class BlAlreadyExistsException : Exception
{
    public BlAlreadyExistsException() { }

    public BlAlreadyExistsException(string? message) : base(message) { }

    public BlAlreadyExistsException(string? message, Exception? innerException) : base(message, innerException) { }

    protected BlAlreadyExistsException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}

[Serializable]
public class BlInvalidFieldException : Exception
{
    public BlInvalidFieldException() { }

    public BlInvalidFieldException(string? message) : base(message) { }

    public BlInvalidFieldException(string? message, Exception? innerException) : base(message, innerException) { }

    protected BlInvalidFieldException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}

[Serializable]
public class BlOutOfStockException : Exception
{
    public BlOutOfStockException() { }

    public BlOutOfStockException(string? message) : base(message) { }

    public BlOutOfStockException(string? message, Exception? innerException) : base(message, innerException) { }

    protected BlOutOfStockException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}

[Serializable]
public class BlFailedException : Exception
{
    public BlFailedException() { }

    public BlFailedException(string? message) : base(message) { }

    public BlFailedException(string? message, Exception? innerException) : base(message, innerException) { }

    protected BlFailedException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}
