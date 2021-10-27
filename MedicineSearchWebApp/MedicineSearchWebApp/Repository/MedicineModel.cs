using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using MedicineSearchWebApp.Models;
namespace MedicineSearchWebApp.Repository
{
    public class MedicineModel
    {
        public List<MedecineADO> _meds { get; set; }

        public List<MedecineADO> getAll()
        {
            List<MedecineADO> dList = new List<MedecineADO>();
            SqlConnection connection = new SqlConnection("Data Source=AZ-MV-SQLSERVER;Initial Catalog=MedicineSearch;Integrated Security=True");
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
        public MedecineADO find(int id)
        {
            List<MedecineADO> meds = getAll();
            var medicines = meds.Where(a => a.MedicineId == id).FirstOrDefault();
            return medicines;
        }
    }
}
