using System;

namespace BackendProjekti
{
    public class LevelRequirementException : Exception
    {
        public LevelRequirementException(): base()
        {

        }

        public LevelRequirementException(string message) : base(message)
        {

        }

        public LevelRequirementException(string message, Exception inner) : base(message, inner)
        {

        }
    
    }

}