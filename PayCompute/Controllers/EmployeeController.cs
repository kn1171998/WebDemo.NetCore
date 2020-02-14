using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using PayCompute.Entity;
using PayCompute.Models;
using PayCompute.Service;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PayCompute.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IHostingEnvironment _hostingEnvironment;

        public EmployeeController(IEmployeeService employeeService, IHostingEnvironment hostingEnvironment)
        {
            this._employeeService = employeeService;
            this._hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            var employees = _employeeService.GetAll().Select(employee => new EmployeeIndexViewModel
            {
                Id = employee.Id,
                EmployeeId = employee.EmployeeId,
                ImageUrl = employee.ImageUrl,
                EmployeeName = employee.EmployeeName,
                Gender = employee.Gender,
                DOB = employee.DOB,
                Email = employee.Email,
                Address = employee.Address
            }).ToList();
            return View(employees);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new EmployeeCreateViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            bool result = true;
            try
            {
                await _employeeService.Delete(id);
                return Json(result);
            }
            catch (Exception)
            {
                result = false;
                return Json(result);
            }
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EmployeeCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var employee = new Employee
                {
                    Id = model.Id,
                    EmployeeId = model.EmployeeId,
                    EmployeeName = model.EmployeeName,
                    Gender = model.Gender,
                    Email = model.Email,
                    DOB = model.DOB,
                    DateJoined = model.DateJoined,
                    NationalInsuranceNo = model.NationalInsuranceNo,
                    PaymentMethod = model.PaymentMethod,
                    Address = model.Address,
                    NumberIdentify = model.NumberIdentify,
                    Phone = model.Phone,
                    Status = true
                };
                if (model.ImageUrl != null && model.ImageUrl.Length > 0)
                {
                    var uploadDir = @"images/employee";
                    var fileName = Path.GetFileNameWithoutExtension(model.ImageUrl.FileName);
                    var extenstion = Path.GetExtension(model.ImageUrl.FileName);
                    var webRootPath = _hostingEnvironment.WebRootPath;
                    fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + extenstion;
                    var path = Path.Combine(webRootPath, uploadDir, fileName);
                    await model.ImageUrl.CopyToAsync(new FileStream(path, FileMode.Create));
                    employee.ImageUrl = "/" + uploadDir + "/" + fileName;
                }
                await _employeeService.CreateAsync(employee);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var employee = _employeeService.GetById(id);
            if (employee == null)
            {
                return NotFound();
            }
            var model = new EmployeeEditViewModel()
            {
                Id = employee.Id,
                EmployeeId = employee.EmployeeId,
                EmployeeName = employee.EmployeeName,
                Gender = employee.Gender,
                Email = employee.Email,
                DOB = employee.DOB,
                DateJoined = employee.DateJoined,
                NationalInsuranceNo = employee.NationalInsuranceNo,
                PaymentMethod = employee.PaymentMethod,
                Address = employee.Address,
                NumberIdentify = employee.NumberIdentify,
                Phone = employee.Phone
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EmployeeEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var employee = _employeeService.GetById(model.Id);
                if (employee == null)
                {
                    return NotFound();
                }
                //employee.Id = model.Id;
                employee.EmployeeId = model.EmployeeId;
                employee.EmployeeName = model.EmployeeName;
                employee.Gender = model.Gender;
                employee.Email = model.Email;
                employee.DOB = model.DOB;
                employee.DateJoined = model.DateJoined;
                employee.NationalInsuranceNo = model.NationalInsuranceNo;
                employee.PaymentMethod = model.PaymentMethod;
                employee.Address = model.Address;
                employee.NumberIdentify = model.NumberIdentify;
                employee.Phone = model.Phone;
                if (model.ImageUrl != null && model.ImageUrl.Length > 0)
                {
                    var uploadDir = @"images/employee";
                    var fileName = Path.GetFileNameWithoutExtension(model.ImageUrl.FileName);
                    var extenstion = Path.GetExtension(model.ImageUrl.FileName);
                    var webRootPath = _hostingEnvironment.WebRootPath;
                    fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + extenstion;
                    var path = Path.Combine(webRootPath, uploadDir, fileName);
                    await model.ImageUrl.CopyToAsync(new FileStream(path, FileMode.Create));
                    employee.ImageUrl = "/" + uploadDir + "/" + fileName;
                }
                await _employeeService.UpdateAsync(employee);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Detail(int id)
        {
            var employee = _employeeService.GetById(id);
            if (employee == null)
            {
                return NotFound();
            }
            EmployeeDetailViewModel model = new EmployeeDetailViewModel()
            {
                Id = employee.Id,
                EmployeeId = employee.EmployeeId,
                EmployeeName = employee.EmployeeName,
                Gender = employee.Gender,
                Email = employee.Email,
                DOB = employee.DOB,
                DateJoined = employee.DateJoined,
                NationalInsuranceNo = employee.NationalInsuranceNo,
                PaymentMethod = employee.PaymentMethod,
                Address = employee.Address,
                Phone = employee.Phone,
                ImageUrl = employee.ImageUrl
            };
            ViewBag.Relative = _employeeService.GetRelatives(model.Id);
            return View(model);
        }
    }
}