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
    public class ServicesService
    {
        private SalonsDbContext context = new SalonsDbContext();

        public List<Service> GetServices()
        {
            return context.Services
                .Include(s=>s.Price)
                .ToList();
        }

        public List<Service> GetServices(int skip, int take)
        {
            return context.Services
                .Include(s => s.Price)
                    .ThenInclude(s => s.Currency)
                    .Skip(skip)
                    .Take(take)
                .ToList();
        }


    }
}
