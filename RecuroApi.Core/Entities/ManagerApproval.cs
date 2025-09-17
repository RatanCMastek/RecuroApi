using System;
using System.Collections.Generic;

namespace RecuroApi.Core.Entities;

public partial class ManagerApproval
{
    public int ApprovalId { get; set; }

    public int ManagerId { get; set; }

    public int ApprovalYear { get; set; }

    public int ApprovalMonth { get; set; }

    public string ApprovalStatus { get; set; } = null!;

    public virtual Employee Manager { get; set; } = null!;
}
