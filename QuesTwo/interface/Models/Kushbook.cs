using System;
using System.Collections.Generic;

namespace flightbooking.Models;

public partial class Kushbook
{
    public int Bookid { get; set; }

    public int? FlightsDid { get; set; }

    public int? Custoid { get; set; }

    public DateTime? Bookdate { get; set; }

    public virtual Kushcustomer? Custo { get; set; }

    public virtual Flightdetail? FlightsD { get; set; }
}
