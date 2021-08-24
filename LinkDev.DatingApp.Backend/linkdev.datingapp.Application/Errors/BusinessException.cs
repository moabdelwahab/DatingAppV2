using System;

namespace LinkDev.DatingApp.Application.Errors
{
    public class BusinessException : Exception
    {
        public BusinessException(string message) : base(message)
        {
        }
    }
}