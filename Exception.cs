using System;

namespace BackendProjekti
{
    public class NotAdminException : Exception
    {
        public NotAdminException(): base()
        {

        }

        public NotAdminException(string message) : base(message)
        {

        }

        public NotAdminException(string message, Exception inner) : base(message, inner)
        {

        }
    
    }

}