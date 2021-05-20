using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectStore
{
    public partial class Solution
    {
        public Solution()
        {
            Tasks = new HashSet<Task>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime CompletionDate { get; set; }

        [Required]
        public int? Priority { get; set; }

        public SolutionsStatus solution_status { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }
    }
}
