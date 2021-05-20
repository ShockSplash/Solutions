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
        //Data context
        private readonly project_storageContext _context;

        public EFTasksRepository(project_storageContext context)
        {
            _context = context;
        }

        /// <summary>Async method for getting task by id
        /// <para name = "id">Current Task id</para>
        /// </summary>
        public Task<List<ProjectStore.Task>> GetAllTaskByIDAsync(int? id)
        {
            var res =  _context.Set<ProjectStore.Task>().Include(x => x.Solution).AsNoTracking().Where(h
    => h.SolutionId == id).ToListAsync();

            return res;
        }

        /// <summary>Method for getting task by id
        /// <para name = "id">Current Task id</para>
        /// </summary>
        public List<ProjectStore.Task> GetAllTaskByID(int? id)
        {

            return _context.Set<ProjectStore.Task>().Include(x => x.Solution).AsNoTracking().Where(h
                => h.SolutionId == id).ToList();
        }

        /// <summary>Method for deleting a task
        /// <para name = "current">Task that needs to be deleted</para>
        /// </summary>
        public void DeleteTask(ProjectStore.Task current)
        {
            if (current != null)
            {

                _context.Remove(current);
                _context.SaveChanges();
            }
        }

        /// <summary>Method for editing task 
        /// <para name = "task">Task that needs to be edited</para>
        /// </summary>
        public void EditTask(ProjectStore.Task task)
        {
            _context.Update(task);
            _context.SaveChangesAsync();
        }

        /// <summary>Method for getting all tasks 
        /// </summary>
        public IEnumerable<ProjectStore.Task> GetAllTasks()
        {
            return _context.Set<ProjectStore.Task>().Include(x => x.Solution).AsNoTracking().ToList();
        }

        /// <summary>Async method for getting all tasks 
        /// </summary>
        public Task<List<ProjectStore.Task>> GetAllTasksAsync()
        {
            return _context.Set<ProjectStore.Task>().Include(x => x.Solution).AsNoTracking().ToListAsync();
        }

        /// <summary>Method for getting task 
        /// <para name = "taskId">TaskId that needs to be geted</para>
        /// </summary>
        public ProjectStore.Task GetTaskById(int? taskId)
        {
            return _context.Tasks.FirstOrDefault(t => t.Id == taskId);
        }

        /// <summary>Check for task existing
        /// <para name = "id">TaskId that needs to be checked</para>
        /// </summary>
        public bool isTaskExist(int id)
        {
            return _context.Tasks.Any(e => e.Id == id);
        }

        /// <summary>Method for saving task 
        /// <para name = "current">Task that needs to be saved</para>
        /// </summary>
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
