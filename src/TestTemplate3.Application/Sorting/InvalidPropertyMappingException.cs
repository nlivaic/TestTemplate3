using System;

namespace TestTemplate3.Application.Sorting
{
    public class InvalidPropertyMappingException : Exception
    {
        public InvalidPropertyMappingException(string message)
            : base(message)
        {
        }
    }
}
