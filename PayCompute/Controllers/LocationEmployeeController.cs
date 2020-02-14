using Microsoft.AspNetCore.Mvc;
using PayCompute.Entity;
using PayCompute.Models.LocationEmployee;
using PayCompute.Service;
using PayCompute.Service.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayCompute.Controllers
{
    public class LocationEmployeeController : Controller
    {
        private readonly ILocationEmployeeService _locationEmployeeService;
        private readonly IEmployeeService _employeeService;
        private readonly ILocationService _locationService;
        private readonly ITimekeepingEMPService _timekeepingEMPService;
        private readonly IPositionService _positionService;
        public LocationEmployeeController(ILocationEmployeeService locationEmployeeService,
                                          IEmployeeService employeeService,
                                          ILocationService locationService,
                                          ITimekeepingEMPService timekeepingEMPService,
                                          IPositionService positionService)
        {
            this._locationEmployeeService = locationEmployeeService;
            this._employeeService = employeeService;
            this._locationService = locationService;
            this._timekeepingEMPService = timekeepingEMPService;
            this._positionService = positionService;
        }
        public IActionResult Create()
        {
            var model = new LocationEmployeeCreateViewModel();
            ViewBag.listPos = _positionService.GetAll();
            ViewBag.listEMP = _employeeService.GetAll();
            return View(model);
        }
        public JsonResult LoadLocationIdEMP(int id)
        {
            var a = _timekeepingEMPService.LoadLocationEMP_FlowID(id).ToList();
            var dm = a[0];

            return new JsonResult(a);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LocationEmployeeCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var locationemployee = new LocationEmployee
                {
                    DateJoinedLocation = DateTime.Now,
                    EmployeeId = model.EmployeeId,
                    LocationId = model.LocationId,
                    Status = true,
                    StatusJoindLocation = true
                };
                
                await _locationEmployeeService.CreateAsync(locationemployee);
                return RedirectToAction("Create");
            }
            return View();
        }
        public IActionResult LoadLocation_FlowPos(int id)
        {
            var a = _locationEmployeeService.LoadLocation_FlowPos(id);
            return new JsonResult(a);
        }
    }
}
