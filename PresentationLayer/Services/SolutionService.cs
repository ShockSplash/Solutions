using BussinesLayer;
using PresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Services
{
    /// <summary>
    /// In this class we work with models "SolutionModel", since they are not used, these too.
    /// </summary>
    public class SolutionService
    {
        private readonly DataManager _dataManager;

        public SolutionService(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        /// <summary>
        /// Method for cast from DBModel to view model(SolutionViewModel).
        /// </summary>
        /// <param name="SolutionId">Current solution id</param>
        /// <returns></returns>
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

        /// <summary>
        /// Method for get SolutionEditModel from DBModel.
        /// </summary>
        /// <param name="SolutionId">Current solution id</param>
        /// <returns></returns>
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
