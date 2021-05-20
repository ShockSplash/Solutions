using ProjectStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Models
{
    public class SortSolution : ISortSolution
    {
        public IEnumerable<Solution> SortByStartDate(List<Solution> solutionList)
        {
            return solutionList.OrderBy(d => d.StartDate);
        }

        public IEnumerable<Solution> SortByEndDate(List<Solution> solutionList)
        {
            return solutionList.OrderByDescending(d => d.StartDate);
        }
        
        public IEnumerable<Solution> SortByName(List<Solution> solutionList)
        {
            return solutionList.OrderByDescending(d => d.Name);
        }

        public IEnumerable<Solution> SortByPriority(List<Solution> solutionList)
        {
            return solutionList.OrderByDescending(d => d.Priority);
        }

        public IEnumerable<Solution> SortBySolutionStatus(List<Solution> solutionList)
        {
            return solutionList.OrderByDescending(d => d.solution_status);
        }
    }
}
