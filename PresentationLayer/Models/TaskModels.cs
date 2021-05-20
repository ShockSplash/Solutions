using ProjectStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PresentationLayer
{
    /// <summary>
    /// Various composite models can be stored here, they are not needed in this project, but they are there for example
    /// </summary>
    public class TaskViewModel
    {
        public Task task;
    }

    /// <summary>
    /// Various composite models can be stored here, they are not needed in this project, but they are there for example
    /// </summary>
    public class TaskEditModel
    {
        public int Id { get; set; }

        public int? SolutionId { get; set; }

        public string TaskName { get; set; }

        public string Description { get; set; }

        public int? Priority { get; set; }

        public TasksStatus task_status { get; set; }

    }
}
