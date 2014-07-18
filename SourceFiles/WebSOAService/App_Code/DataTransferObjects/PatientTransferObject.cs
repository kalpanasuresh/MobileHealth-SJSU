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
public class PatientTransferObject
{
    public int PatientID;

    /// <summary>
    /// Customer or company name.
    /// </summary>
    public string FName;

    /// <summary>
    /// Customer city.
    /// </summary>
    public string LName;

    /// <summary>
    /// Customer country.
    /// </summary>
    public string Phone;

    public string UserID;
    public string SecQues;
    public string SecAns;
    public string Email;
    public string Password;
    public string dOBirth;
    public string gender;
    public string zip;
    public string healthIn;
    public string locPolicy;
    public string address;
    public string city;
    public string state;
    public string provider;
    public PatientTransferObject()
    {
        //
        // TODO: Add constructor logic here
        //
    }
}
