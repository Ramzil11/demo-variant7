using System;
using System.Collections.Generic;

namespace DemoVariant7.Model;

public partial class Pickuppoint
{
    public int IdPickupPoint { get; set; }

    public string? City { get; set; }

    public string? Street { get; set; }

    public int? Home { get; set; }

    public int? Index { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
