using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for PatientTransferObject
/// </summary>
public class AppointmentTransferObject
{
    public int patientID;
    public int doctorID;
    public int apptID;
    public DateTime date;
    public string AM0800;
    public string AM0830;
    public string AM0900;
    public string AM0930;
    public string AM1000;
    public string AM1030;
    public string AM1100;
    public string AM1130;
    public string PM1200;
    public string PM1230;
    public string PM0100;
    public string PM0130;
    public string PM0200;
    public string PM0230;
    public string PM0300;
    public string PM0330;
    public string PM0400;
    public string PM0430;
    public string PM0500;
    public int dayID;
    public AppointmentTransferObject()
    {
        //
        // TODO: Add constructor logic here
        //
    }
}
