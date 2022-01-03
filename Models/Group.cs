using System;
using System.Collections.Generic;

namespace ToDoList.Models
{
    public class Group
    {
        public Group(string name)
        {
            Name = name;
        }

        public string Name { get; }
        public List<Task> Tasks { get; } = new ();
    }
}