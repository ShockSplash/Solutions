using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BussinesLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PresentationLayer.Models;
using PresentationLayer.Services;
using ProjectStore;

namespace ProjectStore.Views
{
    public class SolutionsController : Controller
    {
        private readonly DataManager _dataManager;

        private readonly ISortSolution _sortSolutions;

        private readonly ServicesManager _servicesmanager;


        public SolutionsController(DataManager dataManager, ISortSolution sortSolutions)
        {
            _dataManager = dataManager;
            _sortSolutions = sortSolutions;
            _servicesmanager = new ServicesManager(dataManager);
        }

        // GET: Solutions
        public async Task<IActionResult> Index()
        {
            return View(await _dataManager.Solutions.GetAllSolutionsAsync());
        }

        // GET: Solutions/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var solution = new SolutionViewModel()
            {
                solution = _dataManager.Solutions.GetSolutionById(id),
                Tasks =  _dataManager.Tasks.GetAllTaskByID(id)
            };
            if (solution == null)
            {
                return NotFound();
            }

            return View(solution);
        }

        // GET: Solutions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Solutions/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,StartDate,CompletionDate,Priority,solution_status")] Solution solution)
        {
            if (ModelState.IsValid && solution.StartDate < solution.CompletionDate && solution.Priority >= 0)
            {
                _dataManager.Solutions.SaveSolution(solution);
                return RedirectToAction(nameof(Index));
            }
            return NotFound("Unvaild data: The end date must be greater than the start date and the priority must be greater than or equal to 0");
        }

        // GET: Solutions/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var solution = _dataManager.Solutions.GetSolutionById(id);
            if (solution == null)
            {
                return NotFound();
            }
            return View(solution);
        }

        // POST: Solutions/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,StartDate,CompletionDate,Priority,solution_status")] Solution solution)
        {
            if (id != solution.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _dataManager.Solutions.EditSolution(solution);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SolutionExists(solution.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(solution);
        }

        // GET: Solutions/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var solution = _dataManager.Solutions.GetSolutionById(id);
            if (solution == null)
            {
                return NotFound();
            }

            return View(solution);
        }

        // POST: Solutions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var solution = _dataManager.Solutions.GetSolutionById(id);
            _dataManager.Solutions.DeleteSolution(solution);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult SortByStartDate()
        {
           var solutionsResult = _sortSolutions.SortByStartDate(_dataManager.Solutions.GetAllSolutions().ToList());

            return View("Index", solutionsResult);
        }

        private bool SolutionExists(int id)
        {
            return _dataManager.Solutions.isSolutionExist(id);
        }

    }
}
