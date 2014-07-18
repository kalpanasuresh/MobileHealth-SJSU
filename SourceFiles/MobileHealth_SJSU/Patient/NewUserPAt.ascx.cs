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
using BusinessObject;
using DataSet1TableAdapters;

public partial class Patient_NewUserPAt : System.Web.UI.UserControl
{
    //  private WebRef.Service proxy;
    protected void Page_Load(object sender, EventArgs e)
    {


        if (!Page.IsPostBack)
            MultiView1.ActiveViewIndex = 0;

    }
    protected void CreateUserWizard1_CreatedUser(object sender, EventArgs e)
    {

    }
    protected void Command1_Click(object sender, EventArgs e)
    {
        //PersistPatientRequest pRequest = new PersistPatientRequest();
        //BO_Patient patient = new BO_Patient();
        //pRequest.SecurityToken = "ABC123";
        //pRequest.PersistAction = PersistType.Insert;


        //// Package customer data in customer transfer object
        //PatientTransferObject pattientTransfer = new PatientTransferObject();

        //pattientTransfer.FName = txtFName.Text;
        //pattientTransfer.LName = txtLName.Text;
        //pattientTransfer.Phone = this.txtPhone.Text + "@" +this.ddlProvider.SelectedValue.ToString();
        //pattientTransfer.Email = this.Email.Text;
        //pattientTransfer.UserID = this.UserName.Text;
        //pattientTransfer.Password = this.txtPass.Text;
        //pattientTransfer.SecQues = this.Question.Text;
        //pattientTransfer.SecAns = this.Answer.Text;
        //pattientTransfer.address = this.txtAddr.Text;
        //pattientTransfer.city = this.txtCity.Text;
        //pattientTransfer.state = this.txtState.Text;
        //pattientTransfer.zip = this.txtZip.Text;
        //pattientTransfer.dOBirth = this.txtDoB.Text;
        //pattientTransfer.healthIn = this.ddlHealthPlan.Text;
        //pattientTransfer.locPolicy = this.ddlLocPolicy.Text;


        //pRequest.Patient = pattientTransfer;
        //// Issue customer list request to web service

        //PersistPatientResponse pResponse = proxy.PersistPatient(pRequest);


        //if (pResponse.Acknowledge == AcknowledgeType.Success)
        //{
        //    Response.Write(pResponse.Patient.PatientID.ToString());
        //}
        Patient1TableAdapter ADAP_INS = new Patient1TableAdapter();
        ADAP_INS.InsertQuery(this.txtFName.Text, this.txtLName.Text, Convert.ToDateTime(this.txtDoB.Text), this.Email.Text, this.txtAddr.Text, this.txtCity.Text, this.txtState.Text, this.txtZip.Text
        , this.ddlHealthPlan.Text, this.ddlLocPolicy.Text, this.RadioButtonList1.Text, this.txtPhone.Text + "@" + this.ddlProvider.SelectedValue.ToString(), this.UserName.Text, Session["Pass"].ToString(), this.Question.Text, this.Answer.Text, this.ddlProvider.Text);
        Response.Redirect("~/General/Login.aspx");

    }
    protected void UserName_TextChanged(object sender, EventArgs e)
    {
        PatientUserCheckTableAdapter adap = new PatientUserCheckTableAdapter();
        DataSet1.PatientUserCheckDataTable dt = adap.GetData(UserName.Text);
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
            ErrorMessage.Text = string.Empty;
            CustomValidator1.Visible = false;
            CustomValidator1.Validate();
        }
    }
    protected void Password_TextChanged(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Session["Pass"] = this.ConfirmPassword.Text;
        MultiView1.ActiveViewIndex = 1;
    }
    protected void Button2_Command(object sender, CommandEventArgs e)
    {

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 2;
    }
}
