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

        // GET: Populate zone edit view
        public Models.Zone Edit(Guid? id)
        {
            // Get the zone by ID and return it
            var _zone = GetById(id);

            return _zone;
        }

        // POST: Edit zone by ID
        public void Edit(Guid? id, [Bind("ZoneId,ZoneName,ZoneDescription,DateCreated")] Models.Zone zone)
        {
            // Get the zone by ID, set the zone properties and commit changes
            var _zone = GetById(id);

            _zone.ZoneName = zone.ZoneName;
            _zone.ZoneDescription = zone.ZoneDescription;

            _context.SaveChangesAsync();
        }
    }
}
