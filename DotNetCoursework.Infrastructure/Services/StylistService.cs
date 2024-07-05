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
    public class StylistService
    {
        private SalonsDbContext context = new SalonsDbContext();

        public Stylist? SelectStylistById(int id)
        {
            return context.Stylists.Find(id);
        }

        public List<Stylist> GetStylists()
        {
            return context.Stylists.ToList();
        }

        public List<Stylist> GetStylists(int skip, int take)
        {
            return context.Stylists
                .Include(s=>s.Salons)
                .Skip(skip)
                .Take(take)
                .ToList();
        }

        public int GetStylistsCount()
        {
            return context.Stylists.Count();
        }

        public List<Stylist> GetStylistsBySalon(Salon salon)
        {
            return context.Stylists.Where(s=>s.Salons.Contains(salon)).ToList();
        }

        public void RemoveStylist(int id)
        {
            context.Stylists.Remove(GetStylistById(id));
            context.SaveChanges();
        }

        public Stylist? GetStylistById(int id)
        {
            return context.Stylists
               .Include(s => s.User)
               .Where(s => s.Id == id)
               .FirstOrDefault();
        }
    }
}
