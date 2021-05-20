using BussinesLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Services
{
    public class TaskService
    {
        private readonly DataManager _dataManager;

        public TaskService(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public TaskViewModel TaskDBModelToView(int TaskId)
        {
            var model = new TaskViewModel()
            {
                task = _dataManager.Tasks.GetTaskById(TaskId)
            };

            return model;
        }

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
