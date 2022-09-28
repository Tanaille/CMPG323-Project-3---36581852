using DeviceManagement_WebApp.Models;
using System;

namespace DeviceManagement_WebApp.Repository
{
    public interface IZoneRepository : IGenericRepository<Zone>
    {
        public void Edit(Guid? id, Zone zone);
        public Zone Edit(Guid? id);
    }
}