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

namespace DeviceManagement_WebApp.Controllers
{
    public class ZonesController : Controller
    {
        private readonly IZoneRepository _zoneRepository;

        public ZonesController(IZoneRepository zoneRepository)
        {
            _zoneRepository = zoneRepository;
        }

        // GET: All zones
        public async Task<IActionResult> Index()
        {
            // Set ViewData to include Zone details, then return the view
            ViewData["ZoneId"] = new SelectList(_zoneRepository.GetAll(), "ZoneId", "ZoneName", "ZoneDescription", "DateCreated");

            return View(_zoneRepository.GetAll());
        }

        // GET: zone by ID
        public async Task<IActionResult> Details(Guid? id)
        {
            // Check if zone exists
            if (!_zoneRepository.EntityExists(_zoneRepository.GetById(id)))
                return NotFound();

            // Set ViewData to include Zone details, then return the view
            ViewData["ZoneId"] = new SelectList(_zoneRepository.GetAll(), "ZoneId", "ZoneName", "ZoneDescription", "DateCreated");

            return View(_zoneRepository.GetById(id));
        }

        // GET: Populate zone creation view
        public IActionResult Create()
        {
            return View();
        }

        // POST: Create zone
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ZoneId,ZoneName,ZoneDescription,DateCreated")] Models.Zone zone)
        {
            // Assign values to Zone entity
            zone.ZoneId = Guid.NewGuid();
            zone.DateCreated = DateTime.Now;

            // Add zone to DB and return to Zone index page
            _zoneRepository.Add(zone);

            return RedirectToAction(nameof(Index));
        }

        // GET: Populate zone edit view
        public async Task<IActionResult> Edit(Guid? id)
        {
            // Check if zone exists
            if (id == null)
            {
                return NotFound();
            }

            return View(_zoneRepository.Edit(id));
        }

        // POST: Edit zone
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid? id, [Bind("ZoneId,ZoneName,ZoneDescription,DateCreated")] Models.Zone zone)
        {
            // Check if zone exists
            if (!_zoneRepository.EntityExists(_zoneRepository.GetById(id)))
                return NotFound();

            // Edit zone and return to Zone index page
            _zoneRepository.Edit(id, zone);

            return RedirectToAction(nameof(Index));
        }

        // GET: Populate the zone delete view
        public async Task<IActionResult> Delete(Guid? id)
        {
            // Check that ID is supplied and that the zone exists
            if (id == null)
            {
                return NotFound();
            }

            var zone = _zoneRepository.GetById(id);

            if (zone == null)
            {
                return NotFound();
            }

            return View(zone);
        }

        // POST: Delete zone
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            // Check if zone exists
            if (!_zoneRepository.EntityExists(_zoneRepository.GetById(id)))
                return NotFound();

            // Remove zone from DB and return to index page
            _zoneRepository.Remove(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
