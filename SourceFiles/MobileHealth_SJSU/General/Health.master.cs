using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class General_Health : System.Web.UI.MasterPage
{
    public void DataFromPageLabelControl(string value)
    {
        switch (value)
        {
            case "Doctor":
                Menu1.DataSourceID = SiteMapDataSource2.ID;
                break;
            case "Patient":
                Menu1.DataSourceID = SiteMapDataSource1.ID;
                break;
        }
    }
}