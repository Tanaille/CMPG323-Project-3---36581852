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
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace DeviceManagement_WebApp.Controllers
{
    public class DevicesController : Controller
    {
        private readonly IDeviceRepository _deviceRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IZoneRepository _zoneRepository;

        public DevicesController(IDeviceRepository deviceRepository, ICategoryRepository categoryRepository, IZoneRepository zoneRepository)
        {
            _deviceRepository = deviceRepository;
            _categoryRepository = categoryRepository;
            _zoneRepository = zoneRepository;
        }

        // GET: All devices
        public async Task<IActionResult> Index()
        {
            // Set ViewData to include Category and Zone, then return the view
            ViewData["CategoryId"] = new SelectList(_categoryRepository.GetAll(), "CategoryId", "CategoryName");
            ViewData["ZoneId"] = new SelectList(_zoneRepository.GetAll(), "ZoneId", "ZoneName");

            return View(_deviceRepository.GetAll());
        }

        // GET: Device by ID
        public async Task<IActionResult> Details(Guid? id)
        {
            // Check if device exists
            if (!_deviceRepository.EntityExists(_deviceRepository.GetById(id)))
                return NotFound();

            // Set ViewData to include Category and Zone, then return the view
            ViewData["CategoryId"] = new SelectList(_categoryRepository.GetAll(), "CategoryId", "CategoryName");
            ViewData["ZoneId"] = new SelectList(_zoneRepository.GetAll(), "ZoneId", "ZoneName");

            return View(_deviceRepository.GetById(id));
        }

        // GET: Populate device creation view
        public IActionResult Create()
        {
            // Set ViewData to include Category and Zone, then return the view
            ViewData["CategoryId"] = new SelectList(_categoryRepository.GetAll(), "CategoryId", "CategoryName");
            ViewData["ZoneId"] = new SelectList(_zoneRepository.GetAll(), "ZoneId", "ZoneName");
            return View();
        }

        // POST: Create device
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DeviceId,DeviceName,CategoryId,ZoneId,Status,IsActive,DateCreated")] Device device)
        {
            // Assign values to Device entity (Category and Zone are pulled from the SelectList on the Create page)
            device.DeviceId = Guid.NewGuid();
            device.DateCreated = DateTime.Now;
            device.Category = _categoryRepository.GetById(device.CategoryId);
            device.Zone = _zoneRepository.GetById(device.ZoneId);

            // Add device to DB and return to Device index page
            _deviceRepository.Add(device);

            return RedirectToAction(nameof(Index));
        }

        // GET: Populate device edit view
        public async Task<IActionResult> Edit(Guid? id)
        {
            // Check if device exists
            if (id == null)
            {
                return NotFound();
            }

            // Set ViewData to include Category and Zone, then return the view
            ViewData["CategoryId"] = new SelectList(_categoryRepository.GetAll(), "CategoryId", "CategoryName");
            ViewData["ZoneId"] = new SelectList(_zoneRepository.GetAll(), "ZoneId", "ZoneName");

            return View(_deviceRepository.Edit(id));
        }

        // POST: Edit device
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid? id, [Bind("DeviceId,DeviceName,CategoryId,ZoneId,Status,IsActive,DateCreated")] Device device)
        {
            // Check if device exists
            if (!_deviceRepository.EntityExists(_deviceRepository.GetById(id)))
                return NotFound();

            // Edit device and return to Device index page
            _deviceRepository.Edit(id, device);

            return RedirectToAction(nameof(Index));
        }

        // GET: Populate the device delete view
        public async Task<IActionResult> Delete(Guid? id)
        {
            // Check that ID is supplied and that the device exists
            if (id == null)
            {
                return NotFound();
            }

            var device = _deviceRepository.GetById(id);

            if (device == null)
            {
                return NotFound();
            }

            // Set ViewData to include Category and Zone, then return the view
            ViewData["CategoryId"] = new SelectList(_categoryRepository.GetAll(), "CategoryId", "CategoryName");
            ViewData["ZoneId"] = new SelectList(_zoneRepository.GetAll(), "ZoneId", "ZoneName");

            return View(device);
        }

        // POST: Delete device
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            // Check if device exists
            if (!_deviceRepository.EntityExists(_deviceRepository.GetById(id)))
                return NotFound();

            // Remove device from DB and return to index page
            _deviceRepository.Remove(id);

            return RedirectToAction(nameof(Index));
        }     
    }
}
