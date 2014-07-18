using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Web.Security;
using System.Collections;

using System.Collections.Generic;

using DoFactory.BusinessLayer.Facade;
using DoFactory.BusinessLayer.BusinessObjects;
using DoFactory.Framework.Encryption;
using Facade;
using System.Data;

//
// Unfortunately the /doc setting is not available in VS 2005 for ASP.NET projects. 
// Therefore, no documentation could be generated for this project.  See also: 
// http://lab.msdn.microsoft.com/productfeedback/viewfeedback.aspx?feedbackid=e9c04230-1d2e-48a3-8e30-9f61f3b4d521
// 

/// <summary>
/// Defines the exposed XML Web Services methods for Patterns in Action.
/// 
/// SOA Patterns: Document Centric, Reservation, Unit Of Work, 
/// </summary>
[WebService(Namespace = "http://www.yourcompany.com/webservice/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class Service : System.Web.Services.WebService
{
    /// <summary>
    /// Logs user into the web service. 
    /// Note: Credentials are hardcoded in this example. Normally you 
    /// would need to validate against a database or Active Directory.
    /// </summary>
    /// <param name="request">Login request message.</param>
    /// <returns>Login response message.</returns>
    [WebMethod(EnableSession=true)]
    public LoginResponse Login(LoginRequest request)
    {
        LoginResponse response = new LoginResponse();

        // Set correlation Id
        response.CorrelationId = request.RequestId;
        
        try
        {
            // Validate credentials 
            if (request.SecurityToken != "ABC123")
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = "Invalid Security Token.";
            }

            else if (!(request.UserName == "Jill" && request.Password == "LochNess24"))
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = "Invalid Username or Password.";
            }

            else 
            {
                // Creates authentication ticket and adds it to cookies
                FormsAuthentication.SetAuthCookie(request.UserName, false);

                // Return Uri (could be used for a redirect to another server)
                response.Uri = Context.Request.Url.AbsoluteUri;

                // Return new SessionId
                response.SessionId = Context.Session.SessionID;
            }
        }
        catch // (Exception ex)
        {
            response.Acknowledge = AcknowledgeType.Failure;
            response.Message = "Login request cannot be handled at this time.";
        }

        return response;
    }

    /// <summary>
    /// Logs user out from the web service.
    /// </summary>
    /// <param name="request">Logout request message.</param>
    /// <returns>Logout response message.</returns>
    [WebMethod(EnableSession = true)]
    public LogoutResponse Logout(LogoutRequest request)
    {
        LogoutResponse response = new LogoutResponse();

        // Set correlation Id
        response.CorrelationId = request.RequestId;

        try
        {
            if (request.SecurityToken != "ABC123")
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = "Invalid Security Token";
            }

            FormsAuthentication.SignOut();
        }
        catch // (Exception ex)
        {
            response.Acknowledge = AcknowledgeType.Failure;
            response.Message = "Logout request cannot be handled at this time.";
        }

        return response;
    }

    /// <summary>
    /// Gets a list of all customers in a given sort order.
    /// </summary>
    /// <param name="request">Customer request message.</param>
    /// <returns>Customer response message.</returns>
    //[WebMethod(EnableSession = true)]
    //public CustomerResponse GetCustomers(CustomerRequest request)
    //{
    //    CustomerResponse response = new CustomerResponse();

    //    // Set correlation Id
    //    response.CorrelationId = request.RequestId;

    //    try
    //    {
           

    //            // Get customer list via Customer Facade.
    //            CustomerFacade facade = new CustomerFacade();
    //            IList<Customer> list = facade.GetCustomersWithOrderStatistics(request.SortExpression);

    //            response.Customers = new CustomerTransferObject[list.Count];

    //            // Package customer data in Customer Transfer Object
    //            int index = 0;
    //            foreach (Customer customer in list)
    //            {
    //                CustomerTransferObject transfer = new CustomerTransferObject();

    //                transfer.CustomerId = EncryptId(customer.CustomerId, "Customer");
    //                transfer.Company = customer.Company;
    //                transfer.City = customer.City;
    //                transfer.Country = customer.Country;
    //                transfer.NumOrders = customer.NumOrders;
    //                transfer.LastOrderDate = customer.LastOrderDate;

    //                response.Customers[index++] = transfer;
    //            }
            
    //    }
    //    catch // (Exception ex)
    //    {
    //        response.Acknowledge = AcknowledgeType.Failure;
    //        response.Message = "Request cannot be handled at this time.";
    //    }

    //    return response;
    //}
    [WebMethod(EnableSession = true)]
    public PatientResponse GetPatients(PatientRequest request)
    {
        PatientResponse response = new PatientResponse();

        // Set correlation Id
        response.CorrelationId = request.RequestId;

        try
        {


            // Get customer list via Customer Facade.
            PatientFacade facade = new PatientFacade();
            IList<Patient> list = facade.GetPatients(request.SortExpression);

            response.Patients = new PatientTransferObject[list.Count];
            Console.WriteLine(list.Count.ToString());
            // Package customer data in Customer Transfer Object
            int index = 0;
            foreach (Patient patient in list)
            {
                PatientTransferObject transfer = new PatientTransferObject();

                transfer.PatientID = patient.PatientID;
                transfer.FName = patient.fName;
                transfer.LName = patient.LName;
                transfer.Phone = patient.Phone;
               

                response.Patients[index++] = transfer;
            }

        }
        catch // (Exception ex)
        {
            response.Acknowledge = AcknowledgeType.Failure;
            response.Message = "Request cannot be handled at this time.";
        }

        return response;
    }

    [WebMethod(EnableSession = true)]
    public PatientResponse GetPatient(PatientRequest request)
    {
        PatientResponse response = new PatientResponse();

        // Set correlation Id
        response.CorrelationId = request.RequestId;

        try
        {


            // Get customer patient via Patient Facade.
            PatientFacade facade = new PatientFacade();
           response.Name = facade.GetPatient(request.PatientID);

          

        }
        catch // (Exception ex)
        {
            response.Acknowledge = AcknowledgeType.Failure;
            response.Message = "Request cannot be handled at this time.";
        }

        return response;
    }
    [WebMethod(EnableSession = true)]
    public DoctorResponse GetDoctors(DoctorRequest request)
    {
        DoctorResponse response = new DoctorResponse();

        // Set correlation Id
        response.CorrelationId = request.RequestId;

        try
        {


            // Get customer list via Customer Facade.
            DoctorFacade facade = new DoctorFacade();
          response.ds = facade.GetDoctor(request.lastName);

           //response.Doctors = new DoctorTransferObject[ListDoc.Count];
           //Console.WriteLine(ListDoc.Count.ToString());
           // // Package customer data in Customer Transfer Object
           // int index = 0;
           // foreach (Doctor doctor in ListDoc)
           // {
          //DoctorResponse response = new DoctorResponse();
          
           
            //    transfer.docID = doctor.DoctorID;
            //    transfer.fName = doctor.fName;
            //    transfer.LName = doctor.LName;
            //    transfer.phone = doctor.Phone;


            //    response.Doctors[index++] = transfer;
            //}

        }
        catch (Exception ex)
        {
            response.Acknowledge = AcknowledgeType.Failure;
            response.Message = "Request cannot be handled at this time."+ex.Message;
        }

        return response;
    }
    [WebMethod(EnableSession = true)]
    public AppointmentResponse GetDocSchedule(AppointmentRequest request)
    {
        AppointmentResponse response = new AppointmentResponse();

        // Set correlation Id
        response.CorrelationId = request.RequestId;

        try
        {


            // Get customer list via Customer Facade.
            AppointmentFacade facade = new AppointmentFacade();
            response.ds= facade.GetDocSchedule(request.date,request.docID);

            
           

        }
        catch (Exception ex)
        {
            response.Acknowledge = AcknowledgeType.Failure;
            response.Message = "Request cannot be handled at this time."+ex.Message;
        }

        return response;
    }
    //[WebMethod(EnableSession = true)]
    //public AppointmentResponse CheckAppointment(AppointmentRequest request)
    //{
    //    AppointmentResponse response = new AppointmentResponse();

    //    // Set correlation Id
    //    response.CorrelationId = request.RequestId;

    //    try
    //    {


    //        // Get customer list via Customer Facade.
    //        AppointmentFacade facade = new AppointmentFacade();
    //        Appointment appt=new Appointment();
    //        appt.PatientID=request.Appt.PatientID;
    //        appt.DoctorID=request.Appt.DoctorID;
    //        appt.Start=request.Appt.Start;
    //        appt.End=request.Appt.End;
    //        int count = facade.CheckAppointment(appt);

            
    //        response.count=count;
            

    //    }
    //    catch // (Exception ex)
    //    {
    //        response.Acknowledge = AcknowledgeType.Failure;
    //        response.Message = "Request cannot be handled at this time.";
    //    }

    //    return response;
    //}


    /// <summary>
    /// Inserts, Updates, or Detetes a customer from the database.
    /// </summary>
    /// <param name="request">Persist customer request message.</param>
    /// <returns>Persist customer response message.</returns>
  //  [WebMethod(EnableSession = true)]
  ////  public PersistCustomerResponse PersistCustomer(PersistCustomerRequest request)
  //  {
  //      PersistCustomerResponse response = new PersistCustomerResponse();

  //      // Set correlation Id
  //      response.CorrelationId = request.RequestId;

  //      try
  //      {
  //          if (!Context.User.Identity.IsAuthenticated)
  //          {
  //              response.Acknowledge = AcknowledgeType.Failure;
  //              response.Message = "Session expired. Please login.";
  //          }

  //          else if (request.SecurityToken != "ABC123")
  //          {
  //              response.Acknowledge = AcknowledgeType.Failure;
  //              response.Message = "Invalid Security Token.";

  //              // Forcibly abandon session
  //              Context.Session.Abandon();
  //          }

  //          else if (PreviouslyRequested(request.RequestId))
  //          {
  //              response.Acknowledge = AcknowledgeType.Failure;
  //              response.Message = "Request has been handled previously.";
  //          }

  //          else
  //          {
  //              // Call persistence request via Customer Facade.
  //              CustomerFacade facade = new CustomerFacade();

  //              switch (request.PersistAction)
  //              {
  //                  case PersistType.Insert:
  //                  {
  //                      Customer customer = new Customer();
  //                      customer.Company = request.Customer.Company;
  //                      customer.City = request.Customer.City;
  //                      customer.Country = request.Customer.Country;

  //                      facade.AddCustomer(customer);

  //                      response.Customer = request.Customer;
  //                      response.Customer.CustomerId = EncryptId(customer.CustomerId, "Customer");

  //                      break;
  //                  }
  //                  case PersistType.Update:
  //                  {
  //                      Customer customer = new Customer();

  //                      customer.CustomerId = DecryptId(request.Customer.CustomerId);
  //                      customer.Company = request.Customer.Company;
  //                      customer.City = request.Customer.City;
  //                      customer.Country = request.Customer.Country;

  //                      facade.UpdateCustomer(customer);

  //                      response.Customer = request.Customer;
  //                      break;
  //                  }
  //                  case PersistType.Delete:
  //                  {
  //                      int customerId = DecryptId(request.Customer.CustomerId);
  //                      int rowsAffected = facade.DeleteCustomer(customerId);
  //                      if (rowsAffected == 0)
  //                          throw new Exception("Customer has orders and therefore cannot be deleted. ");

  //                      break;
  //                  }
  //              }
  //          }
  //      }
  //      catch (Exception ex)
  //      {
  //          response.Acknowledge = AcknowledgeType.Failure;
  //          response.Message = ex.Message;
  //      }

  //      return response;
  //  }
    [WebMethod(EnableSession = true)]
    public PersistPatientResponse PersistPatient(PersistPatientRequest request)
    {
        PersistPatientResponse response = new PersistPatientResponse();

        // Set correlation Id
       
        response.CorrelationId = request.RequestId;

        try
        {
                  // Call persistence request via Customer Facade.
                PatientFacade facade = new PatientFacade();

                switch (request.PersistAction)
                {
                    case PersistType.Insert:
                        {
                            Patient patient = new Patient();
                            patient.fName = request.Patient.FName;
                            patient.LName = request.Patient.LName;
                            patient.Phone = request.Patient.Phone;
                            patient.UserID = request.Patient.UserID;
                            patient.Email = request.Patient.Email;
                            patient.SecQues = request.Patient.SecQues;
                            patient.SecAns = request.Patient.SecAns;
                            patient.Pass = request.Patient.Password;
                            patient.dOBirth = request.Patient.dOBirth;
                            patient.gender = request.Patient.gender;
                            patient.zip = request.Patient.zip;
                           patient.InsurName = request.Patient.healthIn;
                           patient.LocationOfPolicy = request.Patient.locPolicy;
                           patient.Address = request.Patient.address;
                           patient.City = request.Patient.city;
                           patient.State = request.Patient.state;
                           patient.Provider = request.Patient.provider;


                            facade.AddPatient(patient);

                            response.Patient = request.Patient;
                            response.Patient.PatientID = patient.PatientID;

                            break;
                        }
                    //case PersistType.Update:
                    //    {
                    //        Customer customer = new Customer();

                    //        customer.CustomerId = DecryptId(request.Customer.CustomerId);
                    //        customer.Company = request.Customer.Company;
                    //        customer.City = request.Customer.City;
                    //        customer.Country = request.Customer.Country;

                    //        facade.UpdateCustomer(customer);

                    //        response.Customer = request.Customer;
                    //        break;
                    //    }
                    //case PersistType.Delete:
                    //    {
                    //        int customerId = DecryptId(request.Customer.CustomerId);
                    //        int rowsAffected = facade.DeleteCustomer(customerId);
                    //        if (rowsAffected == 0)
                    //            throw new Exception("Customer has orders and therefore cannot be deleted. ");

                    //        break;
                    //    }
                }
            
        }
        catch (Exception ex)
        {
            response.Acknowledge = AcknowledgeType.Failure;
            response.Message = ex.ToString();
        }

        return response;
    }
    //[WebMethod(EnableSession = true)]
    //public PersistAppointmentResponse PersistAppointment(PersistAppointmentRequest request)
    //{
    //    PersistAppointmentResponse response = new PersistAppointmentResponse();

    //    // Set correlation Id

    //    response.CorrelationId = request.RequestId;

    //    try
    //    {
    //        // Call persistence request via Customer Facade.
    //        AppointmentFacade facade = new AppointmentFacade();

    //        switch (request.PersistAction)
    //        {
    //            case PersistType.Insert:
    //                {
    //                    Appointment appt = new Appointment();
    //                    appt.PatientID = request.Appt.PatientID;
    //                    appt.DoctorID = request.Appt.DoctorID;
    //                    appt.Start = request.Appt.Start;
    //                    appt.End = request.Appt.End;
    //                    appt.Location = request.Appt.Location;
    //                    appt.note = request.Appt.Notes;
                      

    //                    facade.AddAppointment(appt);

    //                    response.Appt = request.Appt;
    //                    response.Appt.ApptID = appt.ApptID;

    //                    break;
    //                }
    //            //case PersistType.Update:
                //    {
                //        Customer customer = new Customer();

                //        customer.CustomerId = DecryptId(request.Customer.CustomerId);
                //        customer.Company = request.Customer.Company;
                //        customer.City = request.Customer.City;
                //        customer.Country = request.Customer.Country;

                //        facade.UpdateCustomer(customer);

                //        response.Customer = request.Customer;
                //        break;
                //    }
                //case PersistType.Delete:
                //    {
                //        int customerId = DecryptId(request.Customer.CustomerId);
                //        int rowsAffected = facade.DeleteCustomer(customerId);
                //        if (rowsAffected == 0)
                //            throw new Exception("Customer has orders and therefore cannot be deleted. ");

                //        break;
                //    }
    //        }

    //    }
    //    catch (Exception ex)
    //    {
    //        response.Acknowledge = AcknowledgeType.Failure;
    //        response.Message = ex.Message;
    //    }

    //    return response;
    //}

    /// <summary>
    /// Gets all orders for a given customer.
    /// </summary>
    /// <param name="request">Order request message.</param>
    /// <returns>Order response message.</returns>
    //[WebMethod(EnableSession = true)]
    //public OrderResponse GetCustomerOrders(OrderRequest request)
    //{
    //    OrderResponse response = new OrderResponse();

    //    // Set correlation Id
    //    response.CorrelationId = request.RequestId;

    //    try
    //    {
    //        if (!Context.User.Identity.IsAuthenticated)
    //        {
    //            response.Acknowledge = AcknowledgeType.Failure;
    //            response.Message = "Session expired. Please login.";
    //        }

    //        else if (request.SecurityToken != "ABC123")
    //        {
    //            response.Acknowledge = AcknowledgeType.Failure;
    //            response.Message = "Invalid Security Token.";

    //            // Forcibly abandon session
    //            Context.Session.Abandon();
    //        }

    //        else
    //        {
    //            // Get orders via call into Customer Facade.
    //            CustomerFacade facade = new CustomerFacade();
    //            Customer customer = facade.GetCustomer(DecryptId(request.CustomerId));

    //            response.Orders = new OrderTransferObject[customer.Orders.Count];

    //            // Package order data in Order Transfer Object
    //            int i = 0;
    //            foreach (Order order in customer.Orders)
    //            {
    //                OrderTransferObject transferOrder = new OrderTransferObject();

    //                transferOrder.OrderId = EncryptId(order.OrderId, "Order");
    //                transferOrder.OrderDate = order.OrderDate;
    //                transferOrder.RequiredDate = order.RequiredDate;
    //                transferOrder.Freight = order.Freight;

    //                // Get order details via Customer Facade
    //                Order details = facade.GetOrder(order.OrderId);
    //                transferOrder.OrderDetails = new OrderDetailTransferObject[details.OrderDetails.Count];

    //                // Package order detail data in Order Detail Transfer Object
    //                int j = 0;
    //                foreach (OrderDetail detail in details.OrderDetails)
    //                {
    //                    OrderDetailTransferObject transferDetail = new OrderDetailTransferObject();

    //                    transferDetail.Product = detail.Product;
    //                    transferDetail.Quantity = detail.Quantity;
    //                    transferDetail.UnitPrice = detail.UnitPrice;
    //                    transferDetail.Discount = detail.Discount;

    //                    transferOrder.OrderDetails[j++] = transferDetail;
    //                }

    //                response.Orders[i++] = transferOrder;
    //            }
    //        }
    //    }
    //    catch // (Exception ex)
    //    {
    //        response.Acknowledge = AcknowledgeType.Failure;
    //        response.Message = "Request cannot be handled at this time.";
    //    }

    //    return response;
    //}

    /// <summary>
    /// Determines if a UnitOfWork request was requested previously or not.
    /// In the 'real world' you would probably maintain UnitOfWork data in a 
    /// database. Private helper method.
    /// </summary>
    /// <param name="unitOfWork">Unit of work number.</param>
    /// <returns>Value indicating previously requested or not.</returns>
    private bool PreviouslyRequested(string unitOfWork)
    {
        // Check if UnitOfWork hashtable has already been established
        if (Context.Session["UnitOfWork"] == null)
        {
            Context.Session["UnitOfWork"] = new Hashtable();
        }

        Hashtable ht = Context.Session["UnitOfWork"] as Hashtable;
        if (ht.Contains(unitOfWork)) return true;

        ht.Add(unitOfWork, DateTime.Now);
        return false;
    }

    /// <summary>
    /// Encrypts internal identifier before sending it out to client.
    /// Private helper method.
    /// </summary>
    /// <param name="id">Identifier to be encrypted.</param>
    /// <param name="tableName">Database table in which identifier resides.</param>
    /// <returns>Encrypted stringified identifier.</returns>
    private string EncryptId(int id, string tableName)
    {
        string s = id.ToString() + "|" + tableName;
        return Crypto.ActionEncrypt(s);
    }

    /// <summary>
    /// Decrypts identifiers that come back from client.
    /// Private helper method.
    /// </summary>
    /// <param name="sid">Stringified, encrypted identifier.</param>
    /// <returns>Internal identifier.</returns>
    private int DecryptId(string sid)
    {
        string s = Crypto.ActionDecrypt(sid);
        s = s.Substring(0, s.IndexOf("|"));
        return int.Parse(s);
    }
    [WebMethod(EnableSession = true)]
    public PersistDoctorResponse PersistDoctor(PersistDoctorRequest request)
    {
        PersistDoctorResponse response = new PersistDoctorResponse();

        // Set correlation Id

        response.CorrelationId = request.RequestId;

        try
        {
            // Call persistence request via Customer Facade.
            DoctorFacade facade = new DoctorFacade();

            switch (request.PersistAction)
            {
                case PersistType.Insert:
                    {
                        Doctor doctor = new Doctor();
                        doctor.fName = request.Doctor.fName;
                        doctor.LName = request.Doctor.LName;
                        doctor.Phone = request.Doctor.phone;
                        doctor.UserID = request.Doctor.user;
                        doctor.email = request.Doctor.email;
                        doctor.SecQues = request.Doctor.secQu;
                        doctor.SecAns = request.Doctor.answer;
                        doctor.Password = request.Doctor.pass;
                        doctor.City = request.Doctor.city;
                        doctor.DateOfBirth = request.Doctor.dOBirth;
                        doctor.gender = request.Doctor.gender;
                        doctor.License_Type = request.Doctor.LicType;
                        doctor.National_PrvID = request.Doctor.NatProvID;
                        doctor.officeAdr = request.Doctor.officeAdr;
                        doctor.Primary_spl = request.Doctor.PrmSpl;
                        doctor.Title = request.Doctor.title;
                        doctor.zip = request.Doctor.zip;
                        doctor.State = request.Doctor.state;
                       

                        facade.AddDoctor(doctor);

                        response.Doctor = request.Doctor;
                        response.Doctor.docID = doctor.DoctorID;

                        break;
                    }
                //case PersistType.Update:
                //    {
                //        Customer customer = new Customer();

                //        customer.CustomerId = DecryptId(request.Customer.CustomerId);
                //        customer.Company = request.Customer.Company;
                //        customer.City = request.Customer.City;
                //        customer.Country = request.Customer.Country;

                //        facade.UpdateCustomer(customer);

                //        response.Customer = request.Customer;
                //        break;
                //    }
                //case PersistType.Delete:
                //    {
                //        int customerId = DecryptId(request.Customer.CustomerId);
                //        int rowsAffected = facade.DeleteCustomer(customerId);
                //        if (rowsAffected == 0)
                //            throw new Exception("Customer has orders and therefore cannot be deleted. ");

                //        break;
                //    }
            }

        }
        catch (Exception ex)
        {
            response.Acknowledge = AcknowledgeType.Failure;
            response.Message = ex.Message;
        }

        return response;
    }
     [WebMethod(EnableSession = true)]
    public PersistAppointmentResponse PersistAppt(PersistAppointmentRequest request)
    {
        PersistAppointmentResponse response = new PersistAppointmentResponse();

        // Set correlation Id

        response.CorrelationId = request.RequestId;

        try
        {
            // Call persistence request via Customer Facade.
            AppointmentFacade facade = new AppointmentFacade();

            switch (request.PersistAction)
            {
                case PersistType.Insert:
                    {
                        facade.AddStudentAppointment(request.patientID, request.DoctorID, request.Date, request.strSet, request.TimeID);

                        response.Acknowledge = AcknowledgeType.Success;
                        //facade.AddDoctor(doctor);

                        //response.Doctor = request.Doctor;
                        //response.Doctor.docID = doctor.DoctorID;

                        break;
                    }
                case PersistType.Update:
                    {
                        Appointment appt = new Appointment();

                        appt.DoctorID = request.Appt.doctorID;
                        appt.AM8 = request.Appt.AM0800;
                        appt.AM830 = request.Appt.AM0830;
                        appt.AM9 = request.Appt.AM0900;
                        appt.AM930 = request.Appt.AM0930;
                        appt.AM10 = request.Appt.AM1000;
                        appt.AM1030 = request.Appt.AM1030;
                        appt.AM11 = request.Appt.AM1100;
                        appt.AM1130 = request.Appt.AM1130;
                        appt.PM12 = request.Appt.PM1200;
                        appt.PM1230 = request.Appt.PM1230;
                        appt.PM0100 = request.Appt.PM0100;
                        appt.PM0130 = request.Appt.PM0130;
                        appt.PM0200 = request.Appt.PM0200;
                        appt.PM0230 = request.Appt.PM0230;
                        appt.PM0300 = request.Appt.PM0300;
                        appt.PM0330 = request.Appt.PM0330;
                        appt.PM0400 = request.Appt.PM0400;
                        appt.PM0430 = request.Appt.PM0430;
                        appt.PM0500 = request.Appt.PM0500;
                        int dayID=request.Appt.dayID;

                        facade.UpdateDoctorAppointment(appt,dayID);

                       // response.Customer = request.Customer;
                        break;
                    }
                //case PersistType.Delete:
                //    {
                //        int customerId = DecryptId(request.Customer.CustomerId);
                //        int rowsAffected = facade.DeleteCustomer(customerId);
                //        if (rowsAffected == 0)
                //            throw new Exception("Customer has orders and therefore cannot be deleted. ");

                //        break;
                //    }
            }
            

        }
        catch (Exception ex)
        {
            response.Acknowledge = AcknowledgeType.Failure;
            response.Message = ex.Message;
        }

        return response;
    }
}
