using System;
using System.Collections.Generic;

#nullable disable

namespace MedicineSearchWebApp.Models
{
    public partial class Medecine
    {
        public int MedicineId { get; set; }
        public int ProviderId { get; set; }
        public string MedicineName { get; set; }
        public string MedicineCategory { get; set; }
        public int MedicineDosage { get; set; }
        public DateTime MedicineMdate { get; set; }
        public DateTime MedicineEdate { get; set; }
        public int MedicineStock { get; set; }
        public decimal MedicinePrice { get; set; }

        public virtual Vendor Provider { get; set; }
    }
}
