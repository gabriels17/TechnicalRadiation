using System;

namespace TechnicalRadiation.Models.Exceptions
{
    public class ModelFormatException : Exception
    {
        public ModelFormatException() : base("The model is not properly formatted.") {}
        public ModelFormatException(string message) : base(message) {}
    }
}