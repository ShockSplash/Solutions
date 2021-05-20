using ProjectStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PresentationLayer
{
    public class TaskViewModel
    {
        public Task task;
    }

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
