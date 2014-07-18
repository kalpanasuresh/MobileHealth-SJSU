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

public partial class General_GetDoctor : System.Web.UI.UserControl
{
    private WebRef.Service proxy;
    DataTable dsDay = new DataTable();
    DataTable dsSchedule = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
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
            //  btnGo.Visible = true;
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

            Session["DocID"] = lstInstructors.SelectedValue.ToString();

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

    protected void lstInstructors_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (lstInstructors.SelectedValue != "")
        {
            //txtLoad.Text = lstInstructors.SelectedValue;
            //calApp.SelectedDate = GetStartDate();
            //calApp.Visible = true;

            Session["DocID"] = lstInstructors.SelectedValue.ToString();

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
}

