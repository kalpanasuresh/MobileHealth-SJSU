using System;
using System.Collections.Generic;
using System.Text;

namespace DoFactory.DataLayer.DataObjects
{
    
    public abstract class DaoFactory
    {
        
        public abstract IDoctorDao DoctorDao { get; }
        public abstract IPatientDao PatientDao { get; }
        public abstract IAppointmentDao AppointmentDao { get; }
    }
}
