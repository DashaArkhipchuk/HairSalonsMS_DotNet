using System;
using System.Collections.Generic;

namespace DotNetCoursework.Domain;

public partial class Payment
{
    public int Id { get; set; }

    public int CurrencyId { get; set; }

    public int CustomerId { get; set; }

    public int ServiceId { get; set; }

    public int StylistId { get; set; }

    public decimal PaymentValue { get; set; }

    public virtual Currency Currency { get; set; } = null!;

    public virtual Customer Customer { get; set; } = null!;

    public virtual Service Service { get; set; } = null!;

    public virtual Stylist Stylist { get; set; } = null!;
}
