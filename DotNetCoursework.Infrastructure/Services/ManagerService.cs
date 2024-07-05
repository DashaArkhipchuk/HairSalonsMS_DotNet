using DotNetCoursework.Domain;
using DotNetCoursework.Infrastructure.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetCoursework.Infrastructure.Services
{
    public class ManagerService
    {
        private SalonsDbContext context = new SalonsDbContext();

        public Manager? SelectManagerById(int id)
        {
            return context.Managers.Find(id);
        }

        public List<Manager> GetManagers()
        {
            return context.Managers.ToList();
        }

        public List<Manager> GetManagers(int skip, int take)
        {
            return context.Managers
                .Include(m=>m.Salons)
                .Skip(skip)
                .Take(take)
                .ToList();
        }

        public int GetManagersCount()
        {
            return context.Managers.Count();
        }

        public Manager? GetManagerById(int id)
        {
            return context.Managers.Include(m=>m.User).Where(m => m.Id == id).FirstOrDefault();
        }

        public void RemoveManager(int id)
        {
            context.Managers.Remove(GetManagerById(id));
            context.SaveChanges();
        }

    }
}
