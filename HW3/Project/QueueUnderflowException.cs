using System;

namespace Project
{
    public class QueueUnderflowException : SystemException
    {
        public QueueUnderflowException() : base()
        {

        }

        public QueueUnderflowException(string message) : base(message)
        {

        }
    }
}
