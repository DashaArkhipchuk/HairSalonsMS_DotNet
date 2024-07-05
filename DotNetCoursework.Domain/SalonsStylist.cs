using System;
using System.Collections.Generic;

namespace DotNetCoursework.Domain;

public partial class SalonsStylist
{
    public int Id { get; set; }

    public int SalonId { get; set; }

    public int StylistId { get; set; }

    public virtual Salon Salon { get; set; } = null!;

    public virtual Stylist Stylist { get; set; } = null!;
}
