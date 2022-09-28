using DeviceManagement_WebApp.Controllers;
using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace DeviceManagement_WebApp.Repository
{
    public class DeviceRepository : GenericRepository<Device>, IDeviceRepository
    {
        public DeviceRepository(ConnectedOfficeContext context) : base(context)
        {

        }

        // GET: Populate device edit view
        public Device Edit(Guid? id)
        {
            var device = _context.Device
                .FirstOrDefault(d => d.DeviceId == id);

            return device;
        }

        // POST: Edit device by ID
        public void Edit(Guid? id, [Bind("DeviceId,DeviceName,CategoryId,ZoneId,Status,IsActive,DateCreated")] Device device)
        {
            var _device = _context.Device.FirstOrDefault(d => d.DeviceId == id);

            _device.DeviceName = device.DeviceName;
            _device.Status = device.Status;
            _device.IsActive = device.IsActive;
            _device.CategoryId = device.CategoryId;
            _device.ZoneId = device.ZoneId;

            _context.SaveChangesAsync();
        }
    }
}