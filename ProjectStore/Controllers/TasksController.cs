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
    public class TasksController : Controller
    {
        private readonly DataManager _dataManager;

        private readonly ISortSolution _sortSolutions;

        private readonly ServicesManager _servicesmanager;


        public TasksController(DataManager dataManager, ISortSolution sortSolutions)
        {
            _dataManager = dataManager;
            _sortSolutions = sortSolutions;
            _servicesmanager = new ServicesManager(dataManager);
        }
        // GET: Tasks
        public async Task<IActionResult> Index()
        {
            var project_storageContext = await _dataManager.Tasks.GetAllTasksAsync();
            return View(project_storageContext.ToList());
        }

        // GET: Tasks/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var task = _dataManager.Tasks.GetTaskById(id);
            if (task == null)
            {
                return NotFound();
            }

            return View(task);
        }

        // GET: Tasks/Create
        public IActionResult Create()
        {
            ViewData["SolutionId"] = new SelectList(_dataManager.Solutions.GetAllSolutions(), "Id", "Name");
            return View();
        }

        // POST: Tasks/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SolutionId,TaskName,Description,Priority,task_status")] Task task)
        {
            if (ModelState.IsValid && task.Priority >= 0)
            {

                _dataManager.Tasks.SaveTask(task);
                var tasks =await _dataManager.Tasks.GetAllTaskByIDAsync(task.SolutionId);
                return View("Index", tasks);
            }
            ViewData["SolutionId"] = new SelectList(_dataManager.Solutions.GetAllSolutions(), "Id", "Name", task.SolutionId);
            return NotFound("Unvaild data: the priority must be greater than or equal to 0.");
        }

        // GET: Tasks/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var task = _dataManager.Tasks.GetTaskById(id);
            if (task == null)
            {
                return NotFound();
            }
            ViewData["SolutionId"] = new SelectList(_dataManager.Solutions.GetAllSolutions(), "Id", "Name", task.SolutionId);
            return View(task);
        }

        // POST: Tasks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SolutionId,TaskName,Description,Priority,task_status")] Task task)
        {
            if (id != task.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _dataManager.Tasks.EditTask(task);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaskExists(task.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                var tasks = await _dataManager.Tasks.GetAllTaskByIDAsync(task.SolutionId);
                return View("Index", tasks);
            }
            ViewData["SolutionId"] = new SelectList(_dataManager.Solutions.GetAllSolutions(), "Id", "Name", task.SolutionId);
            return View(task);
        }

        // GET: Tasks/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var task = _dataManager.Tasks.GetTaskById(id);
            if (task == null)
            {
                return NotFound();
            }

            return View(task);
        }

        // POST: Tasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var task = _dataManager.Tasks.GetTaskById(id);
            _dataManager.Tasks.DeleteTask(task);
            var tasks =await _dataManager.Tasks.GetAllTaskByIDAsync(task.SolutionId);
            return View("Index", tasks);
        }

        private bool TaskExists(int id)
        {
            return _dataManager.Tasks.isTaskExist(id);
        }
    }
}
