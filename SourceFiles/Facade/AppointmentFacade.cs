using System;
using System.Collections.Generic;
using System.Text;
using DoFactory.DataLayer.DataObjects;
using System.ComponentModel;
using DoFactory.BusinessLayer.BusinessObjects;
using DoFactory.Framework.Transactions;
using System.Data;

namespace Facade
{
    public class AppointmentFacade
    {
        private IAppointmentDao AppointmentDAO = DataAccess.AppointmentDao;

     
        //public int CheckAppointment(Appointment appt)
        //{
        //    int count = AppointmentDAO.CheckAppointment(appt);
        //   return count;
        //}
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public void AddStudentAppointment(int PatientID, int DoctorID, DateTime date, string[] strSet, int TimeID)
        {
            //string sql = string.Empty;
            // TODO: add security here..
            // TODO: add argument validation here..

            // Run within the context of a database transaction.
            // The Decorator Design Pattern.
            using (TransactionDecorator transaction = new TransactionDecorator())
            {
                AppointmentDAO.StudentSchedule(PatientID, DoctorID, date, strSet, TimeID);
                transaction.Complete();

            }
        }
        [DataObjectMethod(DataObjectMethodType.Update)]
        public void UpdateDoctorAppointment(Appointment appt, int dayID)
        {
            //string sql = string.Empty;
            // TODO: add security here..
            // TODO: add argument validation here..

            // Run within the context of a database transaction.
            // The Decorator Design Pattern.
            using (TransactionDecorator transaction = new TransactionDecorator())
            {
                AppointmentDAO.DocSchedule(appt,dayID);
                transaction.Complete();

            }
        }

        public DataSet GetDocSchedule(DateTime date, int DocID)
        {
            return AppointmentDAO.GetSchedule(date, DocID);
        }
      


    }
}
