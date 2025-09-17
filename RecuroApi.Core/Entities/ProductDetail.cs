using System;
using System.Collections.Generic;

namespace RecuroApi.Core.Entities;

public partial class ProductDetail
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public virtual ICollection<SalesDetail> SalesDetails { get; set; } = new List<SalesDetail>();
}
