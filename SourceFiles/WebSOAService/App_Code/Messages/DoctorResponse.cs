using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Serialization;

/// <summary>
/// Summary description for PatientResponse
/// </summary>
/// 
[Serializable]
[XmlInclude(typeof(DoctorTransferObject))]
public class DoctorResponse:ResponseBase
{
    public DataSet ds;
    

    public DoctorTransferObject Doc;
   
}
