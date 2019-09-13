using System;

namespace TechnicalRadiation.Models.Exceptions
{
    public class ResourceNotFoundException : Exception
    {
        public ResourceNotFoundException() : base("The resource was not found.") {}
        public ResourceNotFoundException(string message) : base(message) {}
    }
}