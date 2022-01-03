using System;
using System.Collections.Generic;
using System.Linq;

namespace ToDoList.Models
{
    public class Task
    {
        public Task(string taskInfo)
        {
            Id = Convert.ToBase64String(Guid.NewGuid().ToByteArray());
            TaskInfo = taskInfo;
            Completed = false;
            CreationTime = DateTime.Today;
        }

        public string Id { get; }
        public string TaskInfo { get;}
        public bool Completed { get; set; }
        public DateTime CreationTime { get; }
        public DateTime DeadLine { get; set; }
        public List<SubTask> SubTasks { get; } = new ();
    }
}