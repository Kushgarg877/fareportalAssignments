using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace flightbooking.Models;

public partial class Kushflight
{
    public int? Custid { get; set; }

    [Key]
    public int FlightId { get; set; }

    public int? Depid { get; set; }

    public int? Arrid { get; set; }

    public DateTime? Deptime { get; set; }

    public DateTime? Arrtime { get; set; }

    public string? Flightname { get; set; }

    public virtual Kushairport? Arr { get; set; }

    public virtual Kushcustomer? Cust { get; set; }

    public virtual Kushairport? Dep { get; set; }

    public virtual ICollection<Kushbooking> Kushbookings { get; set; } = new List<Kushbooking>();
}
