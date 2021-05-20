using BussinesLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Services
{
    /// <summary>
    /// In this class we work with models "TaskModels", since they are not used, these too.
    /// </summary>
    public class TaskService
    {
        private readonly DataManager _dataManager;

        public TaskService(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        /// <summary>
        /// Method for cast from DBModel to view model(TaskViewModel).
        /// </summary>
        /// <param name="TaskId">Current task id</param>
        /// <returns></returns>
        public TaskViewModel TaskDBModelToView(int TaskId)
        {
            var model = new TaskViewModel()
            {
                task = _dataManager.Tasks.GetTaskById(TaskId)
            };

            return model;
        }

        /// <summary>
        /// Method for get TaskEditModel from DBModel.
        /// </summary>
        /// <param name="TaskId">Current task id</param>
        /// <returns></returns>
        public TaskEditModel GetTaskEditModel(int TaskId)
        {
            var model = _dataManager.Tasks.GetTaskById(TaskId);

            var editModel = new TaskEditModel()
            {
                Id = model.Id,
                SolutionId = model.SolutionId,
                task_status = model.task_status,
                TaskName = model.TaskName,
                Description = model.Description,
                Priority = model.Priority
            };

            return editModel;
        }

    }
}
