using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PayCompute.Entity;
using PayCompute.Service.Implementation;
using System;
using System.Threading.Tasks;

namespace PayCompute.Controllers
{
    public class TimekeepingEMPController : Controller
    {
        private readonly ITimekeepingEMPService _timekeepingEMPService;
        private readonly IDepartmentService _departmentService;

        public TimekeepingEMPController(ITimekeepingEMPService timekeepingEMPService,
                                        IDepartmentService departmentService)
        {
            this._timekeepingEMPService = timekeepingEMPService;
            this._departmentService = departmentService;
        }

        public IActionResult GetData(int idDept)
        {
            if (_timekeepingEMPService.CheckTimeKeeping(DateTime.Now))
            {
                var a = false;
                return Json(a);
            }
            else
            {
                var a = _timekeepingEMPService.GetListEmployeeDept(idDept);
                return Json(a);
            }
        }

        public IActionResult GetData_Index(DateTime day, int idDept)
        {
            if (_timekeepingEMPService.CheckTimeKeeping(day))
            {
                var a = _timekeepingEMPService.GetListEmployeeDept_Index(idDept, day);
                return Json(a);
            }
            else
            {
                var a = false;
                return Json(a);
            }
        }

        public IActionResult Create()
        {
            //var getDept = _departmentService.GetAll();
            //return View(getDept);
            //IDepartmentService departmentService = ;

            return View(_departmentService.GetAll());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IFormCollection f)
        {
            int dept = int.Parse(f["dept"]);
            var listEMPDept = _timekeepingEMPService.GetListEmployeeDept(dept);
            foreach (var item in listEMPDept)
            {
                var timekeep = new TimekeepingEMP();
                timekeep.DateTimeKeeping = DateTime.Now;
                timekeep.EmployeeId = item.employeeid;
                var empid = item.employeeid.ToString();
                timekeep.Status = f["Status_" + empid] == "1" ? true : false;
                if (!timekeep.Status)
                    timekeep.Furlough = f["furlough_" + empid] == "1" ? true : false;
                timekeep.Reason = f["Reason_" + empid];
                timekeep.StartTimeKeeping = timekeep.DateTimeKeeping.TimeOfDay;
                await _timekeepingEMPService.CreateAsync(timekeep);
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Index()
        {
            return View(_departmentService.GetAll());
        }
    }
}