using System;
using System.Collections.Generic;

namespace DemoVariant7.Model;

public partial class Product
{
    public string ProductArticleNumber { get; set; } = null!;

    public string ProductName { get; set; } = null!;

    public string ProductDescription { get; set; } = null!;

    public int ProductCategory { get; set; }

    public string? ProductPhoto { get; set; }

    public int ProductManufacturer { get; set; }

    public decimal ProductCost { get; set; }

    public int? ProductDiscountAmount { get; set; }

    public int ProductQuantityInStock { get; set; }

    public string? ProductStatus { get; set; }

    public int? ProductSupplier { get; set; }

    public string? ProductUint { get; set; }

    public int? ProductMaxSell { get; set; }

    public virtual Category ProductCategoryNavigation { get; set; } = null!;

    public virtual Manafacture ProductManufacturerNavigation { get; set; } = null!;

    public virtual Supplier? ProductSupplierNavigation { get; set; }
}
