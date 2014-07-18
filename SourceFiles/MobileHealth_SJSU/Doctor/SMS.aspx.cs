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
using System.Net.Mail;
using System.ComponentModel;
using DataSet1TableAdapters;

public partial class Doctor_SMS : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Master.DataFromPageLabelControl("Doctor");
            txtSubject.Text = "Re:" + Request.QueryString[0].ToString();
        }

    }
    protected void cmdSend_Click(object sender, EventArgs e)
    {


        SendMail();
        QueriesTableAdapter adap_mess = new QueriesTableAdapter();
        adap_mess.InsertQuery(Request.QueryString[1].ToString(), Session["DocID"].ToString(), txtSubject.Text, txtMessage.Text,0, 1);
    }
    static bool mailSent = false;

    public void SendMail()
    {
        //Builed The MSG
        Patient2TableAdapter adap = new Patient2TableAdapter();
        DataSet1.Patient2DataTable dt = adap.GetData(Convert.ToInt32(Request.QueryString[1].ToString()));

        System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
        msg.To.Add(dt.Rows[0][2].ToString());
        msg.From = new MailAddress("sjsuhealthcare@gmail.com", "SJSUHealthCare");
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
        }
        mailSent = true;
    }
}
