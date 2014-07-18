using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace DoFactory.DataLayer.DataObjects
{
   
    public static class DataAccess
    {
          private static readonly string dataProvider = ConfigurationManager.AppSettings.Get("DataProvider");
        private static readonly DaoFactory factory = DaoFactories.GetFactory(dataProvider);

           public static IDoctorDao DoctorDao
        {
            get { return factory.DoctorDao; }
        }
        public static IPatientDao PatientDao
        {
            get { return factory.PatientDao; }
        }
        public static IAppointmentDao AppointmentDao
        {
            get { return factory.AppointmentDao; }
        }
    }
}
