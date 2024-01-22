using System;
using System.Collections.Generic;

namespace flightbooking.Models;

public partial class Flightdetail
{
    public int FlightDid { get; set; }

    public string? Source { get; set; }

    public string? Destination { get; set; }

    public DateTime? Departure { get; set; }

    public int? Price { get; set; }

    public virtual ICollection<Kushbook> Kushbooks { get; set; } = new List<Kushbook>();
}
