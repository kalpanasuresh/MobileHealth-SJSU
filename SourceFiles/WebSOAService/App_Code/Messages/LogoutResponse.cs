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
/// Encapsulates a logout response from web service to client.
/// </summary>
[Serializable]
public class LogoutResponse : ResponseBase
{
    // This derived class intentionally left blank. 
    // Base class has the required parameters to acknowledge.
}
