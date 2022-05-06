using Microsoft.AspNetCore.Mvc;
using SPHF.Models;
using SPHF.Models.Services;
using SPHF.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPHF.Controllers
{

    public class TanksController : Controller
    {
        ITankService _tankService;
        private readonly ICountryService _countryService;
        public TanksController(ITankService tankService, ICountryService countryService)
        {
            _tankService = tankService;
            _countryService = countryService;
        }
        public IActionResult Tanks()
        {
            return View(_tankService.GetAll());
        }
        [HttpGet]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create()
        {
            TankCreateViewModel model = new TankCreateViewModel();
            model.Countries = _countryService.GetAll();
            return View(model);
        }
        [HttpPost]
        public IActionResult Create(TankCreateViewModel createTank)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _tankService.Create(createTank);
                }
                catch (ArgumentException exception)
                {
                    ModelState.AddModelError("Name or country", exception.Message);
                    return View(createTank);
                }

                return RedirectToAction(nameof(Tanks));
            }
            return View(createTank);
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            Tank tank = _tankService.FindById(id);

            if (tank == null)
            {
                return RedirectToAction(nameof(Tanks));
                //return NotFound();//404
            }

            return View(tank);
        }
        [HttpGet]
        [AutoValidateAntiforgeryToken]
        public IActionResult Edit(int id)
        {
            Tank tank = _tankService.FindById(id);

            if (tank == null)
            {
                return RedirectToAction(nameof(Tanks));
                //return NotFound();//404
            }
            TankCreateViewModel editTank = new TankCreateViewModel()
            {
                Name = tank.Name,
                TankInfo = tank.TankInfo,
                TankType = tank.TankType,
                CountryId = tank.Id
            };
            editTank.Countries = _countryService.GetAll();
            ViewBag.Id = id;

            return View(editTank);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Edit(int id, TankCreateViewModel editTank)
        {

            if (ModelState.IsValid)
            {
                _tankService.Edit(id, editTank);
                return RedirectToAction(nameof(Tanks));
                //return NotFound();//404
            }

            editTank.Countries = _countryService.GetAll();
            ViewBag.Id = id;

            return View(editTank);
        }
        public IActionResult Delete(int id)
        {
            Tank tank = _tankService.FindById(id);
            //_peopleService.Remove(id);
            if (tank == null)
            {
                return RedirectToAction(nameof(Tanks));
                //return NotFound();//404
            }
            else
            {
                _tankService.Remove(id);

            }

            return View();

        }
    }
}
