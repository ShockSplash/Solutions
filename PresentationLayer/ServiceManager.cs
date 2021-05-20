using BussinesLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace PresentationLayer.Services
{
    /// <summary>
    /// This class is used as a layer for SolutionSerive and TaskService
    /// </summary>
    public class ServicesManager
    {
        DataManager _dataManager;
        private SolutionService _solutionService;
        private TaskService _taskService;

        public ServicesManager(
            DataManager dataManager
            )
        {
            _dataManager = dataManager;
        }
        public SolutionService Solutions { get { return _solutionService; } }
        public TaskService Tasks { get { return _taskService; } }
    }
}
