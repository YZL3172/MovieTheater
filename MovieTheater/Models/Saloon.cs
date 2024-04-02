using System;
using System.Collections.Generic;

namespace MovieTheater.Models;

public partial class Saloon
{
    public int Id { get; set; }

    public int? SaloonNo { get; set; }

    public int? Capacity { get; set; }

    public int? MovieId { get; set; }

    public virtual Movie? Movie { get; set; }
}
