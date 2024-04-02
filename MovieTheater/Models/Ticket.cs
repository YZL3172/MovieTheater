using System;
using System.Collections.Generic;

namespace MovieTheater.Models;

public partial class Ticket
{
    public int Id { get; set; }

    public decimal Price { get; set; }

    public int SeatNumber { get; set; }
}
