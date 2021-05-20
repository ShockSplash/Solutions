using ProjectStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Models
{
    /// <summary>
    /// Not all methods described in this class are used.
    /// </summary>
    public class SortSolution : ISortSolution
    {
        /// <summary>
        /// Sort solution's by start date.
        /// </summary>
        /// <param name="solutionList">List of filtering solutions</param>
        /// <returns></returns>
        public IEnumerable<Solution> SortByStartDate(List<Solution> solutionList)
        {
            return solutionList.OrderBy(d => d.StartDate);
        }

        /// <summary>
        /// Sort solution's by end date.
        /// </summary>
        /// <param name="solutionList">List of filtering solutions</param>
        /// <returns></returns>
        public IEnumerable<Solution> SortByEndDate(List<Solution> solutionList)
        {
            return solutionList.OrderByDescending(d => d.StartDate);
        }

        /// <summary>
        /// Sort solution's by name.
        /// </summary>
        /// <param name="solutionList">List of filtering solutions</param>
        /// <returns></returns>
        public IEnumerable<Solution> SortByName(List<Solution> solutionList)
        {
            return solutionList.OrderByDescending(d => d.Name);
        }

        /// <summary>
        /// Sort solution's by priority.
        /// </summary>
        /// <param name="solutionList">List of filtering solutions</param>
        /// <returns></returns>
        public IEnumerable<Solution> SortByPriority(List<Solution> solutionList)
        {
            return solutionList.OrderByDescending(d => d.Priority);
        }

        /// <summary>
        /// Sort solution's by solution status.
        /// </summary>
        /// <param name="solutionList">List of filtering solutions</param>
        /// <returns></returns>
        public IEnumerable<Solution> SortBySolutionStatus(List<Solution> solutionList)
        {
            return solutionList.OrderByDescending(d => d.solution_status);
        }
    }
}
