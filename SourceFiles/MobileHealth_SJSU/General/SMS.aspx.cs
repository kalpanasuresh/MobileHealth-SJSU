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
using WebRef;
using System.Security.Cryptography.X509Certificates;
using System.Net.Mail;
using System.ComponentModel;
using System.Drawing;

public partial class General_SMS : System.Web.UI.Page
{
    private WebRef.Service proxy;
    DataTable dsDay = new DataTable();
    DataTable dsSchedule = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Master.DataFromPageLabelControl("Patient");

        }

    }
    protected void cmdSend_Click(object sender, EventArgs e)
    {

        SendMail();
        QueriesTableAdapter adap_mess = new QueriesTableAdapter();
        adap_mess.InsertQuery(Session["PatientID"].ToString(), Session["DocID"].ToString(), txtMessage.Text, txtSubject.Text, 1, 0);
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {

        proxy = new WebRef.Service();
        // Proxy must accept and hold cookies
        //   proxy.CookieContainer = new System.Net.CookieContainer();           

        System.Data.DataSet dsDoctors = new DataSet();

        DoctorRequest dRequest = new DoctorRequest();
        DoctorTransferObject dTransObject = new DoctorTransferObject();
        dTransObject.LName = txtSearchValue.Text;

        dRequest.lastName = dTransObject.LName;
        //   X509Certificate x509 = X509Certificate.(@"c:\certificateSJSU.cer");
        proxy.Url = new Uri(proxy.Url).AbsoluteUri;

        //  proxy.ClientCertificates.Add(x509);
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
    static bool mailSent = false;

    public void SendMail()
    {
        //Builed The MSG
        Doctor1TableAdapter adap = new Doctor1TableAdapter();
        DataSet1.Doctor1DataTable dt = adap.GetData(Convert.ToInt32(Session["DocID"]));
        System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
        msg.To.Add(dt.Rows[0][0].ToString());
        msg.From = new MailAddress("sjsuhealthcare@gmail.com", "SJSUHealthCare", System.Text.Encoding.UTF8);
        msg.Subject = txtMessage.Text;
        msg.SubjectEncoding = System.Text.Encoding.UTF8;
        msg.Body = txtSubject.Text;
        msg.BodyEncoding = System.Text.Encoding.UTF8;
        msg.IsBodyHtml = false;
        msg.Priority = MailPriority.High;

        //Add the Creddentials
        SmtpClient client = new SmtpClient();
        client.Credentials = new System.Net.NetworkCredential("sjsuhealthcare", "U_Health");
        client.Port = 587;//or use 587            
        client.Host = "smtp.gmail.com";
        client.EnableSsl = true;
        client.SendCompleted += new SendCompletedEventHandler(client_SendCompleted);
        object userState = msg;
        try
        {
            //you can also call client.Send(msg)
            client.Send(msg);
        }
        catch (System.Net.Mail.SmtpException ex)
        {
            lblMessage.Text = "Send Mail Error";
        }
    }

    void client_SendCompleted(object sender, AsyncCompletedEventArgs e)
    {
        MailMessage mail = (MailMessage)e.UserState;
        string subject = mail.Subject;

        if (e.Cancelled)
        {
            string cancelled = string.Format("[{0}] Send canceled.", subject);
            lblMessage.Text = cancelled;
        }
        if (e.Error != null)
        {
            string error = String.Format("[{0}] {1}", subject, e.Error.ToString());
            lblMessage.Text = error;
        }
        else
        {
            lblMessage.Text = "Message sent.";
            lblMessage.Visible = true;
        }
        mailSent = true;
    }

}
