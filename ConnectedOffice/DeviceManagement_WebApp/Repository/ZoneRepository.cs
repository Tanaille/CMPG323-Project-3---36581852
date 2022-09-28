using DeviceManagement_WebApp.Controllers;
using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace DeviceManagement_WebApp.Repository
{
    public class ZoneRepository : GenericRepository<Models.Zone>, IZoneRepository
    {
        public ZoneRepository(ConnectedOfficeContext context) : base(context)
        {

        }

        // GET: Zones
        public IEnumerable<Models.Zone> GetAll()
        {
            return _context.Zone.ToList();
        }

        // GET: Zones by ID
        public async Task<Models.Zone> GetByID(Guid? id)
        {
            var zone = await _context.Zone
                .FirstOrDefaultAsync(z => z.ZoneId == id);

            return zone;
        }

        // POST: Create zone
        //public void Add([Bind("ZoneId, ZoneName, ZoneDescription, DateCreated")] Models.Zone zone)
        //{
        //    zone.ZoneId = Guid.NewGuid();
        //    _context.Add(zone);
        //    _context.SaveChanges();
        //}

        public Models.Zone Edit(Guid? id)
        {
            var zone = _context.Zone
                .FirstOrDefault(z => z.ZoneId == id);

            return zone;
        }

        // POST: Edit zone by ID
        public void Edit(Guid? id, [Bind("ZoneId,ZoneName,ZoneDescription,DateCreated")] Models.Zone zone)
        {
            var _zone = _context.Zone.FirstOrDefault(z => z.ZoneId == id);

            _zone.ZoneName = zone.ZoneName;
            _zone.ZoneDescription = zone.ZoneDescription;

            _context.SaveChangesAsync();
        }

        // POST: Delete zone by ID
        public void Remove(Guid id, Models.Zone zone)
        {
            Models.Zone _zone = new Models.Zone()
            {
                ZoneId = id
            };

            _context.Remove(_zone);

            _context.SaveChanges();
        }

        // GET: Zones/Delete/5
        public Models.Zone Delete(Guid? id)
        {
            var _zone = _context.Zone.FirstOrDefault(z => z.ZoneId == id);

            return _zone;
        }
    }
}
