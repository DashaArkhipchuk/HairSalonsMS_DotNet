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
    public class CustomerService
    {
        private SalonsDbContext context = new SalonsDbContext();

        public Customer? GetCustomerById(int id)
        {
            return context.Customers
                .Where(c=>c.Id == id).FirstOrDefault();
        }

        public List<Customer> GetCustomers()
        {
            return context.Customers
                .ToList();
        }

    }
}
