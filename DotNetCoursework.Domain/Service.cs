using System;
using System.Collections.Generic;

namespace DotNetCoursework.Domain;

public partial class Service
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public int? PriceId { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual Price? Price { get; set; }

    public override string ToString()
    {
        return Name;
    }

    public override bool Equals(object? obj)
    {
        if (obj is Service other)
        {
            return this.Name == other.Name &&
                this.Description == other.Description &&
                this.Price == other.Price;
        }
        return false;
    }
}
