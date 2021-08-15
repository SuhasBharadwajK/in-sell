using System;

namespace InSell.Services.Exceptions
{
    public class DuplicateLeadException : Exception
    {
        public DuplicateLeadException(string message) : base(message)
        {
        }
    }
}
