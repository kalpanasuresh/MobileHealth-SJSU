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

public partial class Patient_PatHome : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {
            Master.DataFromPageLabelControl("Patient");
            Label2.Text = "Welcome " + Session["name"].ToString() + "!, choose the menu above to navigate";
        }


        //Response.Write(Session["PatientID"].ToString());
        DataTable dt_Schedule = new DataTable();
        dt_Schedule.Columns.Add("Doctor");
        dt_Schedule.Columns.Add("Date");
        dt_Schedule.Columns.Add("Time");


        Doctor2TableAdapter adap = new Doctor2TableAdapter();
        DataSet1.Doctor2DataTable dt = new DataSet1.Doctor2DataTable();
        dt = adap.GetData(Convert.ToInt32(Session["PatientID"]));

        foreach (DataRow row in dt.Rows)
        {
            Day_Data_TableTableAdapter adap_day = new Day_Data_TableTableAdapter();
            DataSet1.Day_Data_TableDataTable dt_day = new DataSet1.Day_Data_TableDataTable();
            dt_day = adap_day.GetData(Convert.ToInt32(row["Day_ID"]));

            DataRow newRow = dt_Schedule.NewRow();
            newRow["Doctor"] = row["Name"].ToString() + row["DocId"].ToString();
            newRow["Date"] = dt_day.Rows[0]["Day_Name"].ToString() + "," + dt_day.Rows[0]["Month_Number"].ToString() + "/" + dt_day.Rows[0]["Day_Number"].ToString();
            // Determine time of appointment
            switch (row["Time_ID"].ToString())
            {
                case "1":
                    newRow["Time"] = "8:00 am";
                    break;
                case "2":
                    newRow["Time"] = "8:30 am";
                    break;
                case "3":
                    newRow["Time"] = "9:00 am";
                    break;
                case "4":
                    newRow["Time"] = "9:30 am";
                    break;
                case "5":
                    newRow["Time"] = "10:00 am";
                    break;
                case "6":
                    newRow["Time"] = "10:30 am";
                    break;
                case "7":
                    newRow["Time"] = "11:00 am";
                    break;
                case "8":
                    newRow["Time"] = "11:30 am";
                    break;
                case "9":
                    newRow["Time"] = "12:00 pm";
                    break;
                case "10":
                    newRow["Time"] = "12:30 pm";
                    break;
                case "11":
                    newRow["Time"] = "1:00 pm";
                    break;
                case "12":
                    newRow["Time"] = "1:30 pm";
                    break;
                case "13":
                    newRow["Time"] = "2:00 pm";
                    break;
                case "14":
                    newRow["Time"] = "2:30 pm";
                    break;
                case "15":
                    newRow["Time"] = "3:00 pm";
                    break;
                case "16":
                    newRow["Time"] = "3:30 pm";
                    break;
                case "17":
                    newRow["Time"] = "4:00 pm";
                    break;
                case "18":
                    newRow["Time"] = "4:30 pm";
                    break;
                case "19":
                    newRow["Time"] = "5:00 pm";
                    break;
            }

            // Continue building row

            dt_Schedule.Rows.Add(newRow);
            dt_Schedule.AcceptChanges();
        }
        if (dt_Schedule.Rows.Count > 0)
        {
            Label1.Text = "Appointments scheduled by you with the doctor(s):";
            GridView1.DataSource = dt_Schedule;
            GridView1.DataBind();
        }
    }

}