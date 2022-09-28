using DeviceManagement_WebApp.Models;
using System;

namespace DeviceManagement_WebApp.Repository
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        public void Edit(Guid? id, Category category);
        public Category Edit(Guid? id);
    }
}
