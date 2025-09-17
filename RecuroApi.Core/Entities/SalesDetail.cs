using System;
using System.Collections.Generic;

namespace RecuroApi.Core.Entities;

public partial class SalesDetail
{
    public int DetailId { get; set; }

    public int SalesId { get; set; }

    public int ProductId { get; set; }

    public int Quantity { get; set; }

    public virtual ProductDetail Product { get; set; } = null!;

    public virtual Sale Sales { get; set; } = null!;
}
