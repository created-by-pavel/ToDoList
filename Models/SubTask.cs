using System;
using System.Collections.Generic;

namespace ToDoList.Models
{
    public class SubTask
    {
        public SubTask(string subTaskInfo)
        {
            Id = Convert.ToBase64String(Guid.NewGuid().ToByteArray());
            SubTaskInfo = subTaskInfo;
            Completed = false;
        }

        public string Id { get; }
        public string SubTaskInfo { get; }
        public bool Completed { get; set; }
    }
}