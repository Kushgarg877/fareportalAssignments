using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Storage;

namespace flightbooking.Models;

public partial class Kushflight
{
    public int? Custid { get; set; }

    [Required(ErrorMessage ="Flight Id is Mandatory")]
    [Display(Name ="Flight Id")]
    public int FlightId { get; set; }

    public int? Depid { get; set; }

    public int? Arrid { get; set; }

    [DateType(DataType.DateTime)]
    [Display(Name ="Date of Departure")]
    public DateTime? Deptime { get; set; }

    [DateType(DataType.DateTime)]
    [Display(Name ="Date of Arrival")]
    public DateTime? Arrtime { get; set; }

    [Required(ErrorMessage ="Flight Name is Mandatory")]
    [Display(Name ="Flight Name")]
    public string? Flightname { get; set; }

    public virtual Kushairport? Arr { get; set; }

    public virtual Kushcustomer? Cust { get; set; }

    public virtual Kushairport? Dep { get; set; }

    public virtual ICollection<Kushbooking> Kushbookings { get; set; } = new List<Kushbooking>();
}

internal class DateTypeAttribute : Attribute
{
    private DataType dateTime;

    public DateTypeAttribute(DataType dateTime)
    {
        this.dateTime = dateTime;
    }
}