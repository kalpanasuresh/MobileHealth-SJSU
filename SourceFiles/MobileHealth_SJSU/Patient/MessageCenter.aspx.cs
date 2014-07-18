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

public partial class Patient_MessageCenter : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Master.DataFromPageLabelControl("Patient");
        }
        MessageTableAdapter adap = new MessageTableAdapter();
        DataSet1.MessageDataTable dt = new DataSet1.MessageDataTable();
       dt=adap.GetData(Session["PatientID"].ToString());
        GridView1.DataSource=dt;
        GridView1.DataBind();

    }
}
