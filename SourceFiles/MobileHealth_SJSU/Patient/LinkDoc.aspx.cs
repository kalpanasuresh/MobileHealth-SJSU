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
using DataSet1TableAdapters;

public partial class Patient_LinkDoc : System.Web.UI.Page
{
    private WebRef.Service proxy;
    DataTable dsDay = new DataTable();
    DataTable dsSchedule = new DataTable();
    DataTable3TableAdapter addp = new DataTable3TableAdapter();
    DataSet1.DataTable3DataTable dt = new DataSet1.DataTable3DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Master.DataFromPageLabelControl("Patient");
            LBLdOC.Visible = false;

        }
        dt = addp.GetData(Convert.ToInt32(Session["PatientID"]));
        GridView1.DataSource = dt;
        GridView1.Visible = true;
        GridView1.DataBind();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        if (lstInstructors.SelectedValue != "")
        {
            //txtLoad.Text = lstInstructors.SelectedValue;
            //calApp.SelectedDate = GetStartDate();
            //calApp.Visible = true;

            Session["DocID"] = lstInstructors.SelectedValue.ToString();
            PatientDoctorTableAdapter adap_patDoc = new PatientDoctorTableAdapter();
            DataSet1.PatientDoctorDataTable dt = new DataSet1.PatientDoctorDataTable();
            dt = adap_patDoc.GetData(Convert.ToInt32(Session["PatientID"]));


            if (dt.Rows.Count == 0 || !dt.Rows[0][0].ToString().Equals(Session["DocID"]))
            {
                QueriesTableAdapter adap_ins = new QueriesTableAdapter();
                adap_ins.PatDocInsertQuery(Convert.ToInt32(Session["PatientID"]), Convert.ToInt32(Session["DocID"]));

                lblMessage.ForeColor = Color.White;
                lblMessage.BackColor = Color.White;
                lblMessage.Text = "Doctor Added Successfully!";
                dt = adap_patDoc.GetData(Convert.ToInt32(Session["PatientID"]));
                GridView1.Visible = true;
                GridView1.DataBind();
                lblMessage.Visible = false;
                lstInstructors.Visible = false;
                LBLdOC.Visible = false;
                txtSearchValue.Text = string.Empty;
                Button1.Visible = false;
            }
            else
            {
                lblMessage.ForeColor = Color.Black;
                lblMessage.BackColor = Color.Red;
                lblMessage.Text = "You have already added this doctor.";
            }
        }



        else
        {
            lblMessage.ForeColor = Color.Black;
            lblMessage.BackColor = Color.Red;
            lblMessage.Text = "Please select a Doctor.";
        }

    }
    protected void GetDoctor1_Load(object sender, EventArgs e)
    {

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {

        // Proxy must accept and hold cookies
        //   proxy.CookieContainer = new System.Net.CookieContainer();           

        System.Data.DataSet dsDoctors = new DataSet();
        System.Net.ServicePointManager.CertificatePolicy = new MyPolicy();

        proxy = new WebRef.Service();
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
            LBLdOC.Visible = true;
            Button1.Visible = true;
            //  btnGo.Visible = true;
        }
    }
    protected void lstInstructors_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void lstInstructors_SelectedIndexChanged1(object sender, EventArgs e)
    {

    }
}
