using System;
using System.Collections.Generic;
using System.Text;
using DoFactory.DataLayer.DataObjects;
using DoFactory.BusinessLayer.BusinessObjects;
using System.Data;

namespace DoFactory.DataLayer.DataObjects.SqlServer
{
   public class SqlServerAppoitmentDao:IAppointmentDao
    {

       



       public void calSetup(int docID)
       {
           	
				string[] strSelect = new string[1] {"Day_ID"};
				string[] strWhere = new string[2] {"Doctor_ID", docID.ToString()};
												
				int intDaysInYear;
				int intDayID = 99999;
                DataTable dsDayID = new DataTable();
				// Get all Day_ID's for doctor
				dsDayID = Db.SelectQuery("DDT", strSelect, strWhere);

                // Get first Day_ID
                
				for (int x = 0; x < dsDayID.Rows.Count; ++x)
				{
					if (Convert.ToInt32(dsDayID.Rows[x][0]) < intDayID)
					{
						intDayID = Convert.ToInt32(dsDayID.Rows[x][0]);
					}
				}

				
				strSelect = new string[2] {"Month_Number", "Day_Number"};
				strWhere = new string[2] {"Day_ID", intDayID.ToString()};				
				dsDayID = new DataTable();
				
				// Get date for first Day ID
				dsDayID = Db.SelectQuery("DDT", strSelect, strWhere);
                
				// Get day of week for first Day ID
				string strDayofWeek = System.DateTime.Parse(dsDayID.Rows[0][0].ToString() +"/" + dsDayID.Rows[0][1].ToString() + "/" + System.DateTime.Now.Year.ToString() + " 00:00:00").DayOfWeek.ToString();
                
				// Determine if year is leap year
				if (System.DateTime.IsLeapYear(System.DateTime.Now.Year))
				{
					intDaysInYear = 366;
				}
				else
				{
					intDaysInYear = 365;
				}
                
				string[] strSet;
				string[] strSet1;                
				// Fill doctor calendar
				for (int x = intDayID; x < intDayID + intDaysInYear ; ++x)
				{
				strWhere = new string[2] {"Day_ID", x.ToString()};					

				strSet = new string[38] {"AM_0800","'Yes'", "AM_0830", "'Yes'", "AM_0900", "'Yes'", "AM_0930", "'Yes'", "AM_1000", "'Yes'", "AM_1030", "'Yes'", "AM_1100", "'Yes'", "AM_1130", "'Yes'", "PM_1200", "'Yes'", "PM_1230", "'Yes'", "PM_0100", "'Yes'", "PM_0130", "'Yes'", "PM_0200", "'Yes'", "PM_0230", "'Yes'", "PM_0300", "'Yes'", "PM_0330", "'Yes'", "PM_0400", "'Yes'", "PM_0430", "'Yes'", "PM_0500", "'Yes'"};							
				strSet1 = new string[2] {"Day_Name", "'" + strDayofWeek + "'"};
                
				// Update Time Data
			    Db.UpdateQuery("TDT", strSet, strWhere);
				// Update Day Data
				Db.UpdateQuery("DDT", strSet1, strWhere);						
				}
				
       }
              public void DocSchedule(Appointment appt,int dayID)
       {         
         
              string[] strSet = new string[38] { "AM_0800", "'" + appt.AM8 + "'", "AM_0830", "'" + appt.AM830 + "'", "AM_0900", "'" +appt.AM9 + "'", "AM_0930", "'" +appt.AM930 + "'", "AM_1000", "'" +appt.AM10 + "'", "AM_1030", "'" + appt.AM1030 + "'", "AM_1100", "'" + appt.AM11 + "'", "AM_1130", "'" + appt.AM1130+ "'", "PM_1200", "'" + appt.PM12 + "'", "PM_1230", "'" + appt.PM1230 + "'", "PM_0100", "'" + appt.PM0100 + "'", "PM_0130", "'" + appt.PM0130 + "'", "PM_0200", "'" + appt.PM0200 + "'", "PM_0230", "'" + appt.PM0230 + "'", "PM_0300", "'" + appt.PM0300 + "'", "PM_0330", "'" +appt.PM0330+ "'", "PM_0400", "'" + appt.PM0400 + "'", "PM_0430", "'" + appt.PM0430 + "'", "PM_0500", "'" + appt.PM0500 + "'" };
              string[] strWhere = new string[2] { "Day_ID", dayID.ToString() };
              Db.UpdateQuery("TDT", strSet, strWhere);

          
       }
             
       public void StudentSchedule(int PatientID, int DoctorID, DateTime date,string[] strset1, int TimeID)
       {
           
           DataTable dsDay = new DataTable();
        
           string[] strSelect;
           string[] strSet = new string[2];
           string[] strWhere;
           string[] strFields;
           string[] strValues;

           strSelect = new string[1] { "Day_ID" };
           strWhere = new string[6] { "Day_Number", date.Day.ToString(), "Month_Number", date.Month.ToString(), "Doctor_ID", DoctorID.ToString() };

           // Get Day ID
           dsDay = Db.SelectQuery("DDT", strSelect, strWhere);       

                        
               strWhere = new string[2] { "Day_ID", dsDay.Rows[0][0].ToString() };

               // Update Time Data Table
               Db.UpdateQuery("TDT", strset1, strWhere);

               strFields = new string[4] { "Patient_ID", "Day_ID", "Time_ID", "Doctor_ID" };
               strValues = new string[4] { PatientID.ToString(), dsDay.Rows[0][0].ToString(), Convert.ToString(TimeID + 1), DoctorID.ToString() };

               // Insert appointment
               Db.InsertQuery("PAT", strFields, strValues);
           
       }
       public DataSet GetSchedule(DateTime dateDayToLoad,int DocID)
       {
          int intDay = dateDayToLoad.Day;
          int intMonth = dateDayToLoad.Month;
          string[] strSelect;
          string[] strWhere;
          DataSet dsSchedule = new DataSet();
          DataTable dsDay = new DataTable();           


               strSelect = new string[2] { "Day_ID", "Day_Name" };
               strWhere = new string[6] { "Day_Number", intDay.ToString(), "Month_Number", intMonth.ToString(), "Doctor_ID", DocID.ToString() };

               // Get day info
               dsDay = Db.SelectQuery("DDT", strSelect, strWhere);
               dsSchedule.Tables.Add(dsDay);
               // Show day on schedule

               strSelect = new string[1] { "" };
               strWhere = new string[2] { "Day_ID", dsDay.Rows[0][0].ToString() };

               // Get schedule
               dsDay = new DataTable();
               dsDay = Db.SelectQuery("TDT", strSelect, strWhere);
               dsSchedule.Tables.Add(dsDay);
              
           
           return dsSchedule;
       }


       //public int CheckAppointment(Appointment appt)
       //{

       //    StringBuilder sql = new StringBuilder();
       //    sql.Append("spCheckAppointment ");
       //    sql.Append(appt.PatientID + ",");
       //    sql.Append(appt.DoctorID + ",'");
       //    sql.Append(appt.Start + "','");
       //    sql.Append(appt.End + "'");
       //    int k = Convert.ToInt32(Db.GetScalar1(sql.ToString()));
       //    return k;
       //}
       //public void InsertAppointment(Appointment appt)
       //{
       //    StringBuilder sql = new StringBuilder();

       //    sql.Append(" INSERT INTO [HealthCare].dbo.Appointment (PatientID, DoctorID, Start, End,Location,Notes) ");
       //    sql.Append("  VALUES( '" + appt.PatientID + "', '");
       //    sql.Append(appt.DoctorID+ "', '");
       //    sql.Append(appt.Start + "', '");
       //    sql.Append(appt.End + "', '");
       //    sql.Append(appt.Location + "', '");
       //    sql.Append(appt.note  + "') ");

       //    // Assign new customer Id back to business object
       //    int id = Db.Insert(sql.ToString(), true);

       //    appt.ApptID = id;
           
       //}


   }
}
