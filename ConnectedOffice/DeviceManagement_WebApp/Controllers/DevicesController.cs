﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;
using DeviceManagement_WebApp.Repository;

namespace DeviceManagement_WebApp.Controllers
{
    public class DevicesController : Controller
    {
        private readonly ConnectedOfficeContext _context;
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
            var devices = _deviceRepository.GetAll();

            return View(devices);

        }

        // GET: Device by ID
        public async Task<IActionResult> Details(Guid? id)
        {
            var device = _deviceRepository.GetById(id);

            return View(device);
        }

        // POST: Create device
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DeviceId,DeviceName,CategoryId,ZoneId,Status,IsActive,DateCreated")] Device device)
        {
            _deviceRepository.Add(device);

            return RedirectToAction(nameof(Index));
        }

        // GET: Devices/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_categoryRepository.GetAll(), "CategoryId", "CategoryName");
            ViewData["ZoneId"] = new SelectList(_zoneRepository.GetAll(), "ZoneId", "ZoneName");
            return View();
        }

        // GET: Devices/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var device = _deviceRepository.Edit(id);

            ViewData["CategoryId"] = new SelectList(_categoryRepository.GetAll(), "CategoryId", "CategoryName");
            ViewData["ZoneId"] = new SelectList(_zoneRepository.GetAll(), "ZoneId", "ZoneName");
            return View(device);
        }

        // POST: Edit device
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid? id, [Bind("DeviceId,DeviceName,CategoryId,ZoneId,Status,IsActive,DateCreated")] Device device)
        {
            _deviceRepository.Edit(id, device);
            return RedirectToAction(nameof(Index));
        }

        // GET: Devices/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            return View(_deviceRepository.Delete(id));
        }

        // POST: Delete device
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id, [Bind("DeviceId,DeviceName,CategoryId,ZoneId,Status,IsActive,DateCreated")] Device device)
        {
            _deviceRepository.Remove(id, device);

            return RedirectToAction(nameof(Index));
        }

        
        private bool DeviceExists(Guid id)
        {
            return _context.Device.Any(e => e.DeviceId == id);
        }
    }
}
