using System;
using System.IO;
using ToDoList.Client;

namespace ToDoList
{
    class Program
    {
        static void Main(string[] args)
        {
            var console = new ConsoleCommands();
            console.Run();
        }
    }
}