using System.Runtime.Serialization;

namespace DO;

[Serializable]
public class DalDoesNotExistException : Exception
{
    public DalDoesNotExistException() { }

    public DalDoesNotExistException(string? message) : base(message) { }

    public DalDoesNotExistException(string? message, Exception? innerException) : base(message, innerException) { }

    protected DalDoesNotExistException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}

[Serializable]
public class DalAlreadyExistsException : Exception
{
    public DalAlreadyExistsException() { }

    public DalAlreadyExistsException(string? message) : base(message) { }

    public DalAlreadyExistsException(string? message, Exception? innerException) : base(message, innerException) { }

    protected DalAlreadyExistsException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}

[Serializable]
public class DalConfigException : Exception
{
    public DalConfigException(string msg) : base(msg) { }
    public DalConfigException(string msg, Exception ex) : base(msg, ex) { }
}
