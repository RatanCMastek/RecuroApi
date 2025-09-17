using System;
using System.Collections.Generic;

namespace RecuroApi.Core.Entities;

public partial class Sale
{
    public int SaleId { get; set; }

    public int SalesPersonId { get; set; }

    public DateOnly SaleDate { get; set; }

    public decimal SaleAmount { get; set; }

    public virtual ICollection<SalesDetail> SalesDetails { get; set; } = new List<SalesDetail>();

    public virtual Employee SalesPerson { get; set; } = null!;
}
