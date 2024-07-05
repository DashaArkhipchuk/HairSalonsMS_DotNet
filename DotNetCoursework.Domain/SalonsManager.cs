using System;
using System.Collections.Generic;

namespace DotNetCoursework.Domain;

public partial class SalonsManager
{
    public int Id { get; set; }

    public int SalonId { get; set; }

    public int ManagerId { get; set; }

    public virtual Manager Manager { get; set; } = null!;

    public virtual Salon Salon { get; set; } = null!;
}
