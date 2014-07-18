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
/// Summary description for PatientRequest
/// </summary>

[Serializable]
public class PatientRequest:RequestBase
{
    public string SortExpression;

    public int PatientID;
    public PatientRequest()
    {
        //
        // TODO: Add constructor logic here
        //
    }
}
