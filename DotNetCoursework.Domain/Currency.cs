using System;
using System.Collections.Generic;

namespace DotNetCoursework.Domain;

public partial class Currency
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Code { get; set; } = null!;

    public decimal CurrencyValue { get; set; }

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual ICollection<Price> Prices { get; set; } = new List<Price>();

    public override bool Equals(object? obj)
    {
        if (obj is Currency other)
        {
            return this.Name == other.Name &&
                this.Code == other.Code &&
                this.CurrencyValue == other.CurrencyValue;
        }
        return false;
    }
}
