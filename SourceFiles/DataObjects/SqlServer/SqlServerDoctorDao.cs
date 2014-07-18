using System;
using System.Collections.Generic;
using System.Text;
using DoFactory.DataLayer.DataObjects;
using DoFactory.BusinessLayer.BusinessObjects;
using System.Data;

namespace DoFactory.DataLayer.DataObjects.SqlServer
{
   public class SqlServerDoctorDao:IDoctorDao
    {
       

     

        
/// <summary>
/// 
/// </summary>
/// <param name="PatientID"></param>
/// <returns></returns>
        public DataSet GetDoctor(string lName)
        {
            
                 DataSet dsDoctors = new DataSet();
           // IList<Doctor> list=new List<Doctor>();
                // Get Doctors that match last name
                dsDoctors = Db.SelectLike(lName);

                //foreach (DataRow row in dsDoctors.Rows)
                //{
                //    list.Add(new Doctor(Convert.ToInt32(row["DocID"].ToString()),row["FirstName"].ToString(),row["LastName"].ToString()));
                //}
                return dsDoctors;
        }
       /// <summary>
       /// 
       /// </summary>
       /// <param name="patient"></param>
       public void InsertDoctor(Doctor doc)
       {
           StringBuilder sql = new StringBuilder();

            sql.Append("  INSERT INTO [HealthCare].[dbo].[Doctor] ([signInName],[password],[secQues] ,[secAns],[LicType],[Title] ");
           sql.Append(" ,[FirstName],[LastName] ,[dateBirth] ,[Gender],[Email],[zip],[NationalProviderID],[PrimarySpl] ,[OffAddr] ");
           sql.Append(",[City] ,[State] ,[phone]) ");
           sql.Append("  VALUES( '" + doc.UserID + "', '");
           sql.Append(doc.Password + "', '");
           sql.Append(doc.SecQues + "', '");
           sql.Append(doc.SecAns + "', '");
           sql.Append(doc.License_Type + "','");
           sql.Append(doc.Title + "','");
           sql.Append(doc.fName + "', '");
           sql.Append(doc.LName + "', '");
            sql.Append(doc.DateOfBirth + "','");
           sql.Append(doc.gender + "','");
           sql.Append(doc.email + "', '");
           sql.Append(doc.zip + "', '");
            sql.Append(doc.National_PrvID + "','");
           sql.Append(doc.Primary_spl+ "','");
           sql.Append(doc.officeAdr + "', '");
           sql.Append(doc.City + "', '");
           sql.Append(doc.State + "', '");
           sql.Append(doc.Phone + "') ");

 
           // Assign new customer Id back to business object
           int id = Db.Insert(sql.ToString(), true);
          doc.DoctorID = id;
           //return sql.ToString();
       }





     
   }
}
