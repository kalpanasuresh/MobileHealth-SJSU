using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using WebRef;
using DoFactory.BusinessLayer.BusinessObjects;
using DataSet1TableAdapters;

public partial class Appointment_ApptDoc : System.Web.UI.Page
{
    protected DropDownList[] cmbArray = new DropDownList[19];
    private WebRef.Service proxy;
    DataSet dsSchedule;
    AppointmentRequest aRequest = new AppointmentRequest();
    AppointmentTransferObject apptTransfer = new AppointmentTransferObject();
    Day_Data_Table1TableAdapter adap = new Day_Data_Table1TableAdapter();
    DataSet1.Day_Data_Table1DataTable dt;

    private void Page_Load(object sender, System.EventArgs e)
    {
        if (!Page.IsPostBack)
            Master.DataFromPageLabelControl("Doctor");
        // Load array elements
        cmbArray[0] = cmb8;
        cmbArray[1] = cmb830;
        cmbArray[2] = cmb9;
        cmbArray[3] = cmb930;
        cmbArray[4] = cmb10;
        cmbArray[5] = cmb1030;
        cmbArray[6] = cmb11;
        cmbArray[7] = cmb1130;
        cmbArray[8] = cmb12;
        cmbArray[9] = cmb1230;
        cmbArray[10] = cmb13;
        cmbArray[11] = cmb1330;
        cmbArray[12] = cmb14;
        cmbArray[13] = cmb1430;
        cmbArray[14] = cmb15;
        cmbArray[15] = cmb1530;
        cmbArray[16] = cmb16;
        cmbArray[17] = cmb1630;
        cmbArray[18] = cmb17;
        if (!Page.IsPostBack)
        {

            // MultiView1.ActiveViewIndex = 0;
            System.Net.ServicePointManager.CertificatePolicy = new MyPolicy();
            proxy = new WebRef.Service();
            // Proxy must accept and hold cookies
            //   proxy.CookieContainer = new System.Net.CookieContainer();
            proxy.Url = new Uri(proxy.Url).AbsoluteUri;

            //txtHiddenDate.Text = System.DateTime.Now.ToString();
            PostSchedule(System.DateTime.Now);
            //Calendar1.SelectedDate = System.DateTime.Now;				
        }
        else
        {
            proxy = new WebRef.Service();

            // Proxy must accept and hold cookies
            //   proxy.CookieContainer = new System.Net.CookieContainer();
            proxy.Url = new Uri(proxy.Url).AbsoluteUri;
            apptTransfer.date = Convert.ToDateTime(this.txtDate.Text);
            apptTransfer.doctorID = Convert.ToInt32(Session["DocID"]);
            aRequest.date = apptTransfer.date;
            aRequest.docID = apptTransfer.doctorID;
            AppointmentResponse aResponse = proxy.GetDocSchedule(aRequest);
            dsSchedule = aResponse.ds;
            dt = adap.GetData(DateTime.Now.Day, DateTime.Now.Month, Convert.ToInt32(Session["DocID"]));
            Session["day"] = dt;
        }

    }

    private void PostSchedule(System.DateTime dateDayToLoad)
    {

        // get selected date's schedule
        if (!string.IsNullOrEmpty(txtDate.Text))
            apptTransfer.date = Convert.ToDateTime(this.txtDate.Text);
        else
        {
            apptTransfer.date = DateTime.Now;
            txtDate.Text = DateTime.Now.ToShortDateString();
        }
        apptTransfer.doctorID = Convert.ToInt32(Session["DocID"]);
        aRequest.date = apptTransfer.date;
        aRequest.docID = apptTransfer.doctorID;
        System.Net.ServicePointManager.CertificatePolicy = new MyPolicy();
        proxy = new WebRef.Service();

        // Proxy must accept and hold cookies
        //   proxy.CookieContainer = new System.Net.CookieContainer();
        proxy.Url = new Uri(proxy.Url).AbsoluteUri;
        AppointmentResponse aResponse = proxy.GetDocSchedule(aRequest);
        dsSchedule = aResponse.ds;
        Session["day"] = adap.GetData(DateTime.Now.Day, DateTime.Now.Month, Convert.ToInt32(Session["DocID"]));

        try
        {
            // For each time slot
            for (int x = 0; x < 19; ++x)
            {
                // If value is available, unavailable, or in class.
                if (dsSchedule.Tables[1].Rows[0][x + 8].ToString() == "Yes" || dsSchedule.Tables[1].Rows[0][x + 8].ToString() == "No")
                {
                    cmbArray[x].SelectedValue = dsSchedule.Tables[1].Rows[0][x + 8].ToString();
                }

                // If value is a student appointment
                if (dsSchedule.Tables[1].Rows[0][x + 8].ToString().StartsWith("P"))
                {
                    System.Net.ServicePointManager.CertificatePolicy = new MyPolicy();
                    proxy = new WebRef.Service();

                    // Proxy must accept and hold cookies
                    //   proxy.CookieContainer = new System.Net.CookieContainer();
                    proxy.Url = new Uri(proxy.Url).AbsoluteUri;

                    PatientRequest pRequest = new PatientRequest();
                    pRequest.PatientID = Convert.ToInt32(dsSchedule.Tables[1].Rows[0][x + 8].ToString().Substring(3));

                    PatientResponse pResponse = proxy.GetPatient(pRequest);


                    //dsStudent = new DataSet();
                    //// Get student ID
                    //strStudentID = dsSchedule.Tables[0].Rows[0][x+8].ToString().Substring(3);

                    //// Set up SQL query to retrieve student's name
                    //string[] strSelect = new string[2] {"First_Name", "Last_Name"};
                    //string[] strWhere = new string [2] {"PAT", strStudentID};


                    //// Execute query
                    //dsStudent = dbMangler.SelectQuery("SDT", strSelect, strWhere);

                    //// Build student's name
                    //strStudentName = dsStudent.Tables[0].Rows[0][0] + " " + dsStudent.Tables[0].Rows[0][1];

                    //// Add and display student's name to combo box
                    cmbArray[x].Items.Add(new ListItem(pResponse.Name, "PAT" + pRequest.PatientID));
                    cmbArray[x].SelectedValue = "PAT" + pRequest.PatientID;
                }

            }
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.ToString();
        }

        //btnSubmit.Enabled = true;
        btnFlip.Enabled = true;
    }

    /// <summary>
    /// Fires when btnSubmit is clicked. Updates Instructor schedule and sends email 
    /// needed
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="e">Event Arguments</param>
    /// <remarks>
    /// Pseudocode follows below.
    /// <code>
    /// Begin
    ///    For each time slot.
    ///       If time slot has changed.
    ///          If time slot was a student appointment
    ///             Send  cancellation email
    ///             Remove appointment
    ///          End If
    ///       End If
    ///    End For
    ///    Update Time Data Table
    /// End
    /// </code>
    /// </remarks>
    protected void btnSubmit_Click(object sender, System.EventArgs e)
    {

        try
        {
            PersistAppointmentRequest papptRequest = new PersistAppointmentRequest();
            papptRequest.SecurityToken = "ABC123";
            papptRequest.PersistAction = PersistType.Update;
            apptTransfer.AM0800 = cmb8.SelectedValue.ToString();
            apptTransfer.AM0830 = cmb830.SelectedValue.ToString();
            apptTransfer.AM0900 = cmb9.SelectedValue.ToString();
            apptTransfer.AM0930 = cmb930.SelectedValue.ToString();
            apptTransfer.AM1000 = cmb10.SelectedValue.ToString();
            apptTransfer.AM1030 = cmb1030.SelectedValue.ToString();
            apptTransfer.AM1100 = cmb11.SelectedValue.ToString();
            apptTransfer.AM1130 = cmb1130.SelectedValue.ToString();
            apptTransfer.PM1200 = cmb12.SelectedValue.ToString();
            apptTransfer.PM1230 = cmb1230.SelectedValue.ToString();
            apptTransfer.PM0100 = cmb13.SelectedValue.ToString();
            apptTransfer.PM0130 = cmb1330.SelectedValue.ToString();
            apptTransfer.PM0200 = cmb14.SelectedValue.ToString();
            apptTransfer.PM0230 = cmb1430.SelectedValue.ToString();
            apptTransfer.PM0300 = cmb15.SelectedValue.ToString();
            apptTransfer.PM0330 = cmb1530.SelectedValue.ToString();
            apptTransfer.PM0400 = cmb16.SelectedValue.ToString();
            apptTransfer.PM0430 = cmb1630.SelectedValue.ToString();
            apptTransfer.PM0500 = cmb17.SelectedValue.ToString();
            apptTransfer.dayID = Convert.ToInt32(((DataTable)Session["day"]).Rows[0][0]);
            papptRequest.Appt = apptTransfer;
            PersistAppointmentResponse aResponse = proxy.PersistAppt(papptRequest);
            lblMessage.Text = "Your changes have been successfully saved!";
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.ToString();
        }

    }



    protected void txtDate_TextChanged(object sender, EventArgs e)
    {
        PostSchedule(Convert.ToDateTime(this.txtDate.Text));
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        if (Convert.ToDateTime(txtDate.Text) < DateTime.Now)
            lblMessage.Text = "Date should be greater than or equal to today";
        else
            PostSchedule(Convert.ToDateTime(this.txtDate.Text));
    }
    protected void btnFlip_Click(object sender, EventArgs e)
    {

    }
}

