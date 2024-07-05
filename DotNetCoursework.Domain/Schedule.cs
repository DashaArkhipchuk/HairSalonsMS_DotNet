using System;
using System.Collections.Generic;

namespace DotNetCoursework.Domain;

public partial class Schedule
{
    public int Id { get; set; }

    public int SalonId { get; set; }

    public int StylistId { get; set; }

    public DateOnly Date { get; set; }

    public int StartHour { get; set; }

    public int EndHour { get; set; }

    public virtual Appointment? Appointment { get; set; }

    public virtual Salon Salon { get; set; } = null!;

    public virtual Stylist Stylist { get; set; } = null!;

    public override string ToString()
    {
        return $"{Date} {StartHour}-{EndHour} {Salon} {Stylist}";
    }

    public override bool Equals(object? obj)
    {
        if (obj is Schedule other)
        {
            return this.Date == other.Date &&
                this.Salon.Name == other.Salon.Name &&
                this.Stylist.FirstName == other.Stylist.FirstName &&
                this.Stylist.LastName == other.Stylist.LastName &&
                this.StartHour == other.StartHour &&
                this.EndHour == other.EndHour;
        }
        return false;
    }
}
