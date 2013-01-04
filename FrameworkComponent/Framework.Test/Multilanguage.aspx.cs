using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

using Framework.Multilanguage;
using System.Collections.Specialized;


public partial class Multilanguage : System.Web.UI.Page
{
    //NameValueCollection languagelist = new NameValueCollection();
    Hashtable languagelist = new Hashtable();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        languagelist = ResourceManager.GetSupportedLanguages();
        bindtest();
        ResourceTest();
    }

    public void bindtest()
    {
        this.DropDownList1.DataSource = languagelist;
        this.DropDownList1.DataTextField = "value";
        this.DropDownList1.DataValueField = "key";
        this.DropDownList1.DataBind();
    }

    public void ResourceTest()
    {
        string str = string.Empty;
        str = ResourceManager.GetString("ACTIVEUSERS.LOGGED_IN");
        Response.Write(str);
        Response.Write("</br>");

        string str1 = ResourceManager.GetString("ACTIVEUSERS.ACTIVE");
        Response.Write(str1);
    }
}