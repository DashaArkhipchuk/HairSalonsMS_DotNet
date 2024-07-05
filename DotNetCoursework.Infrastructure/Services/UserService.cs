using DotNetCoursework.Infrastructure.DAL;
using DotNetCoursework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DotNetCoursework.Infrastructure.Services
{
    public class UserService
    {
        private SalonsDbContext context = new SalonsDbContext();

        public User? GetUserByEmail(string email)
        {
            return context.Users
                .Include(u=>u.Role)
                .Include(u=>u.Customer)
                .Include(u=>u.Stylist)
                    .ThenInclude(u=>u.Salons)
                .Include(u=>u.Manager)
                    .ThenInclude(u=>u.Salons)
                .Where(u => u.Email == email).FirstOrDefault();
        }

        public bool IsEmailInUse(string email)
        {
            return GetUserByEmail(email) != null;
        }

        public void AddUser(User user)
        {
            if (context.Entry(user.Role).State == EntityState.Detached)
            {
                context.Roles.Attach(user.Role);
            }

            context.Users.Add(user);
            context.SaveChanges();
        }
    }
}
