using System;
using System.Collections.Generic;

namespace MovieTheater.Models;

public partial class Week
{
    public int Id { get; set; }

    public int? Week1 { get; set; }

    public string? WeekFirstDay { get; set; }

    public string? WeekLastDay { get; set; }
}
