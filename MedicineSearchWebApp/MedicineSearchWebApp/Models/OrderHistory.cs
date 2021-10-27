using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicineSearchWebApp.Models
{
    public class OrderHistory
    {
        public int OrderNo { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string MedicineName { get; set; }
        public int MedicineId { get; set; }
        public DateTime DateTime { get; set; }
        public int VendorId { get; set; }
        public int Quantity { get; set; }
        public decimal OrderAmount{ get; set; }

        public List<OrderHistory> lastOrder { get; set; }
    }
}
