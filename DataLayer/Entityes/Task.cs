using System;
using System.Collections.Generic;

namespace ProjectStore
{
    public partial class Task
    {
        public int Id { get; set; }

        public int? SolutionId { get; set; }

        public string TaskName { get; set; }

        public string Description { get; set; }

        public int? Priority { get; set; }

        public TasksStatus task_status { get; set; }

        public virtual Solution Solution { get; set; }
    }
}
