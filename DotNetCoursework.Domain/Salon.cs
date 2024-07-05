using System;
using System.Collections.Generic;

namespace DotNetCoursework.Domain;

public partial class Salon
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string? ContactPhone { get; set; }

    public string ContactEmail { get; set; } = null!;

    public virtual Address? Address { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual ICollection<SalonsManager> SalonsManagers { get; set; } = new List<SalonsManager>();

    public virtual ICollection<SalonsStylist> SalonsStylists { get; set; } = new List<SalonsStylist>();

    public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();

    public virtual ICollection<Manager> Managers { get; set; } = new List<Manager>();
    public virtual ICollection<Stylist> Stylists { get; set; } = new List<Stylist>();

    public override string ToString()
    {
        return Name;
    }

    public override bool Equals(object? obj)
    {
        if (obj is Salon other)
        {
            return this.Name == other.Name &&
                this.Description == other.Description &&
                this.ContactPhone == other.ContactPhone &&
                this.ContactEmail == other.ContactEmail;
        }
        return false;
    }
}
