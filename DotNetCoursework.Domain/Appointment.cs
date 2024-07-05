using System;
using System.Collections.Generic;

namespace DotNetCoursework.Domain;

public partial class Appointment
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public int ServiceId { get; set; }

    public int StylistId { get; set; }

    public int SalonId { get; set; }

    public int ScheduleId { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual Salon Salon { get; set; } = null!;

    public virtual Schedule Schedule { get; set; } = null!;

    public virtual Service Service { get; set; } = null!;

    public virtual Stylist Stylist { get; set; } = null!;
}
