using System;
using System.Collections.Generic;

namespace RecuroApi.Core.Entities;

public partial class TopEmployeeOfYear
{
    public int Year { get; set; }

    public int EmployeeId { get; set; }

    public decimal? EmployeeSales { get; set; }
}
