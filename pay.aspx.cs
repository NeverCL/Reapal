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

    public partial class pay : System.Web.UI.Page
    {
        string merchant_id = "100000000000147";
        string charset = "utf-8";
        string seller_email = "850138237@qq.com";
        string notify_url = "http://www.aaabbb.com/reapal_notify.jsp";
        string return_url = "http://localhost:1186/return_url.aspx";
        protected void btnOK_Click(object sender, EventArgs e)
        {
            //公钥
            string itrus001cer = HttpContext.Current.Server.MapPath("cert/itrus001.cer");
            //私钥
            string itrus001pfx = HttpContext.Current.Server.MapPath("cert/itrus001.pfx");
            //地址
			string url = "http://testapi.reapal.com/account/portal";
            //商户Key值
            string user_key = "g0be2385657fa355af68b74e9913a1320af82gb7ae5f580g79bffd04a402ba8f";

            //请求参数
            SortedDictionary<string, string> dic = new SortedDictionary<string, string>();
            dic.Add("merchant_id",this.merchant_id);
            dic.Add("seller_email",this.seller_email);
            dic.Add("notify_url",this.notify_url);
            dic.Add("return_url",this.return_url);
            dic.Add("currency","156");
            dic.Add("transtime", DateTime.Now.ToString("yyyyMMddHHmmss"));
            dic.Add("member_ip", "192.168.1.1");
            dic.Add("terminal_info", "dsfsfsf");
            dic.Add("order_no", "1101" + DateTime.Now.ToString("yyyyMMddHHmmss"));
            dic.Add("charset", this.charset);
            dic.Add("payment_type", "1");
            dic.Add("sign_type", "MD5");

            dic.Add("member_id", this.member_id.Text);    
            dic.Add("title", this.title.Text);
            dic.Add("body", this.body.Text);
            dic.Add("total_fee", Convert.ToString(Math.Ceiling(Convert.ToDouble(this.Rongmoney.Text) * 100)));


            string xx = HttpContext.Current.Request.Form["defaultbank2"];
            string pay_method = "";
            string deafultbank = "";
            if (xx == "1")
            {
                pay_method = "directPay";
                if (HttpContext.Current.Request.Form["defaultbank"] != null) {
                    deafultbank = HttpContext.Current.Request.Form["defaultbank"];
                }
                dic.Add("default_bank", deafultbank);
            }
            else {
                pay_method = "bankPay";
            }
            dic.Add("pay_method", pay_method);

            //生成签名和加密数据
            Dictionary<string, string> dict = ReapalUtils.encryptData(dic, user_key, itrus001cer);
            String data = "";
            String encryptkey = "";
            dict.TryGetValue("encryptData", out data);
            dict.TryGetValue("encryptKey", out encryptkey);


            Response.Redirect("payto.aspx?title=" + Server.UrlEncode(this.title.Text) + "&body=" + Server.UrlEncode(this.body.Text) + "&total_fee=" + Server.UrlEncode(this.Rongmoney.Text) + "&merchant_id=" + merchant_id + "&data=" + Server.UrlEncode(data) + "&encryptkey=" + Server.UrlEncode(encryptkey));
        }

    }
}