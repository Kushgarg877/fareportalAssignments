using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace flightbooking.Models;

public partial class Kushcustomer
{
    [Required(ErrorMessage ="Customer Name is Mandatory")]
    [Display(Name ="Customer Name")]
    public string? Custname { get; set; }

    [StringLength(maximumLength:10,MinimumLength =10,ErrorMessage ="Phone no should be of 10 digits only")]
    [Display(Name ="Phone Number")]
    public string? Custphno { get; set; }

    [Display(Name ="Address")]
    public string? Custadr { get; set; }

    [Required(ErrorMessage ="Customer ID should be unique")]
    [Display(Name ="Create Customer ID")]
    public int Custid { get; set; }

    [Required(ErrorMessage ="Password is Mandatory")]
    [Display(Name ="Password")]
    public string? Custpwd { get; set; }

    [NotMapped]
    [Compare("Custpwd",ErrorMessage ="Passwords do not match")]
    [Display(Name ="Confirm Password")]
    public string? ConfirmPwd { get; set;}
    public virtual ICollection<Kushbooking> Kushbookings { get; set; } = new List<Kushbooking>();

    public virtual ICollection<Kushflight> Kushflights { get; set; } = new List<Kushflight>();
}
