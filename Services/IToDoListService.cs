using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices.ComTypes;
using ToDoList.Models;

namespace ToDoList.Services
{
    public interface IToDoListService
    {
        public Task AddTask(string taskInfo);
        public List<Task> GetTasksNotInGroup();
        public void DeleteTaskById(string taskId);
        public void Save();
        public void Load();
        public void DoComplete(string id);
        public List<Task> GetAllCompletedTasks();
        public void AddDeadLine(string taskId, DateTime deadLine);
        public List<Task> GetTodayTasks();
        public Group AddGroup(string groupName);
        public void DeleteGroup(string groupName);
        public List<Group> GetAllGroups();
        public void AddTaskToGroup(string taskId, string groupName);
        public void DeleteTaskFromGroup(string taskId, string groupName);
        public SubTask AddSubTask(string taskId, string subTaskInfo);
    }
}