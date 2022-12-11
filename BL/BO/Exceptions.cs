using System.Runtime.Serialization;

namespace BO;

public class BlDoesNotExistException : Exception
{
    public BlDoesNotExistException(string? message) : base(message) { }
}

public class BlAlreadyExistsException : Exception
{
    public BlAlreadyExistsException() { }

    public BlAlreadyExistsException(string? message) : base(message) { }

    public BlAlreadyExistsException(string? message, Exception? innerException) : base(message, innerException) { }

    protected BlAlreadyExistsException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}


public class BlInvalidFieldException : Exception
{
    public BlInvalidFieldException(string? message) : base(message) { }
}

public class BlOutOfStockException : Exception
{
    public BlOutOfStockException(string? message) : base(message) { }
}

