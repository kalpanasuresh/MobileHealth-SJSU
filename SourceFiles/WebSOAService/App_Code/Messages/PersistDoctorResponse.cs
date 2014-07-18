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
/// Represents the response to a customer persistence request. 
/// May include additional Customer information, such as, a newly
/// generated CustomerId (following and Insert request).
/// </summary>
[Serializable]
public class PersistDoctorResponse : ResponseBase
{
    /// <summary>
    /// The returned customer data. Following an insert request it will include
    /// the newly generated CustomerId. 
    /// </summary>
    public DoctorTransferObject Doctor;
}
