﻿using ProjectStore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace PresentationLayer.Models
{
    public class SolutionViewModel
    {
        public Solution solution { get; set; }
        
        public List<Task> Tasks { get; set; }
    }

    public class SolutionEditModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime CompletionDate { get; set; }

        [Required]
        public int? Priority { get; set; }

        public SolutionsStatus solution_status { get; set; }
    }
}
