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
        private readonly project_storageContext _context;

        public EFSolutionsRepository(project_storageContext context)
        {
            _context = context;
        }

        public void DeleteSolution(Solution current)
        {
            if (current != null)
            {
                _context.Solutions.Remove(current);
                _context.SaveChanges();
            }
        }

        public void EditSolution(Solution solution)
        {
            _context.Update(solution);
            _context.SaveChangesAsync();
        }

        public Task<List<ProjectStore.Solution>> GetAllSolutionsAsync()
        {
            return _context.Solutions.ToListAsync();
        }

        public IEnumerable<Solution> GetAllSolutions()
        {
            return _context.Solutions.ToList();
        }

        public Solution GetSolutionById(int? taskId)
        {
            return _context.Solutions.FirstOrDefault(s => s.Id == taskId);
        }

        public bool isSolutionExist(int id)
        {
            return _context.Solutions.Any(e => e.Id == id);
        }

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
