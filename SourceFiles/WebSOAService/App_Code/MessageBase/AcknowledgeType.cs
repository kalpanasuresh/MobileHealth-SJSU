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
/// Enumeration of message response acknowledgements. This is a simple
/// enumerated values indicating success of failure.
/// </summary>
[Serializable]
public enum AcknowledgeType
{
    /// <summary>
    /// Respresents an failed response.
    /// </summary>
    Failure = 0,

    /// <summary>
    /// Represents a successful response.
    /// </summary>
    Success = 1
}
