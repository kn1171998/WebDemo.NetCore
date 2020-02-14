using Microsoft.AspNetCore.Mvc;
using PayCompute.Entity;
using PayCompute.Models.Department;
using PayCompute.Service.Implementation;
using System;
using System.Threading.Tasks;

namespace PayCompute.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            this._departmentService = departmentService;
        }

        public IActionResult Index()
        {
            return View(_departmentService.GetAll());
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new DepartmentCreateViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DepartmentCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var department = new Department
                {
                    Id = model.Id,
                    DepartmentCode = model.DepartmentCode,
                    DepartmentName = model.DepartmentName,
                    Address = model.Address,
                    Status = true
                };
                await _departmentService.CreateAsync(department);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var department = _departmentService.GetById(id);
            if (department == null)
            {
                return NotFound();
            }
            var model = new DepartmentEditViewModel()
            {
                Id = department.Id,
                DepartmentCode = department.DepartmentCode,
                DepartmentName = department.DepartmentName,
                Address = department.Address
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(DepartmentEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var department = _departmentService.GetById(model.Id);
                if (department == null)
                {
                    return NotFound();
                }
                //department.Id = model.Id;
                department.DepartmentCode = model.DepartmentCode;
                department.DepartmentName = model.DepartmentName;
                department.Address = model.Address;
                await _departmentService.UpdateAsync(department);
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
                await _departmentService.Delete(id);
                return Json(true);
            }
            catch (Exception)
            {
                result = false;
                return Json(result);
            }
        }
    }
}