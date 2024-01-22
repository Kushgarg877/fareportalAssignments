using System;
using System.Collections.Generic;

namespace flightbooking.Models;

public partial class Kushbooking
{
    public int Bookid { get; set; }

    public int? Flightid { get; set; }

    public int? Custid { get; set; }

    public DateTime? Bookdate { get; set; }

    public virtual Kushcustomer? Cust { get; set; }

    public virtual  Kushflight? Flight { get; set; }
}
