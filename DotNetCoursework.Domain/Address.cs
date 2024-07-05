using System;
using System.Collections.Generic;

namespace DotNetCoursework.Domain;

public partial class Address
{
    public int Id { get; set; }

    public int? SalonId { get; set; }

    public string Region { get; set; } = null!;

    public string? District { get; set; }

    public string City { get; set; } = null!;

    public string Street { get; set; } = null!;

    public virtual Salon? Salon { get; set; }

    public override string ToString()
    {
        return Region + "; " + District + "; " + City + "; " + Street;
    }
}
