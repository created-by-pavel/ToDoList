using System;
using System.Globalization;

namespace ToDoList.Tools
{
    public class ToDoListException : Exception
    {
        public ToDoListException()
        {
        }

        public ToDoListException(string message)
            : base(message)
        {
        }

        public ToDoListException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}