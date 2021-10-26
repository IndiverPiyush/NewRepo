using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace MedicineSearchWebApp.Models
{
    public partial class Customer
    {
        public int UserId { get; set; }
        [Display(Name = "Name")]
        public string UserName { get; set; }
        [Display(Name = "Mobile No")]
        public string UserMobile { get; set; }
        [Display(Name = "Email Id")]
        public string UserEmail { get; set; }
        [Display(Name = "Area")]
        public string UserArea { get; set; }
        [Display(Name = "City")]
        public string UserCity { get; set; }
        [Display(Name = "Wallet Balance")]
        public decimal UserWalletbal { get; set; }
        public string UserPassword { get; set; }
        [Display(Name = "Allergic To")]
        public string AllergicTo { get; set; }
    }
}
