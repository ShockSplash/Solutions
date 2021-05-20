using ProjectStore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BussinesLayer.Interfaces
{
    public interface ISolutionsRepository
    {
        Task<List<ProjectStore.Solution>> GetAllSolutionsAsync();

        IEnumerable<Solution> GetAllSolutions();

        Solution GetSolutionById(int? taskId);

        void SaveSolution(Solution current);

        void DeleteSolution(Solution current);

        void EditSolution(Solution solution);

        bool isSolutionExist(int id);
    }
}
