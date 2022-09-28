using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;
using DeviceManagement_WebApp.Repository;
using Microsoft.AspNetCore.Identity.UI.V3.Pages.Internal.Account;
using DeviceManagement_WebApp.Repository;

namespace DeviceManagement_WebApp.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IGenericRepository<Category> _genericRepository;

        public CategoriesController(ICategoryRepository categoryRepository, IGenericRepository<Category> genericRepository)
        { 
            _categoryRepository = categoryRepository;
            _genericRepository = genericRepository;
        }

        // GET: All categories
        public async Task<IActionResult> Index()
        {
            var categories = _categoryRepository.GetAll();

            return View(categories);

        }

        // GET: Category by ID
        public async Task<IActionResult> Details(Guid? id)
        {
            var category = _categoryRepository.GetById(id);

            return View(category);
        }

        // POST: Categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategoryId,CategoryName,CategoryDescription,DateCreated")] Category category)
        {
            category.CategoryId = Guid.NewGuid();
            category.DateCreated = DateTime.Now;
            _categoryRepository.Add(category);

            return RedirectToAction(nameof(Index));
        }

        // GET: Categories/Create
        public IActionResult Create()
        {
            return View();
        }

        // GET: Categories/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = _categoryRepository.Edit(id);

            return View(category);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid? id, [Bind("CategoryId,CategoryName,CategoryDescription,DateCreated")] Category category)
        {
            _categoryRepository.Edit(id, category);
            return RedirectToAction(nameof(Index));
        }

        // GET: Categories/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            return View(_categoryRepository.Delete(id));
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id, [Bind("CategoryId,CategoryName,CategoryDescription,DateCreated")] Category category)
        {
            _categoryRepository.Remove(id);
            
            return RedirectToAction(nameof(Index));
        }



        /*
        private bool CategoryExists(Guid id)
        {
            return _context.Category.Any(e => e.CategoryId == id);
        }

        */
    }
}
