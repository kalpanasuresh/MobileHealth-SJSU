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
/// Represents a request for a customer list from client to web service.
/// </summary>
[Serializable]
public class AppointmentRequest : RequestBase
{
    /// <summary>
    /// Sort order of the returned customer list. 
    /// </summary>
    public AppointmentTransferObject Appt;

    public DateTime date;
    public int docID;
}
