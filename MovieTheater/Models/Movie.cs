using System;
using System.Collections.Generic;

namespace MovieTheater.Models;

public partial class Movie
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public byte Duration { get; set; }

    public int? Rating { get; set; }

    public int? GenreId { get; set; }

    public virtual Genre? Genre { get; set; }

    public virtual ICollection<Saloon> Saloons { get; set; } = new List<Saloon>();
}
