using BussinesLayer;
using PresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Services
{
    public class SolutionService
    {
        private readonly DataManager _dataManager;

        public SolutionService(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public SolutionViewModel SolutionDBModelToView(int SolutionId)
        {
            var res = _dataManager.Tasks.GetAllTasks();
            var model = new SolutionViewModel()
            {
                solution = _dataManager.Solutions.GetSolutionById(SolutionId),
                Tasks = res.Where(i => i.SolutionId == SolutionId).ToList()
            };

            return model;
        }

        public SolutionEditModel GetSolutionEditModel(int SolutionId)
        {
            var model = _dataManager.Solutions.GetSolutionById(SolutionId);

            var editModel = new SolutionEditModel()
            {
                Id = model.Id,
                CompletionDate = model.CompletionDate,
                Name = model.Name,
                StartDate = model.StartDate,
                solution_status = model.solution_status,
                Priority = model.Priority
            };

            return editModel;
        }


    }
}
