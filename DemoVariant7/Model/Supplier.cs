﻿using System;
using System.Collections.Generic;

namespace DemoVariant7.Model;

public partial class Supplier
{
    public int IdSupplier { get; set; }

    public string SupplierName { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
