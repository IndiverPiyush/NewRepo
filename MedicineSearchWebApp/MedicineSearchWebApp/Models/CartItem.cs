using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MedicineSearchWebApp.Models;
namespace MedicineSearchWebApp.Models
{
    public class CartItem
    {
        [Key]
        public string MedicineId { get; set; }
        public string CartId { get; set; }
        public string MedicineName { get; set; }
        public int MedicineQuntity { get; set; }
        public System.DateTime DateCreated { get; set; }
        public virtual  Medecine Medicine { get; set; }
    }
}
