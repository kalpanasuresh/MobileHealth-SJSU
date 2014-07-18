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
/// Represents a login request from a client. Contains user credentials.
/// </summary>
[Serializable]
public class LoginRequest : RequestBase
{
    /// <summary>
    /// User name credential.
    /// </summary>
    public string UserName = "";

    /// <summary>
    /// Password credential.
    /// </summary>
    public string Password = "";
}
