using System;

namespace BackendProjekti
{
    public class NoKeyException : Exception
    {
        public NoKeyException(): base()
        {

        }

        public NoKeyException(string message) : base(message)
        {

        }

        public NoKeyException(string message, Exception inner) : base(message, inner)
        {

        }
    
    }

}