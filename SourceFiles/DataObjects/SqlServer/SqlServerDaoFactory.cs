using System;
using System.Collections.Generic;
using System.Text;

namespace DoFactory.DataLayer.DataObjects.SqlServer
{
    /// <summary>
    /// Sql Server specific factory that creates Sql Server specific data access objects.
    /// 
    /// GoF Design Pattern: Factory.
    /// </summary>
    public class SqlServerDaoFactory : DaoFactory
    {
        
        public override IDoctorDao DoctorDao
        {
            get { return new SqlServerDoctorDao(); }
        }
        /// <summary>
        /// 
        /// </summary>
        public override IPatientDao PatientDao
        {
            get { return new SqlServerPatientDao(); }
        }
        /// <summary>
        /// 
        /// </summary>
        public override IAppointmentDao AppointmentDao
        {
            get { return new SqlServerAppoitmentDao(); }
        }
    }
}
