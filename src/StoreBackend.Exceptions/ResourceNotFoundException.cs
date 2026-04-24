using System;

namespace StoreBackend.Exceptions;

public class ResourceNotFoundException : Exception
{
    public ResourceNotFoundException() : base("User not found")
    {
    }

    public ResourceNotFoundException(string message) : base(message)
    {
    }


}
