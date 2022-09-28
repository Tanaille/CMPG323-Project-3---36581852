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
        public CategoryRepository(ConnectedOfficeContext context) : base(context)
        {

        }

        // GET: Populate category edit view
        public Category Edit(Guid? id)
        {
            // Get the category by ID and return it
            var _category = GetById(id);

            return _category;
        }

        // POST: Edit category by ID
        public void Edit(Guid? id, [Bind("CategoryId,CategoryName,CategoryDescription,DateCreated")] Category category)
        {
            // Get the device by ID, set the device properties and commit changes
            var _category = GetById(id);

            _category.CategoryDescription = category.CategoryDescription;
            _category.CategoryName = category.CategoryName;

            _context.SaveChangesAsync();
        }

    }
}
