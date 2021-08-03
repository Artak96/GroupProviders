using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Core.Entities;
using DAL.Contexts;
using Core.Interfaces.IServices;
using Core.ViewModels;
using GroupProviders.Validation;
using AutoMapper;
using BLL.Services;

namespace GroupProviders.Controllers
{
    public class ProviderController : Controller
    {
        private readonly IProviderService _service;

        public ProviderController(IProviderService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_service.GetAll().ToList());
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var provider = _service.Get(id);
            if (provider == null)
            {
                return NotFound();
            }

            return View(provider);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var providerService = _service as ProviderService;
            var groups = providerService.groupService.GetAll();
            ProviderViewModel provider = new ProviderViewModel
            {
                Groups = groups.ToList()
            };

            return View(provider);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProviderViewModel model)
        {
            var validator = new ProviderCreateValidation();
            if (validator.Validate(model).IsValid)
            {
                _service.Add(model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var providerService = _service as ProviderService;
            var groups = providerService.groupService.GetAll();
            var provider = providerService.Get(id);
            provider.Groups = groups.ToList();

            return View(provider);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Type,Name,CreateDate,GroupId,IsDeleted")] ProviderViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _service.Update(model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        
        public IActionResult Delete(int id)
        {
            if (_service.Delete(id))
            {
                return RedirectToAction("Index");
            }
            return BadRequest();

        }

        public JsonResult Filter()
        {
            var x = _service.GetAll();
            var providers =x.OrderByDescending(p => p.CreateDate);

            return Json(providers);
        }
    }
}
