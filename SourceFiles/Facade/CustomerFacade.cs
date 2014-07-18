using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

using System.Transactions;

using DoFactory.BusinessLayer.BusinessObjects;
//using DoFactory.BusinessLayer.Facade.ProxyObjects;
using DoFactory.DataLayer.DataObjects;
using DoFactory.Framework.Transactions;

namespace DoFactory.BusinessLayer.Facade
{
    /// <summary>
    /// Facade (also called Service Layer) that controls all access to Customer, 
    /// Order, and Order Details related activities.
    /// 
    /// Gof Design Patterns: Facade, Decorator, Proxy
    /// Enterprise Design Patterns: Remote Facade, LazyLoad, Service Layer, Transaction Script.
    /// </summary>
    /// <remarks>
    /// This Facade is not secure. In most applications each method in the 
    /// Facade should check for access security. This can be accomplished  
    /// either programmatically or declaratively (using Attributes). In addition,
    /// validation of arguments should also be added in each procedure.
    /// 
    /// The DataObject and DataObjectMethod Attributes in this class tell the 
    /// Visual Studio 2005 Wizards which classes and methods are 
    /// appropriate for building the ObjectDataSource Web controls.
    /// 
    /// The Proxy Pattern is used in accessing Orders and Order Details.
    /// 
    /// The Decorator Pattern is used in bracketing database transactions with
    /// a decorated Transaction scope class. 
    /// 
    /// The Remote Facade Design Pattern provides a course-grained facade on a 
    /// fine-grained objects. Indeed the methods are course-grained as they 
    /// deal with complete entities and/or entity lists rather than their individual 
    /// attributes.
    /// 
    /// The Service Layer Design Pattern is the same as the Facade Design Pattern 
    /// except that Service Layer is more specific to Enterprise Business Applications 
    /// in that the layer sits on top of the Domain Model (which is the case here).
    /// 
    /// The Transaction Script Design Pattern organizes business logic by procedures
    /// where each procedure handles a single request from the presentation.  This is 
    /// exactly how the Facade API has been modeled. They entirely handle individual
    /// requests (either from Web Application or Web Service).
    /// </remarks>
    [DataObject(true)]
    public class CustomerFacade
    {
        private ICustomerDao customerDao = DataAccess.CustomerDao;
        private IOrderDao orderDao = DataAccess.OrderDao;

        /// <summary>
        /// Gets a list of customers.
        /// </summary>
        /// <returns>List of Customers.</returns>
        [DataObjectMethod(DataObjectMethodType.Select)]
        public IList<Customer> GetCustomers()
        {
            // TODO: add access security here..

            return customerDao.GetCustomers();
        }

        /// <summary>
        /// Gets a list of customers in a given sort order.
        /// </summary>
        /// <param name="sortExpression">Sort order of the list</param>
        /// <returns>Sorted list of customers.</returns>
        [DataObjectMethod(DataObjectMethodType.Select)]
        public IList<Customer> GetCustomers(string sortExpression)
        {
            // TODO: add access security here..
            // TODO: add argument validation here..


            return customerDao.GetCustomers(sortExpression);
        }

        /// <summary>
        /// Gets a list of customers with order summary statistics.
        /// </summary>
        /// <param name="sortExpression">Sort order of list.</param>
        /// <returns>Sorted list of customers with order statistics.</returns>
        [DataObjectMethod(DataObjectMethodType.Select)]
        public IList<Customer> GetCustomersWithOrderStatistics(string sortExpression)
        {
            // TODO: add access security here..
            // TODO: add argument validation here..

            if (sortExpression.IndexOf("NumOrders") >= 0 ||
                sortExpression.IndexOf("LastOrderDate") >= 0)
            {
                // Sort order is handled by the Order Dao
                IList<Customer> list = customerDao.GetCustomers();
                return orderDao.GetOrderStatistics(list, sortExpression);
            }
            else
            {
                // Sort order is handled by the Customer Dao
                IList<Customer> list = customerDao.GetCustomers(sortExpression);
                return orderDao.GetOrderStatistics(list);
            }
        }

        /// <summary>
        /// Get a specific customer.
        /// Uses the Proxy Design Pattern.
        /// </summary>
        /// <param name="customerId">Unique customer identifier.</param>
        /// <returns>Requested customer.</returns>
        [DataObjectMethod(DataObjectMethodType.Select)]
        public Customer GetCustomer(int customerId)
        {
            // TODO: add access security here..
            // TODO: add argument validation here..

            // Retrieve Customer
            Customer customer = customerDao.GetCustomer(customerId);
            
            // Assign a Proxy for Orders. Only when Orders are absolutely 
            // needed will they be retrieved from the database.
            customer.Orders = new ProxyForOrders<Order>(customer);

            return customer;
        }

        /// <summary>
        /// Adds a new customer
        /// Uses the Decorator Design Pattern.
        /// </summary>
        /// <param name="customer">New Customer.</param>
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public void AddCustomer(Customer customer)
        {
            // TODO: add security here..
            // TODO: add argument validation here..

            // Run within the context of a database transaction.
            // The Decorator Design Pattern.
            using (TransactionDecorator transaction = new TransactionDecorator())
            {
                customerDao.InsertCustomer(customer);
                transaction.Complete();
            }
        }

        /// <summary>
        /// Updates a customer
        /// Uses the Decorator Design Pattern.
        /// </summary>
        /// <param name="customer">Customer to be updated.</param>
        [DataObjectMethod(DataObjectMethodType.Update)]
        public void UpdateCustomer(Customer customer)
        {
            // TODO: add security here..
            // TODO: add argument validation here..

            // Run within the context of a database transaction 
            // The Decorator Design Pattern.
            using (TransactionDecorator transaction = new TransactionDecorator())
            {
                customerDao.UpdateCustomer(customer);
                transaction.Complete();
            }
        }

        /// <summary>
        /// Deletes an existing customer.
        /// Uses the Decorator Design Pattern.
        /// </summary>
        /// <param name="customerId">Unique customer identifier.</param>
        /// <returns>Number of records deleted successfully.</returns>
        [DataObjectMethod(DataObjectMethodType.Delete)]
        public int DeleteCustomer(int customerId)
        {
            // TODO: add access security here..
            // TODO: add argument validation here..

            Customer customer = customerDao.GetCustomer(customerId);
            customer.Orders = orderDao.GetOrders(customer);

            int rowsAffected = 0;

            // Business rule: cannot delete Customers that have Orders
            if (customer.Orders.Count == 0)
            {
                // Run within the context of a database transaction 
                // The Decorator Design Pattern.
                using (TransactionDecorator transaction = new TransactionDecorator())
                {
                    rowsAffected = customerDao.DeleteCustomer(customer);
                    transaction.Complete();
                }
            }

            return rowsAffected;
        }

        /// <summary>
        /// Gets order details for a given order.
        /// Uses the Proxy Design Pattern.
        /// </summary>
        /// <param name="orderId">Unique order identifier.</param>
        /// <returns>Order that was requested.</returns>
        public Order GetOrder(int orderId)
        {
            // TODO: add access security here..
            // TODO: add argument validation here..

            Order order = orderDao.GetOrder(orderId);
            order.Customer = customerDao.GetCustomerByOrder(order);

            // Assign a Proxy for Order Details. Only when Order Details are 
            // absolutely needed will they be retrieved from the database.
            order.OrderDetails = new ProxyForOrderDetails<OrderDetail>(order);

            return order;
        }
    }
}
