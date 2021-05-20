using BussinesLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using ProjectStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BussinesLayer.Implementations
{
    public class EFSolutionsRepository : ISolutionsRepository
    {
        //Data context
        private readonly project_storageContext _context;

        public EFSolutionsRepository(project_storageContext context)
        {
            _context = context;
        }

        /// <summary>Method for removing the solution
        /// <para name = "current">Solution to be removed</para>
        /// </summary>
        public void DeleteSolution(Solution current)
        {
            if (current != null)
            {
                _context.Solutions.Remove(current);
                _context.SaveChanges();
            }
        }

        /// <summary>Method for editing the solution
        /// <para name = "soluton">Solution to be edited</para>
        /// </summary>
        public void EditSolution(Solution solution)
        {
            _context.Update(solution);
            _context.SaveChangesAsync();
        }

        /// <summary>Async method for getting all solutions
        /// </summary>
        public Task<List<ProjectStore.Solution>> GetAllSolutionsAsync()
        {
            return _context.Solutions.ToListAsync();
        }

        /// <summary>Method for getting all solutions
        /// </summary>
        public IEnumerable<Solution> GetAllSolutions()
        {
            return _context.Solutions.ToList();
        }

        /// <summary>Method for getting solution by taskId
        /// <para name = "taskId">Task id for allow to current solution</para>
        /// </summary>
        public Solution GetSolutionById(int? taskId)
        {
            return _context.Solutions.FirstOrDefault(s => s.Id == taskId);
        }

        /// <summary>Method check solution exist
        /// <para name = "id">TSolution id</para>
        /// </summary>
        public bool isSolutionExist(int id)
        {
            return _context.Solutions.Any(e => e.Id == id);
        }

        /// <summary>Method for saving solution
        /// <para name = "current">A solution that must be preserved</para>
        /// </summary>
        public void SaveSolution(Solution current)
        {
            if (current != null)
            {
                _context.Add(current);
                _context.SaveChanges();
            }
        }
    }
}
