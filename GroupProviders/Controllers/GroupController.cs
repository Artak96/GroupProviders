using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core.Entities;
using DAL.Contexts;
using Core.Interfaces.IServices;
using Core.ViewModels;

namespace GroupProviders.Controllers
{
    public class GroupController : Controller
    {
        private readonly IGroupService _service;

        public GroupController(IGroupService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View( _service.GetAll().ToList());
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var group = _service.Get(id);
            if (group is null)
            {
                return NotFound();
            }

            return View(group);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Type,Name,CreateDate,IsDeleted")] GroupViewModel model)
        {
            if (ModelState.IsValid)
            {
                _service.Add(model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var group = _service.Get(id);
            return View(group);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Type,Name,CreateDate,IsDeleted")] GroupViewModel model)
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
            var providers = x.OrderByDescending(p => p.CreateDate);

            return Json(providers);
        }
    }
}
