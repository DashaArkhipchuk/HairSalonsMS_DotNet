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
    public class AppointmentService
    {
        private SalonsDbContext context = new SalonsDbContext();

        public void AddAppointment(Appointment a)
        {
            if (context.Entry(a.Salon).State == EntityState.Detached)
            {
                context.Salons.Attach(a.Salon);
            }

            if (context.Entry(a.Stylist).State == EntityState.Detached)
            {
                context.Stylists.Attach(a.Stylist);
            }

            if (context.Entry(a.Schedule).State == EntityState.Detached)
            {
                context.Schedules.Attach(a.Schedule);
            }

            if (context.Entry(a.Customer).State == EntityState.Detached)
            {
                context.Customers.Attach(a.Customer);
            }

            if (context.Entry(a.Service).State == EntityState.Detached)
            {
                context.Services.Attach(a.Service);
            }




            context.Appointments.Add(a);
            context.SaveChanges();
        }

        public Appointment? GetAppointmentById(int id)
        {
            return context.Appointments
                .Include(a => a.Salon)
                .Include(a => a.Schedule)
                .Include(a => a.Service)
                .Include(a => a.Customer)
                .Include(a => a.Stylist)
                .Where(a => a.Id == id)
                .FirstOrDefault();
        }

        public List<Appointment> GetAppointments(int skip = 0, int take = 5)
        {
            return context.Appointments
                .Include(a => a.Salon)
                .Include(a=>a.Schedule)
                .Include(a=>a.Service)
                .Include(a=>a.Customer)
                .Include(a=>a.Stylist)
                .Skip(skip)
                .Take(take)
                .ToList();
        }

        public List<Appointment> GetAppointmentsByCustomer(int id)
        {
            return context.Appointments
                .Include(a => a.Salon)
                .Include(a => a.Schedule)
                .Include(a => a.Service)
                .Include(a => a.Customer)
                .Include(a => a.Stylist)
                .Where(a => a.Customer.Id == id)
                .ToList();
        }

        public List<Appointment> GetAppointmentsBySalon(int id)
        {
            return context.Appointments
                .Include(a => a.Salon)
                .Include(a => a.Schedule)
                .Include(a => a.Service)
                .Include(a => a.Customer)
                .Include(a => a.Stylist)
                .Where(a => a.Salon.Id == id)
                .ToList();
        }

        public List<Appointment> GetAppointmentsByStylist(int id)
        {
            return context.Appointments
               .Include(a => a.Salon)
               .Include(a => a.Schedule)
               .Include(a => a.Service)
               .Include(a => a.Customer)
               .Include(a => a.Stylist)
               .Where(a => a.Stylist.Id == id)
               .ToList();
        }

        public int GetAppointmentsCount()
        {
            return context.Appointments.Count();
        }

        public void RemoveAppointment(int id)
        {
            context.Appointments.Remove(GetAppointmentById(id));
            context.SaveChanges();
        }

        public void UpdateAppointment(int id, Appointment a)
        {
            Appointment appointment = GetAppointmentById(id);
            if (appointment == null)
            {
                return;
            }

            var trackedSalon = context.Salons.Local.FirstOrDefault(st => st.Id == a.Salon.Id) ?? context.Salons.Find(a.Salon.Id);
            if (trackedSalon == null)
            {
                context.Salons.Attach(a.Salon);
                appointment.Salon = a.Salon;
            }
            else
            {
                appointment.Salon = trackedSalon;
            }


            var trackedStylist = context.Stylists.Local.FirstOrDefault(st => st.Id == a.Stylist.Id) ?? context.Stylists.Find(a.Stylist.Id);
            if (trackedStylist == null)
            {
                context.Stylists.Attach(a.Stylist);
                appointment.Stylist = a.Stylist;
            }
            else
            {
                appointment.Stylist = trackedStylist;
            }

            var trackedSchedule = context.Schedules.Local.FirstOrDefault(st => st.Id == a.Schedule.Id) ?? context.Schedules.Find(a.Schedule.Id);
            if (trackedSchedule == null)
            {
                context.Schedules.Attach(a.Schedule);
                appointment.Schedule = a.Schedule;
            }
            else
            {
                appointment.Schedule = trackedSchedule;
            }

            var trackedCustomer = context.Customers.Local.FirstOrDefault(st => st.Id == a.Customer.Id) ?? context.Customers.Find(a.Customer.Id);
            if (trackedCustomer == null)
            {
                context.Customers.Attach(a.Customer);
                appointment.Customer = a.Customer;
            }
            else
            {
                appointment.Customer = trackedCustomer;
            }

            var trackedService = context.Services.Local.FirstOrDefault(st => st.Id == a.Service.Id) ?? context.Services.Find(a.Service.Id);
            if (trackedService == null)
            {
                context.Services.Attach(a.Service);
                appointment.Service = a.Service;
            }
            else
            {
                appointment.Service = trackedService;
            }

            context.SaveChanges();
        }

        public int GetAppointmentsBySalonsCount(List<Salon> salons)
        {
            int count = 0;
            foreach (var salon in salons)
            {
                count += GetAppointmentsBySalon(salon.Id).Count();
            }
            return count;
        }
    }
}
