using System;
using System.Collections.Generic;

namespace RecuroApi.Core.Entities;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public int? ManagerId { get; set; }

    public int DepartmentId { get; set; }

    public virtual ICollection<EmployeeBonuse> EmployeeBonuses { get; set; } = new List<EmployeeBonuse>();

    public virtual ICollection<ManagerApproval> ManagerApprovals { get; set; } = new List<ManagerApproval>();

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
