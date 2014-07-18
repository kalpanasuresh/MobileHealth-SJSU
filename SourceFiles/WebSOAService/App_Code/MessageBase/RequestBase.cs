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
/// Base class for all client request messages of the web service. It standardizes 
/// communication between web services and clients with a series of common values.
/// Derived request message classes assign values to these variables. There are no 
/// default values. 
/// </summary>
[Serializable]
public class RequestBase
{
    /// <summary>
    /// Each web service request carries a security token as an extra level of security.
    /// Tokens are issued when users are coming online. They can expire if necessary.
    /// Google.com and Amazon.com uses this in their API.
    /// </summary>
    public string SecurityToken;

    /// <summary>
    /// Minimum version number that client request is required to run under. This facilitates
    /// a certain level of backward compatibility for when the web service API evolves.
    /// Ebay.com uses the version number in their API. 
    /// </summary>
    public string Version;

    /// <summary>
    /// A unique number (ideally a Guid) issued by the client representing the instance 
    /// of the request. Avoids rapid-fire processing of the same request over and over 
    /// in denial-of-service type attacks.
    /// </summary>
    public string RequestId;
}
