using System;
using System.Collections.Generic;

namespace RecuroApi.Core.Entities;

public partial class EmployeeBonuse
{
    public int BonusId { get; set; }

    public int EmployeeId { get; set; }

    public int BonusYear { get; set; }

    public decimal BonusAmount { get; set; }

    public DateTime CreatedDate { get; set; }

    public virtual Employee Employee { get; set; } = null!;
}
