using System;
using System.Collections.Generic;

namespace DemoVariant7.Model;

public partial class Manafacture
{
    public int IdManafacture { get; set; }

    public string ManafactureName { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
