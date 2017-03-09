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

    public partial class certificate : System.Web.UI.Page
    {
        string merchant_id = "100000000000147";

        string charset = "utf-8";
        string seller_email = "850138237@qq.com";
        string notify_url = "http://10.168.15.30:1186/notifyUrl.aspx";
        string return_url = "http://10.168.15.30:1186/index.aspx";
        //string certify_return_url = "http:localhost:8080/index.aspx";
        protected void btnOK_Click(object sender, EventArgs e)
        {
            //公钥
            string itrus001cer = HttpContext.Current.Server.MapPath("cert/itrus001.cer");
            //私钥
            string itrus001pfx = HttpContext.Current.Server.MapPath("cert/itrus001.pfx");
            //地址
            //商户Key值
            string user_key = "g0be2385657fa355af68b74e9913a1320af82gb7ae5f580g79bffd04a402ba8f";

            //请求参数
            SortedDictionary<string, string> dic = new SortedDictionary<string, string>();
            dic.Add("merchant_id", this.merchant_id);
            dic.Add("member_id", this.member_id.Text);
            dic.Add("bind_id", this.bind_id.Text);
            dic.Add("order_no", this.order_no.Text);
            dic.Add("terminal_type", this.terminal_type.Text);
            dic.Add("notify_url", this.notify_url);
            dic.Add("return_url", this.return_url);
            //dic.Add("sign_type", "MD5");
            dic.Add("version", "3.1.3");


            //生成签名和加密数据
            Dictionary<string, string> dict = ReapalUtils.encryptData(dic, user_key, itrus001cer);
            String data = "";
            String encryptkey = "";
            dict.TryGetValue("encryptData", out data);
            dict.TryGetValue("encryptKey", out encryptkey);

            Response.Redirect("certificateTo.aspx?merchant_id=" + merchant_id + "&data=" + Server.UrlEncode(data) + "&encryptkey=" + Server.UrlEncode(encryptkey));
        }

    }
}