using BussinesLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer
{
    public class DataManager
    {
        private readonly ISolutionsRepository _solutionsRepository;
        private readonly ITasksRepository _tasksRepository;

        public DataManager(ITasksRepository tasksRepository, ISolutionsRepository solutionsRepository)
        {
            _tasksRepository = tasksRepository;
            _solutionsRepository = solutionsRepository;
        }

        public ISolutionsRepository Solutions { get { return _solutionsRepository; }  }
        public ITasksRepository Tasks { get { return _tasksRepository; } }
    }
}
