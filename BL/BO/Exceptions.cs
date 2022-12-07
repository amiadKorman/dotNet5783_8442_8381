﻿namespace BO;

public class BlDoesNotExistException : Exception
{
    public BlDoesNotExistException(string? message) : base(message) { }
}

public class BlAlreadyExistsException : Exception
{
    public BlAlreadyExistsException(string? message) : base(message) { }
}

public class BlInvalidFieldException : Exception
{
    public BlInvalidFieldException(string? message) : base(message) { }
}
