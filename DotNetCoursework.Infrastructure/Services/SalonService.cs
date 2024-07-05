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
    public class SalonService
    {
        private SalonsDbContext context = new SalonsDbContext();


        public List<Salon> GetSalons(int skip = 0, int take = 5)
        {
            return context.Salons
                .Include(s => s.Address)
                .Include(s => s.Managers)
                .Include(s => s.Stylists)
                .OrderBy(s => s.Name)
                .Skip(skip)
                .Take(take)
                .ToList();
        }

        public List<Salon> GetSalonsWithNoRelatedData()
        {
            return context.Salons
                .ToList();
        }

        public List<Salon> GetSalonWithNoRelatedDataById(int id)
        {
            return context.Salons
                .Where(s=>s.Id==id)
                .ToList();
        }

        public int GetSalonsCount()
        {
            return context.Salons.Count();
        }

        public void AddSalon(Salon s)
        {
            if (context.Entry(s.Address).State == EntityState.Detached)
            {
                context.Addresses.Attach(s.Address);
            }

            // Attach or add managers
            foreach (var manager in s.Managers)
            {
                if (context.Entry(manager).State == EntityState.Detached)
                {
                    context.Managers.Attach(manager);
                }
            }

            // Attach or add stylists
            foreach (var stylist in s.Stylists)
            {
                if (context.Entry(stylist).State == EntityState.Detached)
                {
                    context.Stylists.Attach(stylist);
                }
            }


            context.Salons.Add(s);
            context.SaveChanges();
        }

        public Salon? SelectSalonById(int id)
        {
            return context.Salons
                .Include(s => s.Address)
                .Include(s => s.Managers)
                .Include(s => s.Stylists)
                .Where(s => s.Id == id)
                .FirstOrDefault();
        }

        public void UpdateSalon(int id, Salon s)
        {
            Salon salon = SelectSalonById(id);
            if (salon == null)
            {
                return;
            }

            salon.Name = s.Name;
            salon.Description = s.Description;
            salon.ContactPhone = s.ContactPhone;
            salon.ContactEmail = s.ContactEmail;
            salon.Address = s.Address;

            // Update Managers
            var existingManagers = salon.Managers.ToList();
            var newManagers = s.Managers.ToDictionary(m => m.Id);

            foreach (var manager in existingManagers)
            {
                if (!newManagers.ContainsKey(manager.Id))
                {
                    salon.Managers.Remove(manager);
                }
            }

            foreach (var manager in s.Managers)
            {
                var trackedManager = context.Managers.Local.FirstOrDefault(m => m.Id == manager.Id) ?? context.Managers.Find(manager.Id);
                if (trackedManager == null)
                {
                    context.Managers.Attach(manager);
                    salon.Managers.Add(manager);
                }
                else
                {
                    if (!salon.Managers.Any(m => m.Id == manager.Id))
                    {
                        salon.Managers.Add(trackedManager);
                    }
                }
            }

            // Update Stylists
            var existingStylists = salon.Stylists.ToList();
            var newStylists = s.Stylists.ToDictionary(st => st.Id);

            foreach (var stylist in existingStylists)
            {
                if (!newStylists.ContainsKey(stylist.Id))
                {
                    salon.Stylists.Remove(stylist);
                }
            }

            foreach (var stylist in s.Stylists)
            {
                var trackedStylist = context.Stylists.Local.FirstOrDefault(st => st.Id == stylist.Id) ?? context.Stylists.Find(stylist.Id);
                if (trackedStylist == null)
                {
                    context.Stylists.Attach(stylist);
                    salon.Stylists.Add(stylist);
                }
                else
                {
                    if (!salon.Stylists.Any(st => st.Id == stylist.Id))
                    {
                        salon.Stylists.Add(trackedStylist);
                    }
                }
            }

            context.SaveChanges();

        }

        public void RemoveSalon(int id)
        {
            context.Salons.Remove(SelectSalonById(id));
            context.SaveChanges();

        }

        public List<Salon> GetSalonsByManager(int managerId, int skip, int take)
        {
            return context.Salons
                .Where(s=>s.Managers.Select(m=>m.Id).Contains(managerId))
                .Include(s => s.Address)
                .Include(s => s.Managers)
                .Include(s => s.Stylists)
                .OrderBy(s => s.Name)
                .Skip(skip)
                .Take(take)
                .ToList();
        }

        public List<Salon> GetSalonsByManagerWithNoRelatedData(int id)
        {
            return context.Salons
                .Where(s => s.Managers.Select(m => m.Id).Contains(id))
                .OrderBy(s => s.Name)
                .ToList();
        }
    }
}
