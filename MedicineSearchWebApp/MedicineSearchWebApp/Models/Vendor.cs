using System;
using System.Collections.Generic;

#nullable disable

namespace MedicineSearchWebApp.Models
{
    public partial class Vendor
    {
        public Vendor()
        {
            Medecines = new HashSet<Medecine>();
        }

        public int VendorId { get; set; }
        public string VendorOrgName { get; set; }
        public string VendorArea { get; set; }
        public string VendorCity { get; set; }
        public string VendorMobile { get; set; }
        public decimal VendorWallet { get; set; }
        public string VendorPassword { get; set; }
        public string VendorSpeciality { get; set; }

        public virtual ICollection<Medecine> Medecines { get; set; }
    }
}
