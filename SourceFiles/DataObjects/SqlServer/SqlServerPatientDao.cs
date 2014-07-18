using System;
using System.Collections.Generic;
using System.Text;
using DoFactory.DataLayer.DataObjects;
using DoFactory.BusinessLayer.BusinessObjects;
using System.Data;

namespace DoFactory.DataLayer.DataObjects.SqlServer
{
   public class SqlServerPatientDao:IPatientDao
    {
       

        public IList<Patient> GetPatients()
        {
            string sortExpression = null;
            return GetPatients(sortExpression);
        }

        public IList<Patient> GetPatients(string sortExpression)
        {

            string strSQL = "SELECT Patient.* FROM Patient";



            DataTable dt = Db.GetDataTable(strSQL);

            IList<Patient> list = new List<Patient>();
            foreach (DataRow row in dt.Rows)
            {
                int id = int.Parse(row["PatientID"].ToString());
                string fname = row["FirstName"].ToString();
                string lname = row["LastName"].ToString();
                string phone = row["phone"].ToString();

                list.Add(new Patient(id, fname, lname, phone));
            }
            return list;
        }
/// <summary>
/// 
/// </summary>
/// <param name="PatientID"></param>
/// <returns></returns>
        public string GetPatient(int PatientID)
        {
            string strSQL = "SELECT FirstName +' ' + LastName as Name FROM Patient where PatientID="+PatientID;



            return Convert.ToString(Db.GetScalar(strSQL));
        }
       public int PatientUserExists(string user)
       {
           string strSQL = "SELECT count(*) FROM Patient WHERE     (userId ='"+user+")";
           return Convert.ToInt32(Db.GetScalar(strSQL));
       }
       public int PatientLoginCheck(string user, string pass)
       {

           string strSQL = " SELECT PatientID FROM Patient WHERE (password ='" + pass + "') AND (userId = '" + user + "')";
           return Convert.ToInt32(Db.GetScalar(strSQL));
       }
       /// <summary>
       /// 
       /// </summary>
       /// <param name="patient"></param>
       public void InsertPatient(Patient patient)
       {
           StringBuilder sql = new StringBuilder();
           sql.Append("INSERT INTO [HealthCare].[dbo].[Patient]([FirstName],[LastName],[dateBirth]");
           sql.Append(" ,[strEmail]  ,[Address] ,[city],[state] ,[zip] ,[Insurance] ,[locOfPolicy]");
           sql.Append("  ,[Gender],[phone],[userId],[password],[secQues],[secAns] ,[provider])");
           sql.Append("  VALUES( '" + patient.fName + "', '");
           sql.Append(patient.LName + "', '");
           sql.Append(patient.dOBirth + "', '");
           sql.Append(patient.Email + "','");
           sql.Append(patient.Address + "','");
           sql.Append(patient.City + "','");
           sql.Append(patient.State + "','");
           sql.Append(patient.zip + "','");
           sql.Append(patient.InsurName + "','");
           sql.Append(patient.LocationOfPolicy + "','");
           sql.Append(patient.gender + "', '");
           sql.Append(patient.Phone + "', '");
           sql.Append(patient.UserID + "', '");
           sql.Append(patient.Pass + "', '");
           sql.Append(patient.SecQues + "', '");
           sql.Append(patient.SecAns + "', '");
           sql.Append(patient.Provider + "') ");
 
           // Assign new customer Id back to business object
           int id = Db.Insert(sql.ToString(), true);
          patient.PatientID = id;
           //return sql.ToString();
       }

   

    }
}
