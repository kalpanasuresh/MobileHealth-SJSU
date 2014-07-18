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
/// Represents a persistence request for a given customer record. 
/// Persisence operations include Insert, Update, or Delete. 
/// Sometimes referred to as a CRUD request: Create, Read, Update, Delete.
/// </summary>
[Serializable]
public class PersistPatientRequest : RequestBase
{
    /// <summary>
    /// Type of persistence: Insert, Update, or Delete.
    /// </summary>
    public PersistType PersistAction;

    /// <summary>
    /// The customer business data.
    /// </summary>
    public PatientTransferObject Patient;
}
