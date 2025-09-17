using System;
using System.Collections.Generic;

namespace RecuroApi.Core.Entities;

public partial class EligibleEmployee
{
    public int Year { get; set; }

    public int EmployeeId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public decimal? EmployeeSales { get; set; }

    public decimal? DepartmentSales { get; set; }

    public decimal? BonusAmount { get; set; }
}
