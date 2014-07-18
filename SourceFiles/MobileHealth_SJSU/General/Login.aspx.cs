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
using DataSet1TableAdapters;

public partial class General_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Session.Clear();

        }

    }
    protected void WebUserControl1_Load(object sender, EventArgs e)
    {

    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {

    }
    protected void LoginButton_Click(object sender, EventArgs e)
    {
        if (CaptchaControl1.UserValidated)
        {

            if (RadioButtonList1.SelectedIndex == 1)
            {
                PatientTableAdapter adap_patient = new PatientTableAdapter();
                DataSet1.PatientDataTable dt = adap_patient.GetData(UserName.Text, Password.Text);
                if (dt.Rows.Count > 0)
                {
                    Session["PatientID"] = dt.Rows[0][0].ToString();
                    Master.DataFromPageLabelControl("Patient");
                    Session["name"] = dt.Rows[0][1].ToString();
                    Response.Redirect("~/Patient/PatHome.aspx");
                    //  Session["type"] = "Doctor";
                }
                else
                    FailureText.Text = "Login attempt failed, Please try again.";


            }
            else
            {
                DoctorTableAdapter adap_doctor = new DoctorTableAdapter();
                DataSet1.DoctorDataTable dt = adap_doctor.GetData(UserName.Text, Password.Text);
                if (dt.Rows.Count > 0)
                {
                    Session["DocID"] = dt.Rows[0][0].ToString();
                    Session["name"] = dt.Rows[0][1].ToString();
                    Master.DataFromPageLabelControl("Doctor");
                    Response.Redirect("~/Doctor/DoctorHome.aspx");
                }

                else
                    FailureText.Text = "Login attempt failed, Please try again.";

            }
        }


    }
    protected void UserName_TextChanged(object sender, EventArgs e)
    {

    }
    protected void SubmitButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Doctor/MyMessageCenter.aspx");
    }
    protected void UserName_TextChanged1(object sender, EventArgs e)
    {

    }
    protected void Radiobuttonlist2_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.Radiobuttonlist2.SelectedIndex == 0)
        {
            Response.Redirect("~/Doctor/NewUser.aspx");

        }
        else
            Response.Redirect("~/Patient/NewUser.aspx");
    }
}
