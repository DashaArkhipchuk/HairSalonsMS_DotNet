using DotNetCoursework.Domain;
using DotNetCoursework.Infrastructure.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetCoursework.Infrastructure.Services
{
    public class AddressService
    {
        private SalonsDbContext context = new SalonsDbContext();

        public void AddAddress(Address a)
        {
            context.Addresses.Add(a);
            context.SaveChanges();
        }

        public List<Address> GetAddressesNotOccupied()
        {
            return context.Addresses.Where(a => a.SalonId == null).ToList();
        }

       
    }
}
