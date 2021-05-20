using BussinesLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using ProjectStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BussinesLayer.Implementations
{
    public class EFTasksRepository : ITasksRepository
    {
        private readonly project_storageContext _context;

        public EFTasksRepository(project_storageContext context)
        {
            _context = context;
        }

        public Task<List<ProjectStore.Task>> GetAllTaskByIDAsync(int? id)
        {
            var res =  _context.Set<ProjectStore.Task>().Include(x => x.Solution).AsNoTracking().Where(h
    => h.SolutionId == id).ToListAsync();

            return res;
        }

        public List<ProjectStore.Task> GetAllTaskByID(int? id)
        {

            return _context.Set<ProjectStore.Task>().Include(x => x.Solution).AsNoTracking().Where(h
                => h.SolutionId == id).ToList();
        }

        public void DeleteTask(ProjectStore.Task current)
        {
            if (current != null)
            {

                _context.Remove(current);
                _context.SaveChanges();
            }
        }

        public void EditTask(ProjectStore.Task task)
        {
            _context.Update(task);
            _context.SaveChangesAsync();
        }

        public IEnumerable<ProjectStore.Task> GetAllTasks()
        {
            return _context.Set<ProjectStore.Task>().Include(x => x.Solution).AsNoTracking().ToList();
        }

        public Task<List<ProjectStore.Task>> GetAllTasksAsync()
        {
            return _context.Set<ProjectStore.Task>().Include(x => x.Solution).AsNoTracking().ToListAsync();
        }

        public ProjectStore.Task GetTaskById(int? taskId)
        {
            return _context.Tasks.FirstOrDefault(t => t.Id == taskId);
        }

        public bool isTaskExist(int id)
        {
            return _context.Tasks.Any(e => e.Id == id);
        }

        public void SaveTask(ProjectStore.Task current)
        {
            if (current != null)
            {
                _context.Add(current);
                _context.SaveChanges();
            }
        }
    }
}
