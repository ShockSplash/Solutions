using ProjectStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Interfaces
{
    public interface ITasksRepository
    {
        IEnumerable<ProjectStore.Task> GetAllTasks();

        Task<List<ProjectStore.Task>> GetAllTasksAsync();

        ProjectStore.Task GetTaskById(int? taskId);

        public Task<List<ProjectStore.Task>> GetAllTaskByIDAsync(int? id);

        public List<ProjectStore.Task> GetAllTaskByID(int? id);

        void SaveTask(ProjectStore.Task current);

        void DeleteTask(ProjectStore.Task current);

        void EditTask(ProjectStore.Task task);

        bool isTaskExist(int id);
    }
}
