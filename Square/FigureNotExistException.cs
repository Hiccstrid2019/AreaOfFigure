using System;

namespace Square
{
    public class FigureNotExistException: Exception
    {
        public FigureNotExistException()
        {
            
        }

        public FigureNotExistException(string message) : base(message)
        {
            
        }

        public FigureNotExistException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}