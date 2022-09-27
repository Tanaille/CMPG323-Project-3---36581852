using DeviceManagement_WebApp.Models;
using System;

namespace DeviceManagement_WebApp.Repository
{
    public interface IDeviceRepository : IGenericRepository<Device>
    {
        public void Edit(Guid? id, Device device);
        public Device Edit(Guid? id);
        public Device Delete(Guid? id);
    }
}
