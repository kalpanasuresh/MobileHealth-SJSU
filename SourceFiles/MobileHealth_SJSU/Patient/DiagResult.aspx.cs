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

public partial class Patient_DiagResult : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Master.DataFromPageLabelControl("Patient");
        }

        lblName.Text = Request.QueryString[0].ToString();
        Label1.Text = Request.QueryString[1].ToString();
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/General/SMS.aspx?dis='" + Request.QueryString[0].ToString() + "'&med='" + Request.QueryString[1].ToString() + "'");
    }
}