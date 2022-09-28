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

namespace DeviceManagement_WebApp.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoriesController(ICategoryRepository categoryRepository)
        { 
            _categoryRepository = categoryRepository;
        }

        // GET: All categories
        public async Task<IActionResult> Index()
        {
            // Set ViewData to include Category details, then return the view
            ViewData["CategoryId"] = new SelectList(_categoryRepository.GetAll(), "CategoryId", "CategoryName", "CategoryDescription", "DateCreated");

            return View(_categoryRepository.GetAll());
        }

        // GET: Category by ID
        public async Task<IActionResult> Details(Guid? id)
        {
            // Check if category exists
            if (!_categoryRepository.EntityExists(_categoryRepository.GetById(id)))
                return NotFound();

            // Set ViewData to include Category details, then return the view
            ViewData["CategoryId"] = new SelectList(_categoryRepository.GetAll(), "CategoryId", "CategoryName", "CategoryDescription");

            return View(_categoryRepository.GetById(id));
        }

        // GET: Populate category creation view
        public IActionResult Create()
        {
            return View();
        }

        // POST: Create category
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategoryId,CategoryName,CategoryDescription,DateCreated")] Category category)
        {
            // Assign values to Category entity
            category.CategoryId = Guid.NewGuid();
            category.DateCreated = DateTime.Now;

            // Add category to DB and return to Category index page
            _categoryRepository.Add(category);

            return RedirectToAction(nameof(Index));
        }

        // GET: Populate category edit view
        public async Task<IActionResult> Edit(Guid? id)
        {
            // Check if category exists
            if (id == null)
            {
                return NotFound();
            }

            return View(_categoryRepository.Edit(id));
        }

        // POST: Edit category
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid? id, [Bind("CategoryId,CategoryName,CategoryDescription,DateCreated")] Category category)
        {
            // Check if category exists
            if (!_categoryRepository.EntityExists(_categoryRepository.GetById(id)))
                return NotFound();

            // Edit category and return to Category index page
            _categoryRepository.Edit(id, category);

            return RedirectToAction(nameof(Index));
        }

        // GET: Populate the category delete view
        public async Task<IActionResult> Delete(Guid? id)
        {
            // Check that ID is supplied and that the category exists
            if (id == null)
            {
                return NotFound();
            }

            var category = _categoryRepository.GetById(id);

            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: Delete category
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            // Check if category exists
            if (!_categoryRepository.EntityExists(_categoryRepository.GetById(id)))
                return NotFound();

            // Remove category from DB and return to index page
            _categoryRepository.Remove(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
