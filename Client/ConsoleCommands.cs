using System;
using ToDoList.Services;
namespace ToDoList.Client
{
    public class ConsoleCommands
    {
        private readonly IToDoListService _service;
        private readonly Drawing _drawing;
        private bool _run;
        private string[] _input;
        public ConsoleCommands()
        {
            _service = new ToDoListService();
            _drawing = new Drawing();
            _run = true;
        }

        private void ReadCommands()
        {
            _input = Console.ReadLine().Split(" ");
            var args = string.Join(' ', _input, 1, _input.Length - 1);
            switch (_input[0])
            {
                case "/add":
                    _service.AddTask(args);
                    break;
                case "/all":
                    _drawing.DrawGroupsTree(_service.GetAllGroups());
                    _drawing.DrawTable(_service.GetTasksNotInGroup());
                    break;
                case "/delete":
                    _service.DeleteTaskById(args);
                    break;
                case "/save":
                    _service.Save();
                    break;
                case "/load":
                    _service.Load();
                    _drawing.DrawGroupsTree(_service.GetAllGroups());
                    _drawing.DrawTable(_service.GetTasksNotInGroup());
                    break;
                case "/complete":
                    _service.DoComplete(args);
                    break;
                case "/completed":
                    _drawing.DrawTable(_service.GetAllCompletedTasks());
                    break;
                case "/deadline":
                    var deadlineArgs = args.Split(" ");
                    var deadLineTime = string.Join(' ', deadlineArgs, 1, deadlineArgs.Length - 1);
                    _service.AddDeadLine(deadlineArgs[0], DateTime.Parse(deadLineTime));
                    break;
                case "/today":
                    _drawing.DrawTable(_service.GetTodayTasks());
                    break;
                case "/add-subtask":
                    var subtaskArgs = args.Split(" ");
                    var subtaskInfo = string.Join(' ', subtaskArgs, 1, subtaskArgs.Length - 1);
                    _service.AddSubTask(subtaskArgs[0], subtaskInfo);
                    break;
                case "/create-group":
                    _service.AddGroup(args);
                    break;
                case "/delete-group":
                    _service.DeleteGroup(args);
                    break;
                case "/add-to-group":
                    var groupArgs = args.Split(" ");
                    var groupName = string.Join(' ', groupArgs, 1, groupArgs.Length - 1);
                    _service.AddTaskToGroup(groupArgs[0], groupName);
                    break;
                case "/delete-from-group":
                    var delGroupArgs = args.Split(" ");
                    var delGroupName = string.Join(' ', delGroupArgs, 1, delGroupArgs.Length - 1);
                    _service.DeleteTaskFromGroup(delGroupArgs[0], delGroupName);
                    break;
                case "/exit":
                    _run = false;
                    break;
                default:
                    Console.WriteLine("Invalid command");
                    break;
            }
        }

        public void Run()
        {
            while (_run)
            {
                ReadCommands();
            }
        }
    }
}