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
    public class DoctorFacade
    {
        private IDoctorDao doctorDAO = DataAccess.DoctorDao;
        private IAppointmentDao apptDAO = DataAccess.AppointmentDao;

         /// <summary>
        /// Get a specific customer.
        /// Uses the Proxy Design Pattern.
        /// </summary>
        /// <param name="customerId">Unique customer identifier.</param>
        /// <returns>Requested customer.</returns>
        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataSet GetDoctor(string lastName)
        {
            // TODO: add access security here..
            // TODO: add argument validation here..

            // Retrieve Customer
            DataSet dt = doctorDAO.GetDoctor(lastName);

            // Assign a Proxy for Orders. Only when Orders are absolutely 
            // needed will they be retrieved from the database.
            // customer.Orders = new ProxyForOrders<Order>(customer);

            return dt;
        }

        /// <summary>
        /// Adds a new customer
        /// Uses the Decorator Design Pattern.
        /// </summary>
        /// <param name="customer">New Customer.</param>
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public void AddDoctor(Doctor doctor)
        {
            //string sql = string.Empty;
            // TODO: add security here..
            // TODO: add argument validation here..

            // Run within the context of a database transaction.
            // The Decorator Design Pattern.
            using (TransactionDecorator transaction = new TransactionDecorator())
            {
                doctorDAO.InsertDoctor(doctor);
                transaction.Complete();
                
            }
            apptDAO.calSetup(doctor.DoctorID);
        }
       


    }
}
