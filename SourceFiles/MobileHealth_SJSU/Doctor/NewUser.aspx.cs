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
using DataSet1TableAdapters;
using DoFactory.BusinessLayer.BusinessObjects;

public partial class Doctor_NewUser : System.Web.UI.Page
{
    private WebRef.Service proxy;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            MultiView1.ActiveViewIndex = 0;
            // Master.DataFromPageLabelControl("Doctor");
         //   System.Net.ServicePointManager.CertificatePolicy = new MyPolicy();
            proxy = new WebRef.Service();

            // Proxy must accept and hold cookies
            //   proxy.CookieContainer = new System.Net.CookieContainer();
            proxy.Url = new Uri(proxy.Url).AbsoluteUri;
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 2;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        Session["Pass"] = this.ConfirmPassword.Text;

        MultiView1.ActiveViewIndex = 1;
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        PersistDoctorRequest dRequest = new PersistDoctorRequest();
        Doctor doc = new Doctor();
        dRequest.SecurityToken = "ABC123";
        dRequest.PersistAction = PersistType.Insert;
        proxy = new WebRef.Service();
        proxy.Url = new Uri(proxy.Url).AbsoluteUri;
        // Package customer data in customer transfer object
        DoctorTransferObject doctorTransfer = new DoctorTransferObject();

        doctorTransfer.fName = this.txtFName.Text;
        doctorTransfer.LName = this.txtLName.Text;
        doctorTransfer.phone = this.txtPhone.Text + "@" + ddlProvider.SelectedValue.ToString();
        doctorTransfer.email = this.Email.Text;
        doctorTransfer.user = this.UserName.Text;
        doctorTransfer.pass = Session["Pass"].ToString();
        doctorTransfer.secQu = this.Question.Text;
        doctorTransfer.answer = this.Answer.Text;
        doctorTransfer.city = this.txtCity.Text;
        doctorTransfer.dOBirth = this.txtDoB.Text;
        doctorTransfer.gender = rdGender.Text;
        doctorTransfer.LicType = ddlLic.Text;
        doctorTransfer.NatProvID = txtProvID.Text;
        doctorTransfer.officeAdr = this.txtAddr.Text;
        doctorTransfer.PrmSpl = this.ddlPrmSpl.Text;
        doctorTransfer.state = this.txtState.Text;
        doctorTransfer.title = "Mr.";
        doctorTransfer.zip = this.txtZip.Text;
        dRequest.Doctor = doctorTransfer;
        // Issue customer list request to web service

        PersistDoctorResponse dResponse = proxy.PersistDoctor(dRequest);


        if (dResponse.Acknowledge == AcknowledgeType.Success)
        {
            Session["DocID"] = dResponse.Doctor.docID.ToString();

        }
        else
            Literal2.Text = "Failure to add the user";
        Server.Transfer("~/General/Login.aspx");
    }
    protected void txtDoB_TextChanged(object sender, EventArgs e)
    {

    }
    protected void UserName_TextChanged(object sender, EventArgs e)
    {
        DoctorUserCheckTableAdapter adap_user = new DoctorUserCheckTableAdapter();
        DataSet1.DoctorUserCheckDataTable dt = adap_user.GetData(UserName.Text);
        if (Convert.ToInt32(dt.Rows[0][0]) != 0)
        {
            ErrorMessage.Text = "This user name already exists!, please choose another one";
            CustomValidator1.IsValid = false;
            CustomValidator1.Visible = true;
            CustomValidator1.Validate();
        }
        else
        {
            CustomValidator1.IsValid = true;
            CustomValidator1.Validate();
            CustomValidator1.Visible = false;
            ErrorMessage.Text = string.Empty;
        }
    }
    protected void txtPass_TextChanged(object sender, EventArgs e)
    {

    }
    protected void ConfirmPassword_TextChanged(object sender, EventArgs e)
    {
    }
}

