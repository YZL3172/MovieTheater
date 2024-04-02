using System;
using System.Collections.Generic;

namespace MovieTheater.Models;

public partial class Session
{
    public int Id { get; set; }

    public DateTime? SessionTime { get; set; }

    public int? MovieId { get; set; }

    public int? WeekId { get; set; }

    public int? SaloonId { get; set; }

    public int? TicketId { get; set; }

    public virtual Movie? Movie { get; set; }

    public virtual Saloon? Saloon { get; set; }

    public virtual Ticket? Ticket { get; set; }

    public virtual Week? Week { get; set; }
}
