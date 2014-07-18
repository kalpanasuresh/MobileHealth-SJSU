using System;
using System.Collections.Generic;
using System.Text;
using DoFactory.BusinessLayer.BusinessObjects;
using System.Data;

namespace DoFactory.DataLayer.DataObjects
{
    public interface IAppointmentDao
    {
        void calSetup(int docID);
        void DocSchedule(Appointment appt,int dayID);
        DataSet GetSchedule(DateTime dateDayToLoad, int DocID);
        void StudentSchedule(int PatientID, int DoctorID, DateTime date, string[] strSet,int TimeID);
    }
}
