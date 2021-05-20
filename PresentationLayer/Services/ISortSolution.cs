using ProjectStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Models
{
    /// <summary>
    /// Service for filter Solution's
    /// </summary>
    public interface ISortSolution
    {
        public IEnumerable<Solution> SortByStartDate(List<Solution> solutionList);

        public IEnumerable<Solution> SortByEndDate(List<Solution> solutionList);

        public IEnumerable<Solution> SortByName(List<Solution> solutionList);

        public IEnumerable<Solution> SortByPriority(List<Solution> solutionList);

        public IEnumerable<Solution> SortBySolutionStatus(List<Solution> solutionList);
    }
}
