using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MedicineSearchWebApp.Models
{
    public class MedecineADO
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
        public List<MedecineADO> medicineList { get; set; }
        public List<MedecineADO> getAllMedicine()
        {
            List<MedecineADO> dList = new List<MedecineADO>();
            SqlConnection connection = new SqlConnection("Data Source=AZ-MV-SQLSERVER;Initial Catalog=MedicineSearch_IP;Integrated Security=True");
            connection.Open();
            SqlCommand cmd = new SqlCommand("select * from medecine", connection);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                MedecineADO m = new MedecineADO();
                m.MedicineId = int.Parse(dr["MEDICINE_ID"].ToString());
                m.MedicineCategory = dr["MEDICINE_CATEGORY"].ToString(); 
                m.MedicineName = dr["MEDICINE_NAME"].ToString();
                m.MedicineEdate = DateTime.Parse(dr["MEDICINE_EDATE"].ToString());
                m.MedicineMdate = DateTime.Parse(dr["MEDICINE_MDATE"].ToString());
                m.MedicineDosage = int.Parse(dr["MEDICINE_DOSAGE"].ToString());
                m.MedicinePrice = (decimal)double.Parse(dr["MEDICINE_PRICE"].ToString());
                m.MedicineStock = int.Parse(dr["MEDICINE_STOCK"].ToString());
                m.ProviderId = int.Parse(dr["PROVIDER_ID"].ToString());
                dList.Add(m);
            }
            connection.Close();
            return dList;
        }
        public List<MedecineADO> getAllMedicineCategory()
        {
            List<MedecineADO> dList = new List<MedecineADO>();
            SqlConnection connection = new SqlConnection("Data Source=AZ-MV-SQLSERVER;Initial Catalog=MedicineSearch_IP;Integrated Security=True");
            connection.Open();
            SqlCommand cmd = new SqlCommand("select distinct MEDICINE_CATEGORY from medecine", connection);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                MedecineADO m = new MedecineADO();
                /*m.MedicineId = int.Parse(dr["MEDICINE_ID"].ToString());*/
                m.MedicineCategory = dr["MEDICINE_CATEGORY"].ToString();
                dList.Add(m);
            }
            connection.Close();
            return dList;
        }

        public List<MedecineADO> getAllMedicineByName(int id)
        {
            List<MedecineADO> dList = new List<MedecineADO>();
            SqlConnection connection = new SqlConnection("Data Source=AZ-MV-SQLSERVER;Initial Catalog=MedicineSearch_IP;Integrated Security=True");
            connection.Open();
            SqlCommand cmd = new SqlCommand("select * from medecine where MEDICINE_ID =" + id , connection);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                MedecineADO m = new MedecineADO();
                m.MedicineId = int.Parse(dr["MEDICINE_ID"].ToString());
                m.MedicineCategory = dr["MEDICINE_CATEGORY"].ToString();
                m.MedicineName = dr["MEDICINE_NAME"].ToString();
                m.MedicineEdate = DateTime.Parse(dr["MEDICINE_EDATE"].ToString());
                m.MedicineMdate = DateTime.Parse(dr["MEDICINE_MDATE"].ToString());
                m.MedicineDosage = int.Parse(dr["MEDICINE_DOSAGE"].ToString());
                m.MedicinePrice= (decimal)double.Parse(dr["MEDICINE_PRICE"].ToString());
                m.MedicineStock = int.Parse(dr["MEDICINE_STOCK"].ToString());
                m.ProviderId = int.Parse(dr["PROVIDER_ID"].ToString());
                dList.Add(m);
            }
            connection.Close();
            return dList;
        }
        public List<MedecineADO> getAllMedicineByCategory(string category)
        {
            List<MedecineADO> dList = new List<MedecineADO>();
            SqlConnection connection = new SqlConnection("Data Source=AZ-MV-SQLSERVER;Initial Catalog=MedicineSearch_IP;Integrated Security=True");
            connection.Open();
            SqlCommand cmd = new SqlCommand("select * from medecine where MEDICINE_CATEGORY=" + "'" + category + "'", connection);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                MedecineADO m = new MedecineADO();
                m.MedicineId = int.Parse(dr["MEDICINE_ID"].ToString());
                m.MedicineCategory = dr["MEDICINE_CATEGORY"].ToString();
                m.MedicineName = dr["MEDICINE_NAME"].ToString();
                m.MedicineEdate = DateTime.Parse(dr["MEDICINE_EDATE"].ToString());
                m.MedicineMdate = DateTime.Parse(dr["MEDICINE_MDATE"].ToString());
                m.MedicineDosage = int.Parse(dr["MEDICINE_DOSAGE"].ToString());
                m.MedicinePrice = (decimal)double.Parse(dr["MEDICINE_PRICE"].ToString());
                m.MedicineStock = int.Parse(dr["MEDICINE_STOCK"].ToString());
                m.ProviderId = int.Parse(dr["PROVIDER_ID"].ToString());
                dList.Add(m);
            }
            connection.Close();
            return dList;
        }
    }
}
