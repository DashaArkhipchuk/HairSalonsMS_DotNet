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
    public class ScheduleService
    {
        private SalonsDbContext context = new SalonsDbContext();

        public void AddSchedule(Schedule s)
        {
            if (context.Entry(s.Salon).State == EntityState.Detached)
            {
                context.Salons.Attach(s.Salon);
            }

            var trackedStylist = context.Stylists.Local.FirstOrDefault(st => st.Id == s.Stylist.Id) ?? context.Stylists.Find(s.Stylist.Id);
            if (trackedStylist == null)
            {
                context.Stylists.Attach(s.Stylist);
            }
            else
            {
                s.Stylist = trackedStylist;
            }


            context.Schedules.Add(s);
            context.SaveChanges();
        }

        public void UpdateSchedule(int id, Schedule s)
        {
            Schedule schedule = GetScheduleById(id);
            if (schedule == null)
            {
                return;
            }

            schedule.Date = s.Date;
            schedule.StartHour = s.StartHour;
            schedule.EndHour = s.EndHour;


            var trackedStylist = context.Stylists.Local.FirstOrDefault(st => st.Id == s.Stylist.Id) ?? context.Stylists.Find(s.Stylist.Id);
            if (trackedStylist == null)
            {
                context.Stylists.Attach(s.Stylist);
                schedule.Stylist = s.Stylist;
            }
            else
            {
                schedule.Stylist= trackedStylist;
            }

            var trackedSalon = context.Salons.Local.FirstOrDefault(st => st.Id == s.Salon.Id) ?? context.Salons.Find(s.Salon.Id);
            if (trackedSalon == null)
            {
                context.Salons.Attach(s.Salon);
                schedule.Salon = s.Salon;
            }
            else
            {
                schedule.Salon = trackedSalon;
            }

            context.SaveChanges();
        }

        public Schedule? GetScheduleById(int id)
        {
            return context.Schedules
                .Include(s => s.Salon)
                .Include(s => s.Stylist)
                .Where(s => s.Id == id)
                .FirstOrDefault();
        }

        public List<Schedule> GetSchedules(int skip = 0, int take = 5)
        {
            return context.Schedules
                .Include(s => s.Stylist)
                .Include(s => s.Salon)
                .Include(s => s.Appointment)
                    .ThenInclude(a=>a.Customer)
                .Include(s => s.Appointment)
                    .ThenInclude(a => a.Service)
                .Where(s=>s.Date>=DateOnly.FromDateTime(DateTime.Today))
                .Skip(skip)
                .Take(take)
                .ToList();
        }

        public int GetSchedulesCount()
        {
            return context.Schedules.Where(s => s.Date >= DateOnly.FromDateTime(DateTime.Today)).Count();
        }

        public void RemoveSchedule(int id)
        {
            context.Schedules.Remove(GetScheduleById(id));
            context.SaveChanges();
        }

        public List<Schedule> GetSchedulesByStylistAndSalon(Salon? salon, Stylist? stylist)
        {
            return context.Schedules.Where(schedule=>schedule.Stylist==stylist).Where(schedule=>schedule.Salon==salon).Where(schedule => schedule.Date >= DateOnly.FromDateTime(DateTime.Today)).Where(schedule=>schedule.Appointment==null).ToList();
        }

        public List<Schedule> GetSchedulesByStylist(int stylistId)
        {
            return context.Schedules
                .Where(schedule => schedule.Stylist.Id == stylistId)
                .Include(s => s.Stylist)
                .Include(s => s.Salon)
                .Include(s => s.Appointment)
                    .ThenInclude(a => a.Customer)
                .Include(s => s.Appointment)
                    .ThenInclude(a => a.Service)
                .Where(schedule => schedule.Date >= DateOnly.FromDateTime(DateTime.Today)).ToList();
        }

        public List<Schedule> GetSchedulesBySalon(int id)
        {
             return context.Schedules
                .Where(schedule=>schedule.Salon.Id == id)
                .Include(s => s.Stylist)
                .Include(s => s.Salon)
                .Include(s => s.Appointment)
                    .ThenInclude(a => a.Customer)
                .Include(s => s.Appointment)
                    .ThenInclude(a => a.Service)
                .Where(schedule => schedule.Date >= DateOnly.FromDateTime(DateTime.Today)).ToList();
        }

        public int GetSchedulesBySalonsCount(List<Salon> salons)
        {
            int count = 0;
            foreach(var salon in salons)
            {
                count += GetSchedulesBySalon(salon.Id).Count();
            }
            return count;
        }
    }
}
