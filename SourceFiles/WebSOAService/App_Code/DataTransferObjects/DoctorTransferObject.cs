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
public class DoctorTransferObject
{
    public string fName;
        public string LName;
        public string dOBirth;
        public string gender;
        public string email;
        public string zip;
        public string user;
        public string pass;
        public int docID;
        public string phone;
        public string secQu;
        public string answer;
        public string NatProvID;
        public string PrmSpl;
        public string LicType;
        public string title;
        public string officeAdr;
        public string state;
        public string city;
    
    public DoctorTransferObject()
    {
        //
        // TODO: Add constructor logic here
        //
    }
}
