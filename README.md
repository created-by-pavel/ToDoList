# ToDoList
### Task description
Implement an application that handles commands:
- [X] **/add** *task-info* - creates new task
- [X] **/all** - displays all tasks
- [X] **/delete** *id* - deletes the task by id (which should appear in /all)
- [X] **/save** *file-name.txt* - saves all current tasks to the specified file
- [X] **/load** *file-name.txt* - loads tasks from file
- [X] **/complete** *id* - indicates that the task is completed. *Completed tasks are displayed at the end of the list and are marked as completed.*
- [X] **/completed** - displays all completed tasks
- *The ability to specify the due date:*
- [X] Info about **deadlines** in /all
- [X] **/today** - displays tasks with the deadline for the current day
- [X] **/create-group** *group-name* - creates a group for tasks
- [X] **/delete-group** *group-name* - removes the group with the specified name
- [X] **/add-to-group** *id group-name* - adds a task with the specified id to the specified group
- [X] **/delete-from-group** *id group-name* - removes a task with the specified id from the specified group
- [X] Tasks that are in the group should be displayed in a **nested list** when /all is executed
- [X] **/completed** *group-name* - displays all completed tasks in the group
- [X] **/add-subtask** *id subtask-info* - adds a subtask to the selected task
- [X] **/complete** *id* supporting for a subtask
- [X] Tasks with subtasks should display information about **how many subtasks** have been **completed** in the "3/4" format.
- [X] Missing files, incorrect input format.
- [X] Corner cases (e.g. one task cannot be added twice).
- #### An example of working
![example](https://github.com/created-by-pavel/ToDoList/blob/main/Screenshots/Снимок%20экрана%202022-01-06%20в%2011.11.24.png)
