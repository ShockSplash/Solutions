using System;
using System.Collections.Generic;

namespace ProjectStore
{
    /// <summary>
    /// A class describing the "Task" relation.
    /// </summary>
    public partial class Task
    {
        /// <summary>
        /// Task id - primary key.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Solution Id To which the assignment refers - foreign key.
        /// </summary>
        public int? SolutionId { get; set; }

        /// <summary>
        /// Name of task.
        /// </summary>
        public string TaskName { get; set; }

        /// <summary>
        /// Task description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Resolution priority.
        /// </summary>
        public int? Priority { get; set; }

        /// <summary>
        /// Task status there are 3 states:  ToDo,InProgress,Done.
        /// </summary>
        public TasksStatus task_status { get; set; }

        /// <summary>
        /// Solution which the assignment refers.
        /// </summary>
        public virtual Solution Solution { get; set; }
    }
}
