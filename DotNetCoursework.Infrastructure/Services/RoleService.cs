using DotNetCoursework.Domain;
using DotNetCoursework.Infrastructure.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetCoursework.Infrastructure.Services
{
    public class RoleService
    {
        private SalonsDbContext context = new SalonsDbContext();


        public Role? GetRoleById(int id)
        {
            return context.Roles.Where(r => r.Id == id).FirstOrDefault();
        }
    }
}
