using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using ToDoList.Models;
using ToDoList.Tools;

namespace ToDoList.Services
{
    public class ToDoListService : IToDoListService
    {
        private List<Task> _tasks = new ();
        private List<Group> _groups = new ();

        public Task AddTask(string taskInfo)
        {
            if (_tasks.Any(t => t.TaskInfo == taskInfo)) 
                throw new ToDoListException("this task already exists");
            Task newTask = new (taskInfo);
            _tasks.Add(newTask);
            return newTask;
        }

        public List<Task> GetTasksNotInGroup()
        {
            return _tasks.Except(GetTasksInGroups()).ToList();
        }

        public void DeleteTaskById(string taskId)
        {
            _tasks.Remove(GetTask(taskId));
        }

        public void Save(string directoryPath = "")
        {
            var jsonTasksString = JsonSerializer.Serialize(_tasks);
            var jsonGroupsString = JsonSerializer.Serialize(_groups);
            if (directoryPath == "")
            {
                File.WriteAllText("Tasks.json", jsonTasksString);
                File.WriteAllText("Groups.json", jsonGroupsString);
            }
            else
            {
                var file = new FileInfo(directoryPath + "/tasks.json");
                var file2 = new FileInfo(directoryPath + "/groups.json");
                File.WriteAllText(file.FullName, jsonTasksString);
                File.WriteAllText(file2.FullName, jsonGroupsString);
            }
        }

        public void Load(string directoryPath = "")
        {
            string jsonTasksString;
            string jsonGroupsString;
            if (directoryPath == "")
            {
                jsonTasksString = File.ReadAllText("Tasks.json");
                jsonGroupsString = File.ReadAllText("Groups.json");
            }
            else
            {
                jsonTasksString = File.ReadAllText(directoryPath + "/tasks.json");
                jsonGroupsString = File.ReadAllText(directoryPath + "/groups.json");  
            }

            _tasks = JsonSerializer.Deserialize<List<Task>>(jsonTasksString);
            _groups = JsonSerializer.Deserialize<List<Group>>(jsonGroupsString);
        }

        public void DoComplete(string id)
        {
            _tasks.ForEach(t => t.DoComplete(id));
        }

        public List<Task> GetAllCompletedTasks()
        {
            return _tasks.Where(t => t.Completed == true).ToList();
        }

        public void AddDeadLine(string taskId, DateTime deadLine)
        {
            GetTask(taskId).DeadLine = deadLine;
        }

        public List<Task> GetTodayTasks()
        {
            return _tasks.Where(t => t.DeadLine == DateTime.Today).ToList();
        }

        public Group AddGroup(string groupName)
        {
            if (_groups.Any(g => g.Name == groupName)) 
                throw new ToDoListException("this group already exists");
            Group newGroup = new (groupName);
            _groups.Add(newGroup);
            return newGroup;
        }

        public void DeleteGroup(string groupName)
        {
            _groups.Remove(GetGroup(groupName));
        }

        public List<Group> GetAllGroups() => _groups.ToList();

        public void AddTaskToGroup(string taskId, string groupName)
        {
            var group = GetGroup(groupName);
            var task = GetTask(taskId);
            if (group.Tasks.Contains(task)) 
                throw new ToDoListException("group already contains this task");
            group.Tasks.Add(task);
        }

        public void DeleteTaskFromGroup(string taskId, string groupName)
        {
            var group = GetGroup(groupName);
            var task = GetTask(taskId);

            if (group.Tasks.Contains(task))
                group.Tasks.Remove(task);
            else
                throw new ToDoListException("group doesnt contain this task");
        }

        public SubTask AddSubTask(string taskId, string subTaskInfo)
        {
            var task = GetTask(taskId);

            if (task.SubTasks.Any(st => st.SubTaskInfo == subTaskInfo)) 
                throw new ToDoListException("already exists");

            SubTask newSubTask = new (subTaskInfo);
            task.SubTasks.Add(newSubTask);
            return newSubTask;
        }

        private Task GetTask(string taskId)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == taskId);
            if (task == null) 
                throw new ToDoListException("cant find");
            return task;
        }

        private Group GetGroup(string groupName)
        {
            var group = _groups.FirstOrDefault(g => g.Name == groupName);
            if (group == null) 
                throw new ToDoListException("cant find");
            return group;
        }

        private List<Task> GetTasksInGroups()
        {
            var tasks = new List<Task>(_groups.SelectMany(g => g.Tasks));
            return tasks;
        }
    }
}