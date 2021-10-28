using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RockyASPMVC.Data;

namespace RockyASPMVC.Controllers
{
    public class Category : Controller
    {
        private readonly ApplicationDbContext _context;

        public Category(ApplicationDbContext context)
        {
            _context = context;
        }
        
        // GET
        public IActionResult Index()
        {
            IEnumerable<Models.Category> categories = _context.Category;
            return View(categories);
        }
        
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Models.Category category)
        {
            if (!ModelState.IsValid) return View();
            
            _context.Category.Add(category);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id < 1)
            {
                return NotFound();
            }

            var category = _context.Category.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Models.Category category)
        {
            if (!ModelState.IsValid) return View();
            
            _context.Category.Update(category);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id < 1)
            {
                return NotFound();
            }

            var category = _context.Category.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost]
        public IActionResult Delete(Models.Category category)
        {
            _context.Category.Remove(category);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}