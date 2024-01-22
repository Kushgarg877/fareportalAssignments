using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace flightbooking.Models;

public partial class Kushcustomer
{
    [Required(ErrorMessage ="Customer Name is Required")]
    public string? Custname { get; set; }

    [Required(ErrorMessage ="Customer Number is Required")]
    [StringLength(maximumLength:10, MinimumLength =10,ErrorMessage ="Phone No should be of exactly 10 digits")]
    public string? Custphno { get; set; }

    [Required(ErrorMessage ="Customer Address is Required")]
    public string? Custadr { get; set; }

    [Required(ErrorMessage ="Customer Id is Required")]
    [Range(minimum:1,maximum:1000)]
    public int Custid { get; set; }


    [Required(ErrorMessage ="Customer Password is Required")]
    public string? Custpwd { get; set; }

    public virtual ICollection<Kushbooking> Kushbookings { get; set; } = new List<Kushbooking>();

    public virtual ICollection<Kushbook> Kushbooks { get; set; } = new List<Kushbook>();

    public virtual ICollection<Kushflight> Kushflights { get; set; } = new List<Kushflight>();
}
