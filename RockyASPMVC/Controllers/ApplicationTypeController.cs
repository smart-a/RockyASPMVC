using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RockyASPMVC.Data;
using RockyASPMVC.Models;

namespace RockyASPMVC.Controllers
{
    public class ApplicationTypeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ApplicationTypeController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET
        public IActionResult Index()
        {
            IEnumerable<ApplicationType> appTypes = _context.ApplicationType;
            return View(appTypes);
        }
        
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ApplicationType appType)
        {
            if (!ModelState.IsValid) return View();
            
            _context.ApplicationType.Add(appType);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }

        public IActionResult Edit(int? id)
        {
            if (id is null or < 1)
            {
                return NotFound();
            }

            var appType = _context.ApplicationType.Find(id);
            if (appType == null)
            {
                return NotFound();
            }
            return View(appType);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ApplicationType appType)
        {
            if (!ModelState.IsValid) return View();
            
            _context.ApplicationType.Update(appType);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }

        public IActionResult Delete(int? id)
        {
            if (id is null or < 1)
            {
                return NotFound();
            }

            var appType = _context.ApplicationType.Find(id);
            if (appType == null)
            {
                return NotFound();
            }
            return View(appType);
        }

        [HttpPost]
        public IActionResult Delete(ApplicationType appType)
        {
            _context.ApplicationType.Remove(appType);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}