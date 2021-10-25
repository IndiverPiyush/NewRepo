using System;
using System.Collections.Generic;

#nullable disable

namespace MedicineSearchWebApp.Models
{
    public partial class Customer
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserMobile { get; set; }
        public string UserEmail { get; set; }
        public string UserArea { get; set; }
        public string UserCity { get; set; }
        public decimal UserWalletbal { get; set; }
        public string UserPassword { get; set; }
        public string AllergicTo { get; set; }
    }
}
