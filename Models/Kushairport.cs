﻿using System;
using System.Collections.Generic;

namespace flightbooking.Models;

public partial class Kushairport
{
    public int Aid { get; set; }

    public string? Aname { get; set; }

    public string? Alocation { get; set; }

    public virtual ICollection<Kushflight> KushflightArrs { get; set; } = new List<Kushflight>();

    public virtual ICollection<Kushflight> KushflightDeps { get; set; } = new List<Kushflight>();
}
