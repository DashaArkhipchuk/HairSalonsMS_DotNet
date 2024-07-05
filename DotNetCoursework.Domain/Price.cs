using System;
using System.Collections.Generic;

namespace DotNetCoursework.Domain;

public partial class Price
{
    public int Id { get; set; }

    public int StylistId { get; set; }

    public int? CurrencyId { get; set; }

    public decimal Value { get; set; }

    public virtual Currency? Currency { get; set; }

    public virtual ICollection<Service> Services { get; set; } = new List<Service>();

    public virtual Stylist Stylist { get; set; } = null!;

    public override bool Equals(object? obj)
    {
        if (obj is Price other)
        {
            return this.Stylist == other.Stylist &&
                this.Value == other.Value &&
                this.Currency == other.Currency;
        }
        return false;
    }
}
