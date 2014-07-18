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

public partial class Patient_Health : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Master.DataFromPageLabelControl("Patient");
        }

    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList1.SelectedItem.Text == "Test")
            txtTest.Visible = true;
        else
            txtTest.Visible = false;

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (DropDownList1.SelectedItem.Text == "Test" && txtTest.Text == string.Empty)
            Error.Text = "Please enter the test name";

        else
        {
            string test;
            if (DropDownList1.SelectedItem.Text == "Test")
                test = txtTest.Text;
            else
                test = DropDownList1.SelectedItem.Text;

            MedicalInfoTableAdapter adap = new MedicalInfoTableAdapter();
            adap.InsertQuery(Convert.ToInt32(Session["PatientID"]), test, string.Empty, txtMeasure.Text, string.Empty, DateTime.Now, txtDate.Text);
            SqlDataSource1.DataBind();
            GridView1.DataBind();
            GridView1.Visible = true;
        }
    }
}
