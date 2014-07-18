using System;
using System.Collections.Generic;
using System.Text;
using DoFactory.DataLayer.DataObjects;
using System.ComponentModel;
using DoFactory.BusinessLayer.BusinessObjects;
using DoFactory.Framework.Transactions;

namespace Facade
{
    public class PatientFacade
    {
        private IPatientDao patientDAO = DataAccess.PatientDao;

        /// <summary>
        /// Gets a list of customers.
        /// </summary>
        /// <returns>List of Customers.</returns>
        [DataObjectMethod(DataObjectMethodType.Select)]
        public IList<Patient> GetPatients()
        {
            // TODO: add access security here..

            return patientDAO.GetPatients();
        }

        /// <summary>
        /// Gets a list of customers in a given sort order.
        /// </summary>
        /// <param name="sortExpression">Sort order of the list</param>
        /// <returns>Sorted list of customers.</returns>
        [DataObjectMethod(DataObjectMethodType.Select)]
        public IList<Patient> GetPatients(string sortExpression)
        {
            // TODO: add access security here..
            // TODO: add argument validation here..


            return patientDAO.GetPatients(sortExpression);
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public string GetPatient(int patientID)
        {
           
           return patientDAO.GetPatient(patientID);

            
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public void AddPatient(Patient patient)
        {
            //string sql = string.Empty;
            // TODO: add security here..
            // TODO: add argument validation here..

            // Run within the context of a database transaction.
            // The Decorator Design Pattern.
            using (TransactionDecorator transaction = new TransactionDecorator())
            {
                patientDAO.InsertPatient(patient);
                transaction.Complete();
                
            }
        }
       


    }
}
