using DeviceManagement_WebApp.Controllers;
using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace DeviceManagement_WebApp.Repository
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        //protected readonly ConnectedOfficeContext _context = new ConnectedOfficeContext();
        public CategoryRepository(ConnectedOfficeContext context) : base(context)
        {

        }

        // GET: Categories
        public  IEnumerable<Category> GetAll()
        {
            return _context.Category.ToList();  
        }

        // GET: Categories by ID
        public async Task<Category> GetByID(Guid? id)
        {
            var category = await _context.Category
                .FirstOrDefaultAsync(m => m.CategoryId == id);

            return category;
        }

        // POST: Create category
        public async void Add([Bind("CategoryId,CategoryName,CategoryDescription,DateCreated")] Category category)
        {
            category.CategoryId = Guid.NewGuid();
            _context.Add(category);
            _context.SaveChanges();
        }
    }
}
