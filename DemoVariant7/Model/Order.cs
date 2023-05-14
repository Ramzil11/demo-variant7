using System;
using System.Collections.Generic;

namespace DemoVariant7.Model;

public partial class Order
{
    public int OrderId { get; set; }

    public string OrderStatus { get; set; } = null!;

    public DateOnly OrderDeliveryDate { get; set; }

    public int OrderPickupPoint { get; set; }

    public DateOnly? OrderDate { get; set; }

    public int? OrderCode { get; set; }

    public int? Fio { get; set; }

    public virtual User? FioNavigation { get; set; }

    public virtual Pickuppoint OrderPickupPointNavigation { get; set; } = null!;
}
