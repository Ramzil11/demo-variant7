using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoVariant7.Model
{
   partial class Product
    {
        public string ImageProduct { get { return ProductPhoto != "" ? $"/Resources/{ProductPhoto}" : null; } }
        public string CostStyle { get { return ProductDiscountAmount > 0 ? $"Strikethrough" : "None"; } }
        public string GridStyle { get { return ProductDiscountAmount > 15 ? $"#7fff00" : "#ffffff"; } }
        public string ProductNewCost { get { return ProductDiscountAmount >0 ? (ProductCost - (ProductCost / 100 * ProductDiscountAmount)).ToString() : ""; } }
    }
}
