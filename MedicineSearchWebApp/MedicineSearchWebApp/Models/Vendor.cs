using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        [Display(Name = "Organisation Name")]
        public string VendorOrgName { get; set; }
        [Display(Name = "Area")]
        public string VendorArea { get; set; }
        [Display(Name = "City")]
        public string VendorCity { get; set; }
        [Display(Name = "Mobile No")]
        public string VendorMobile { get; set; }
        [Display(Name = "Wallet Balance")]
        public decimal VendorWallet { get; set; }
        public string VendorPassword { get; set; }
        [Display(Name = "Speciality")]
        public string VendorSpeciality { get; set; }

        public virtual ICollection<Medecine> Medecines { get; set; }
    }
}
