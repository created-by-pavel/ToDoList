using System;
using System.IO;
using ToDoList.Client;
using ToDoList.Services;

namespace ToDoList
{
    class Program
    {
        static void Main(string[] args)
        {
            IToDoListService service = new ToDoListService();
            var drawing = new Drawing();
            var console = new ConsoleCommands(service, drawing);
            console.Run();
        }
    }
}