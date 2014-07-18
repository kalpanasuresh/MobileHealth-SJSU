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
/// Represents a login response to the client.
/// </summary>
[Serializable]
public class LoginResponse : ResponseBase
{
    /// <summary>
    /// Uri to which client should redirect following successful login. 
    /// This would be necessary if authentication is handled centrally 
    /// and other services are distributed accross multiple servers. 
    /// Not used in this sample application. 
    /// SalesForce.com uses this in their API.
    /// </summary>
    public string Uri = "";

    /// <summary>
    /// Session identifier. Useful when sessions are maintained using 
    /// SOAP headers (rather than cookies). Not used in this sample application.
    /// SalesForce.com uses this in their SOAP header model.
    /// </summary>
    public string SessionId = "";
}
