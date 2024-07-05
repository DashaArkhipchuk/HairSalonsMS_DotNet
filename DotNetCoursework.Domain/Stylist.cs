using System;
using System.Collections.Generic;

namespace DotNetCoursework.Domain;

public partial class Stylist
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? ContactPhone { get; set; }

    public string? ContactEmail { get; set; }

    public long UserId { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual ICollection<Price> Prices { get; set; } = new List<Price>();

    public virtual ICollection<SalonsStylist> SalonsStylists { get; set; } = new List<SalonsStylist>();

    public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();

    public virtual ICollection<Salon> Salons { get; set; } = new List<Salon>();

    public virtual User User { get; set; } = null!;

    public override string ToString()
    {
        return $"{FirstName} {LastName}";
    }
    public override bool Equals(object? obj)
    {
        if (obj is Stylist other)
        {
            return this.FirstName == other.FirstName &&
                this.LastName == other.LastName &&
                this.ContactPhone == other.ContactPhone &&
                this.ContactEmail == other.ContactEmail &&
                this.UserId == other.UserId;
        }
        return false;
    }
}
