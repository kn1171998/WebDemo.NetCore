using Microsoft.AspNetCore.Mvc;
using PayCompute.Entity;
using PayCompute.Models.Position;
using PayCompute.Service.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayCompute.Controllers
{
    public class PositionController : Controller
    {
        private readonly IPositionService _positionService;
        public PositionController(IPositionService positionService)
        {
            this._positionService = positionService;
        }
        public IActionResult Index()
        {
            return View(_positionService.GetAll());
        }
        public IActionResult Create()
        {
            var model = new PositionCreateViewModel();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PositionCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var position = new PositionJob()
                {
                    Id = model.Id,
                    PositionJobCode = model.PositionJobCode,
                    PositionJobName = model.PositionJobName,
                    InsuranceMoney = model.InsuranceMoney,
                    Status = true
                };
                await _positionService.CreateAsync(position);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var position = _positionService.GetById(id);
            if (position == null)
            {
                return NotFound();
            }
            var model = new PositionEditViewModel()
            {
                Id = position.Id,
                PositionJobCode = position.PositionJobCode,
                PositionJobName = position.PositionJobName,
                InsuranceMoney = position.InsuranceMoney
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(PositionEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var position = _positionService.GetById(model.Id);
                if (position == null)
                {
                    return NotFound();
                }
                //Position.Id = model.Id;
                position.PositionJobCode = model.PositionJobCode;
                position.PositionJobName = model.PositionJobName;
                position.InsuranceMoney = model.InsuranceMoney;
                await _positionService.UpdateAsync(position);
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
                await _positionService.Delete(id);
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
