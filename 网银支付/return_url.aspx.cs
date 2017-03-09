using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ReapalFastApiDemo
{
    public partial class return_url : System.Web.UI.Page
    {
    protected void Page_Load(object sender, EventArgs e)
        {
            string merchant_id = Request.Form["merchant_id"];
            string encryptData = Request.Form["data"];
            string encryptkey = Request.Form["encryptkey"];
            m1.InnerText = merchant_id+"====="+ encryptData + "====="+ encryptkey;


            // 私钥解密
            string itrus001pfx = HttpContext.Current.Server.MapPath("cert/itrus001.pfx");


            encryptkey = ReapalDemo.utils.RSADE.decryptData(encryptkey, itrus001pfx, "UTF-8");

            encryptData = ReapalDemo.utils.AESDE.Decrypt(encryptData, encryptkey);

            m2.InnerText = merchant_id + "#####" + encryptData + "#####" + encryptkey;
        }
        }
}