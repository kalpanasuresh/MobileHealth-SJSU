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
/// Enumeration of database persistence actions.
/// (Also called CRUD operations: Create, Read, Update, Delete).
/// 
/// SOA Design Pattern: Command Message. Basically this in an instruction
/// or command to the receiver which operatin to execute.
/// </summary>
[Serializable]
public enum PersistType
{
    /// <summary>
    /// Insert record in database.
    /// </summary>
    Insert = 1,

    /// <summary>
    /// Update record in database.
    /// </summary>
    Update = 2,

    /// <summary>
    /// Delete record from database.
    /// </summary>
    Delete = 3
}
