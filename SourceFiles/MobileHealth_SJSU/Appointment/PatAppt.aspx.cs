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
using System.Drawing;

public partial class Appointment_PatAppt : System.Web.UI.Page
{

    private WebRef.Service proxy;
    DataTable dsDay = new DataTable();
    DataTable dsSchedule = new DataTable();

    /// <summary>
    /// Array that eases programmatic access to the radio buttons used to set appointments.
    /// </summary>
    protected System.Web.UI.WebControls.RadioButton[] radArray = new RadioButton[19];

    /// <summary>
    /// Fires when page loads. Ensures session has not expired. Initializes radio 
    /// button array.
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="e">Event Arguments</param>
    /// <remarks>
    /// Pseudocode follows below.
    /// <code>
    /// Begin
    ///    If session has expired
    ///       Transfer user to login
    ///    End If
    ///    Initialize radio button array
    /// End
    /// </code> 
    /// </remarks>
    protected void Page_Load(object sender, System.EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            txtDate.Text = DateTime.Now.ToShortDateString();
            Master.DataFromPageLabelControl("Patient");
        }
        radArray[0] = radMakeApp1;
        radArray[1] = radMakeApp2;
        radArray[2] = radMakeApp3;
        radArray[3] = radMakeApp4;
        radArray[4] = radMakeApp5;
        radArray[5] = radMakeApp6;
        radArray[6] = radMakeApp7;
        radArray[7] = radMakeApp8;
        radArray[8] = radMakeApp9;
        radArray[9] = radMakeApp10;
        radArray[10] = radMakeApp11;
        radArray[11] = radMakeApp12;
        radArray[12] = radMakeApp13;
        radArray[13] = radMakeApp14;
        radArray[14] = radMakeApp15;
        radArray[15] = radMakeApp16;
        radArray[16] = radMakeApp17;
        radArray[17] = radMakeApp18;
        radArray[18] = radMakeApp19;
    }


    /// <summary>
    /// Fires when btnSearch is clicked. Searches for instructors based on ID or 
    /// last name.
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="e">Event Arguments</param>
    /// <remarks>
    /// Pseudocode follows below
    /// <code>
    /// Begin
    ///    If last name is selected
    ///       Get instructors by last name
    ///    Else
    ///       Get instructor by ID
    ///    End If
    ///    If no results are returned
    ///       Inform user
    ///    Else
    ///       For each result
    ///          add result to listbox
    ///       End For
    ///    End If
    /// End
    /// </code>
    /// </remarks>
    protected void btnSearch_Click(object sender, System.EventArgs e)
    {
        proxy = new WebRef.Service();
        // Proxy must accept and hold cookies
        //   proxy.CookieContainer = new System.Net.CookieContainer();           

        System.Data.DataSet dsDoctors = new DataSet();

        DoctorRequest dRequest = new DoctorRequest();
        DoctorTransferObject dTransObject = new DoctorTransferObject();
        dTransObject.LName = txtSearchValue.Text;

        dRequest.lastName = dTransObject.LName;
        proxy.Url = new Uri(proxy.Url).AbsoluteUri;
        DoctorResponse dResponse = proxy.GetDoctors(dRequest);
        // Get instructors that match last name
        dsDoctors = dResponse.ds;


        // If there are no results inform user
        if (dsDoctors.Tables[0].Rows.Count < 1)
        {
            lblMessage.ForeColor = Color.Black;
            lblMessage.BackColor = Color.Red;
            lblMessage.Text = "No doctor's match the given Last Name";
        }
        else
        {
            // Populate list box with results
            for (int x = 0; x < dsDoctors.Tables[0].Rows.Count; ++x)
            {
                this.lstInstructors.Items.Add(new ListItem(dsDoctors.Tables[0].Rows[x][1].ToString() + " " + dsDoctors.Tables[0].Rows[x][2].ToString(), dsDoctors.Tables[0].Rows[x][0].ToString()));
            }
            lstInstructors.Visible = true;
            btnGo.Visible = true;
        }
    }

    /// <summary>
    /// Fires when btnGo is clicked. Gets selected instructor's schedule
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="e">Event Arguments</param>
    /// <remarks>
    /// Pseudocode follows below
    /// <code>
    /// Begin
    ///    If an instructor is selected
    ///       Get schedule for instructor
    ///       Display Schedule for instructor
    ///    Else
    ///       Prompt user to select an instructor
    ///    End If
    /// End
    /// </code>
    /// </remarks>
    protected void btnGo_Click(object sender, System.EventArgs e)
    {
        // ensure an instructor is selected
        if (lstInstructors.SelectedValue != "")
        {
            //txtLoad.Text = lstInstructors.SelectedValue;
            //calApp.SelectedDate = GetStartDate();
            //calApp.Visible = true;

            GetDocSchedule(lstInstructors.SelectedValue);
            DispInsSchedule();

            lblMessage.ForeColor = Color.White;
            lblMessage.BackColor = Color.White;
            lblMessage.Text = "";


        }
        else
        {
            lblMessage.ForeColor = Color.Black;
            lblMessage.BackColor = Color.Red;
            lblMessage.Text = "Please select a Doctor.";
        }


    }

    /// <summary>
    /// Gets an instructors schedule
    /// </summary>
    /// <param name="strInsID">A string value with a numeric integer representing 
    /// an instructor.</param>
    /// <remarks>
    /// Pseudocode follows below
    /// <code>
    /// Begin
    ///    Get Day_ID for selected date and instructor
    ///    Get Schedule for selected Day_ID    
    /// End
    /// </code>
    /// </remarks>
    private void GetDocSchedule(string strDocID)
    {

        try
        {
            proxy = new WebRef.Service();

            // Proxy must accept and hold cookies
            //   proxy.CookieContainer = new System.Net.CookieContainer();
            proxy.Url = new Uri(proxy.Url).AbsoluteUri;
            AppointmentRequest aRequest = new AppointmentRequest();
            AppointmentTransferObject aTransferObject = new AppointmentTransferObject();
            aTransferObject.date = Convert.ToDateTime(txtDate.Text);
            aTransferObject.doctorID = Convert.ToInt32(strDocID);
            aRequest.date = aTransferObject.date;
            aRequest.docID = aTransferObject.doctorID;

            AppointmentResponse aResponse = proxy.GetDocSchedule(aRequest);

            dsDay = aResponse.ds.Tables[0];
            dsSchedule = aResponse.ds.Tables[1];


            Session["dsSchedule"] = dsSchedule;

            //  lblDay.Text = dsDay.Rows[0][1].ToString();


            // Get schedule                

        }
        catch (Exception ex)
        {
            lblMessage.ForeColor = Color.Black;
            lblMessage.BackColor = Color.Red;
            lblMessage.Text = ex.ToString();
        }

    }

    /// <summary>
    /// Displays instructor's schedule
    /// </summary>
    /// <remarks>
    /// Pseudocode follows below
    /// <code>
    /// Begin
    ///    For each time slot
    ///       If "Available"
    ///          Set radio button text
    ///          Make radio button visible
    ///       Else
    ///          If "Group"
    ///             Set radio button text
    ///             Make radio button visible
    ///          Else
    ///             Make radio button invisible
    ///          End If
    ///       End If
    ///    End For       
    /// End
    /// </code>
    /// </remarks>
    private void DispInsSchedule()
    {
        dsSchedule = (DataTable)Session["dsSchedule"];
        for (int x = 0; x < 19; ++x)
        {

            switch (dsSchedule.Rows[0][x + 8].ToString())
            {
                case "Yes":
                    radArray[x].Visible = true;
                    radArray[x].Checked = true;
                    radArray[x].Text = "Make Appointment";
                    break;
                case "Group":
                    radArray[x].Visible = true;
                    radArray[x].Checked = true;
                    radArray[x].Text = "Group Meeting";
                    break;
                default:
                    radArray[x].Visible = false;
                    radArray[x].Checked = false;
                    break;
            }
        }
        btnSubmit.Visible = true;
    }


    protected void btnSubmit_Click(object sender, System.EventArgs e)
    {
        string[] strSet = new string[2];
        Session["PATID"] = Session["PatientID"];

        for (int x = 0; x < 19; ++x)
        {
            int Time = -1;
            switch (x)
            {
                case 0:
                    if (radArray[x].Checked)
                    {
                        strSet = new string[2] { "AM_0800", "'PAT" + Session["PATID"].ToString() + "'" };
                        Time = x;
                    }
                    break;
                case 1:
                    if (radArray[x].Checked)
                    {
                        strSet = new string[2] { "AM_0830", "'PAT" + Session["PATID"].ToString() + "'" };
                        Time = x;
                    }
                    break;
                case 2:
                    if (radArray[x].Checked)
                    {
                        strSet = new string[2] { "AM_0900", "'PAT" + Session["PATID"].ToString() + "'" };
                        Time = x;
                    }
                    break;
                case 3:
                    if (radArray[x].Checked)
                    {
                        strSet = new string[2] { "AM_0930", "'PAT" + Session["PATID"].ToString() + "'" };
                        Time = x;
                    }
                    break;
                case 4:
                    if (radArray[x].Checked)
                    {
                        strSet = new string[2] { "AM_1000", "'PAT" + Session["PATID"].ToString() + "'" };
                        Time = x;
                    }
                    break;
                case 5:
                    if (radArray[x].Checked)
                    {
                        strSet = new string[2] { "AM_1030", "'PAT" + Session["PATID"].ToString() + "'" };
                        Time = x;
                    }
                    break;
                case 6:
                    if (radArray[x].Checked)
                    {
                        strSet = new string[2] { "AM_1100", "'PAT" + Session["PATID"].ToString() + "'" };
                        Time = x;
                    }
                    break;
                case 7:
                    if (radArray[x].Checked)
                    {
                        strSet = new string[2] { "AM_1130", "'PAT" + Session["PATID"].ToString() + "'" };
                        Time = x;
                    }
                    break;
                case 8:
                    if (radArray[x].Checked)
                    {
                        strSet = new string[2] { "PM_1200", "'PAT" + Session["PATID"].ToString() + "'" };
                        Time = x;
                    }
                    break;
                case 9:
                    if (radArray[x].Checked)
                    {
                        strSet = new string[2] { "PM_1230", "'PAT" + Session["PATID"].ToString() + "'" };
                        Time = x;
                    }
                    break;
                case 10:
                    if (radArray[x].Checked)
                    {
                        strSet = new string[2] { "PM_0100", "'PAT" + Session["PATID"].ToString() + "'" };
                        Time = x;
                    }
                    break;
                case 11:
                    if (radArray[x].Checked)
                    {
                        strSet = new string[2] { "PM_0130", "'PAT" + Session["PATID"].ToString() + "'" };
                        Time = x;
                    }
                    break;
                case 12:
                    if (radArray[x].Checked)
                    {
                        strSet = new string[2] { "PM_0200", "'PAT" + Session["PATID"].ToString() + "'" };
                        Time = x;
                    }
                    break;
                case 13:
                    if (radArray[x].Checked)
                    {
                        strSet = new string[2] { "PM_0230", "'PAT" + Session["PATID"].ToString() + "'" };
                        Time = x;
                    }
                    break;
                case 14:
                    if (radArray[x].Checked)
                    {
                        strSet = new string[2] { "PM_0300", "'PAT" + Session["PATID"].ToString() + "'" };
                        Time = x;
                    }
                    break;
                case 15:
                    if (radArray[x].Checked)
                    {
                        strSet = new string[2] { "PM_0330", "'PAT" + Session["PATID"].ToString() + "'" };
                        Time = x;
                    }
                    break;
                case 16:
                    if (radArray[x].Checked)
                    {
                        strSet = new string[2] { "PM_0400", "'PAT" + Session["PATID"].ToString() + "'" };
                        Time = x;
                    }
                    break;
                case 17:
                    if (radArray[x].Checked)
                    {
                        strSet = new string[2] { "PM_0430", "'PAT" + Session["PATID"].ToString() + "'" };
                        Time = x;
                    }
                    break;
                case 18:
                    if (radArray[x].Checked)
                    {
                        strSet = new string[2] { "PM_0500", "'PAT" + Session["PATID"].ToString() + "'" };
                        Time = x;
                    }
                    break;
            }

            if (Time != -1)
            {
                proxy = new WebRef.Service();

                // Proxy must accept and hold cookies
                //   proxy.CookieContainer = new System.Net.CookieContainer();
                proxy.Url = new Uri(proxy.Url).AbsoluteUri;
                PersistAppointmentRequest aRequest = new PersistAppointmentRequest();
                aRequest.PersistAction = PersistType.Insert;
                aRequest.Date = Convert.ToDateTime(txtDate.Text);
                aRequest.DoctorID = Convert.ToInt32(lstInstructors.SelectedValue);
                aRequest.patientID = Convert.ToInt32(Session["PATID"]);
                aRequest.strSet = strSet;
                aRequest.TimeID = Time;
                PersistAppointmentResponse aResponse = proxy.PersistAppt(aRequest);
                if (aResponse.Acknowledge == AcknowledgeType.Success)
                    Response.Write("Success");
            }
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (lstInstructors.SelectedValue != "")
        {
            if (Convert.ToDateTime(txtDate.Text) >= DateTime.Now)
            {
                //txtLoad.Text = lstInstructors.SelectedValue;
                //calApp.SelectedDate = GetStartDate();
                //calApp.Visible = true;

                GetDocSchedule(lstInstructors.SelectedValue);
                DispInsSchedule();

                lblMessage.ForeColor = Color.White;
                lblMessage.BackColor = Color.White;
                lblMessage.Text = "";
            }
            else
            {
                lblMessage.ForeColor = Color.Black;
                lblMessage.BackColor = Color.Red;
                lblMessage.Text = "Please enter a date greater than or equal to current date.";
            }


        }
        else
        {
            lblMessage.ForeColor = Color.Black;
            lblMessage.BackColor = Color.Red;
            lblMessage.Text = "Please select a Doctor.";
        }
    }
}



