using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectStore
{
    /// <summary>
    /// A class describing the "Solution" relation.
    /// </summary>
    public partial class Solution
    {
        public Solution()
        {
            Tasks = new HashSet<Task>();
        }

        /// <summary>
        /// Solution id  - primary key.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Solution name.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Solution start date.
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Solution end date.
        /// </summary>
        public DateTime CompletionDate { get; set; }

        /// <summary>
        /// Resolution priority.
        /// </summary>
        [Required]
        public int? Priority { get; set; }

        /// <summary>
        /// Solution status there are 3 states:  NotStarted,Active,Completed.
        /// </summary>
        public SolutionsStatus solution_status { get; set; }

        /// <summary>
        /// Collection of solution's tasks.
        /// </summary>
        public virtual ICollection<Task> Tasks { get; set; }
    }
}
