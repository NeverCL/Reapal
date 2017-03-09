using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ReapalDemo.utils;
using System.Text;

namespace ReapalFastApiDemo
{
    public partial class certificateTo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string merchant_id = Request.Form["merchant_id"];
            string data = Request.Form["data"];
            string encryptkey = Request.Form["encryptkey"];
        }

    }
}