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

public partial class Doctor_MessageCenter : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Master.DataFromPageLabelControl("Doctor");
 
        DataTable2TableAdapter adap = new DataTable2TableAdapter();
        DataSet1.DataTable2DataTable dt = new DataSet1.DataTable2DataTable();
       // Response.Write(Session["DocID"].ToString());
        dt = adap.GetData(Session["DocID"].ToString());
  
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

        
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        // Response.Redirect("~/Doctor/SMS.aspx?sub='" + GridView1.SelectedRow.Cells[2].Text + "'&PatID='" + GridView1.SelectedRow.Cells[0].Text+);

    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

        Response.Redirect("SMS.aspx?sub=" + GridView1.SelectedRow.Cells[2].Text + "&PatID=" + GridView1.SelectedRow.Cells[1].Text);

    }
    protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
            }
}
