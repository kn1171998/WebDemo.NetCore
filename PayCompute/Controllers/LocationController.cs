using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PayCompute.Entity;
using PayCompute.Models.Location;
using PayCompute.Service.Implementation;
using System;
using System.Threading.Tasks;

namespace PayCompute.Controllers
{
    public class LocationController : Controller
    {
        private readonly ILocationService _locationService;
        private readonly IDepartmentService _departmentService;
        private readonly IPositionService _positionService;
        public LocationController(ILocationService locationService, 
                            IDepartmentService departmentService,
                            IPositionService positionService)
        {
            this._locationService = locationService;
            this._departmentService = departmentService;
            this._positionService = positionService;
        }

        public IActionResult Index()
        {
            return View(_locationService.GetAll());
        }

        public IActionResult Create()
        {
            var model = new LocationCreateViewModel();
            ViewBag.listDept = _departmentService.GetAll();
            ViewBag.listPos = _positionService.GetAll();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LocationCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var location = new Location
                {
                    Id = model.Id,
                    LocationName = model.LocationName,
                    DepartmentId = model.DepartmentId,
                    PositionJobId = model.PositionJobId,
                    Status = true
                };
                await _locationService.CreateAsync(location);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var location = _locationService.GetById(id);
            if (location == null)
            {
                return NotFound();
            }
            var model = new LocationCreateViewModel
            {
                Id = location.Id,
                LocationName = location.LocationName,
                DepartmentId = location.DepartmentId,
                PositionJobId = location.PositionJobId
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(LocationCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var location = _locationService.GetById(model.Id);
                if (location == null)
                {
                    return NotFound();
                }
                location.LocationName = model.LocationName;
                location.DepartmentId = model.DepartmentId;
                location.PositionJobId = model.PositionJobId;
                await _locationService.UpdateAsync(location);
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
                await _locationService.Delete(id);
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