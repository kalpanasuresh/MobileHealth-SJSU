using System;
using System.Collections.Generic;
using System.Text;
using DoFactory.BusinessLayer.BusinessObjects;
using System.Data;

namespace DoFactory.DataLayer.DataObjects
{
    public interface IDoctorDao
    {       
      

        DataSet GetDoctor(string lname);
        
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
        void InsertDoctor(Doctor doc);
      
    }
}
