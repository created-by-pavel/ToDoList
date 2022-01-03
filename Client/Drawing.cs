using System.Collections.Generic;
using System.Globalization;
using Spectre.Console;
using ToDoList.Models;

namespace ToDoList.Client
{
    public class Drawing
    {
        public void DrawGroupsTree(List<Group> groups)
        { 
            var root = new Tree("Groups");
            foreach (var group in groups)
            {
                var newTable = new Table()
                    .Border(TableBorder.Rounded)
                    .Expand()
                    .AddColumns("Id", "Task", "Creation Time", "DeadLine", "Completed", "SubTasks");

                var node = root.AddNode(newTable);
                foreach (var task in group.Tasks)
                {
                    var subTaskTable = new Table()
                        .Border(TableBorder.Rounded)
                        .Expand()
                        .AddColumns("Id", "Task", "Completed");
                    if (task.SubTasks.Count > 0)
                    {
                        foreach (var subTask in task.SubTasks)
                        {
                            subTaskTable.AddRow(subTask.Id, subTask.SubTaskInfo, subTask.Completed ? "[darkcyan]True[/]" : "[red1]False[/]");
                        }
                    }
                    newTable.AddRow(
                        new Markup(task.Id),
                        new Markup(task.TaskInfo),
                        new Markup(task.CreationTime.ToShortDateString()),
                        new Markup($"{(task.DeadLine == default ? " " : task.DeadLine.ToShortDateString()) }"),
                        new Markup($"{(task.Completed ? "[darkcyan]True[/]" : "[red1]False[/]") }"),
                        subTaskTable);
                }
            }
            AnsiConsole.Write(root);
        }

        public void DrawTable(List<Task> tasks)
        {
            var taskTable = new Table()
                .Border(TableBorder.Rounded)
                .Centered()
                .Expand()
                .AddColumns("Id", "Task", "Creation Time", "DeadLine", "Completed", "SubTasks");

            foreach (var task in tasks)
            {
                var subTaskTable = new Table()
                    .Border(TableBorder.Rounded)
                    .Expand()
                    .AddColumns("Id", "Task", "Completed");
                if (task.SubTasks.Count > 0)
                {
                    foreach (var subTask in task.SubTasks)
                    {
                        subTaskTable.AddRow(subTask.Id, subTask.SubTaskInfo, subTask.Completed ? "[darkcyan]True[/]" : "[red1]False[/]");
                    }
                }

                taskTable.AddRow(
                    new Markup($"[yellow1]{task.Id}[/]"),
                    new Markup(task.TaskInfo),
                    new Markup($"[paleturquoise1]{task.CreationTime.ToShortDateString()}[/]"),
                    new Markup($"{(task.DeadLine == default ? " " : task.DeadLine.ToShortDateString()) }"),
                    new Markup($"{(task.Completed ? "[darkcyan]True[/]" : "[red1]False[/]") }"),
                    subTaskTable);
            }
            AnsiConsole.Write(taskTable);
        }
    }
}