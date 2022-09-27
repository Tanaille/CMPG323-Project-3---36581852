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

        // GET: Devices
        public IEnumerable<Device> GetAll()
        {
            return _context.Device.ToList();
        }

        // GET: Device by ID
        public async Task<Device> GetByID(Guid? id)
        {
            var device = await _context.Device
                .FirstOrDefaultAsync(m => m.DeviceId == id);

            return device;
        }

        // POST: Create device
        public void Add([Bind("DeviceId,DeviceName,CategoryId,ZoneId,Status,IsActive,DateCreated")] Device device)
        {
            device.DeviceId = Guid.NewGuid();



            _context.Add(device);
            _context.SaveChanges();
        }

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

        // POST: Delete device by ID
        public void Remove(Guid id, Device device)
        {
            Device _device = new Device()
            {
                DeviceId = id
            };

            _context.Remove(_device);

            _context.SaveChanges();
        }

        // GET: Devices/Delete/5
        public Device Delete(Guid? id)
        {
            var _device = _context.Device.FirstOrDefault(d => d.DeviceId == id);

            return _device;
        }
    }
}