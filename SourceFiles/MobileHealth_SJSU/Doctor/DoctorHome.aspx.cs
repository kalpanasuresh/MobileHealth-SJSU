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

public partial class Doctor_DoctorHome : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {
            Master.DataFromPageLabelControl("Doctor");
            Label2.Text = "Welcome Dr." + Session["name"].ToString() + "!, choose the menu above to navigate";

        }
        MedicalInfo1TableAdapter adap = new MedicalInfo1TableAdapter();
        DataSet1.MedicalInfo1DataTable dt = adap.GetData(Convert.ToInt32(Session["DocID"]));
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
}