using Microsoft.AspNetCore.Mvc;
using PayCompute.Entity;
using PayCompute.Models.Relative;
using PayCompute.Service.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayCompute.Controllers
{
    public class RelativeController : Controller
    {
        private readonly IRelativeService _relativeService;
        public RelativeController(IRelativeService relativeService)
        {
            this._relativeService = relativeService;
        }
        public IActionResult Index()
        {
            return View(_relativeService.GetAll());
        }

        [HttpGet]
        public IActionResult Create(int myVar, string emp)
        {
            var model = new RelativeCreateViewModel();
            model.EmpCode = emp;//mã của employee
            model.EmployeeId = myVar;//id của employee
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RelativeCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var relative = new Relative
                {
                    Id = model.Id,
                    Name = model.Name,
                    Gender = model.Gender,
                    Relationship = model.Relationship,
                    DOB = model.DOB,
                    EmployeeId = model.EmployeeId
                };
                await _relativeService.CreateAsync(relative);
                return RedirectToAction("Detail", "Employee", new { id = model.EmployeeId });
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var relative = _relativeService.GetById(id);
            if (relative == null)
            {
                return NotFound();
            }
            var model = new RelativeEditViewModel()
            {
                Id = relative.Id,
                Name = relative.Name,
                Gender = relative.Gender,
                Relationship = relative.Relationship,
                DOB = relative.DOB,
                EmployeeId = relative.EmployeeId
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(RelativeEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var relative = _relativeService.GetById(model.Id);
                if (relative == null)
                {
                    return NotFound();
                }
                //department.Id = model.Id;
                relative.Name = model.Name;
                relative.Gender = model.Gender;
                relative.Relationship = model.Relationship;
                relative.DOB = model.DOB;
                relative.EmployeeId = model.EmployeeId;
                await _relativeService.UpdateAsync(relative);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            bool result = true;
            try
            {
                await _relativeService.Delete(id);

            }
            catch (Exception)
            {
                result = false;
            }
            return Json(result);
        }
    }
}

