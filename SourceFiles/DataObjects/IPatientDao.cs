using System;
using System.Collections.Generic;
using System.Text;
using DoFactory.BusinessLayer.BusinessObjects;

namespace DoFactory.DataLayer.DataObjects
{
    public interface IPatientDao
    {       
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IList<Patient> GetPatients();

        /// <summary>
        /// Gets a sorted list of all customers.
        /// </summary>
        /// <param name="sortExpression">Sort order.</param>
        /// <returns>Sorted list of customers.</returns>
        IList<Patient> GetPatients(string sortExpression);

        /// <summary>
        /// Gets a customer.
        /// </summary>
        /// <param name="customerId">Unique customer identifier.</param>
        /// <returns>Customer.</returns>
        string GetPatient(int PatientID);
        
        /// <summary>
        /// Gets customer given an order.
        /// </summary>
        /// <param name="order">Order.</param>
        /// <returns>Customer.</returns>

        /// <summary>
        /// Inserts a new customer. 
        /// </summary>
        /// <remarks>
        /// Following insert, customer object will contain the new identifier.
        /// </remarks>
        /// <param name="customer">Customer.</param>
        void InsertPatient(Patient patient);
      
    }
}
