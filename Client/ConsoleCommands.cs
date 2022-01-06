using System;
using ToDoList.Services;
using ToDoList.Tools;
using static System.DateTime;

namespace ToDoList.Client
{
    public class ConsoleCommands
    {
        private readonly IToDoListService _service;
        private readonly Drawing _drawing;
        private bool _run;
        private string[] _input;
        public ConsoleCommands(IToDoListService service, Drawing drawing)
        {
            _service = service;
            _drawing = drawing;
            _run = true;
        }

        private void ReadAndExecuteCommands()
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
                    if (_input.Length != 2) throw new ToDoListException("args length should be 1");
                    _service.DeleteTaskById(args);
                    break;
                case "/save":
                    _service.Save(args);
                    break;
                case "/load":
                    _service.Load(args);
                    _drawing.DrawGroupsTree(_service.GetAllGroups());
                    _drawing.DrawTable(_service.GetTasksNotInGroup());
                    break;
                case "/complete":
                    if (_input.Length != 2) throw new ToDoListException("args length should be 1");
                    _service.DoComplete(args);
                    break;
                case "/completed":
                    _drawing.DrawTable(_service.GetAllCompletedTasks());
                    break;
                case "/deadline":
                    if (_input.Length != 3) throw new ToDoListException("args length should be 2");
                    var deadlineArgs = args.Split(" ");
                    var deadLineTime = string.Join(' ', deadlineArgs, 1, deadlineArgs.Length - 1);
                    if (!TryParse(deadLineTime, out var deadline))
                        throw new ToDoListException("cant parse argument");
                    _service.AddDeadLine(deadlineArgs[0], deadline);
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
                    if (_input.Length != 2) throw new ToDoListException("args length should be 1");
                    _service.DeleteGroup(args);
                    break;
                case "/add-to-group":
                    if (_input.Length != 3) throw new ToDoListException("args length should be 2");
                    var groupArgs = args.Split(" ");
                    var groupName = string.Join(' ', groupArgs, 1, groupArgs.Length - 1);
                    _service.AddTaskToGroup(groupArgs[0], groupName);
                    break;
                case "/delete-from-group":
                    if (_input.Length != 3) throw new ToDoListException("args length should be 2");
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
                ReadAndExecuteCommands();
            }
        }
    }
}