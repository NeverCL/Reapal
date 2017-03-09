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
        string merchant_id = "100000000000147"; // 商户ID	String(16)	必须	商户在融宝的账户ID，
        string charset = "utf-8";               // 编码
        string seller_email = "850138237@qq.com";   // 商户邮箱	String	必须	签约融宝支付账号或卖家收款融宝支付帐户
        string notify_url = "http://www.aaabbb.com/reapal_notify.jsp";  // 商户后台系统的回调地址	String	必须	融宝服务器主动通知商户网站里指定的页面http路径
        string return_url = "http://localhost:1186/return_url.aspx";    // 商户前台系统的回调地址	String	必须	结果返回URL，仅适用于立即返回处理结果的接口。融宝处理完请求后，立即将处理结果返回给这个URL
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
            dic.Add("currency","156");  // 交易币种	String	可选	默认传156，目前仅支持人民币
            dic.Add("transtime", DateTime.Now.ToString("yyyyMMddHHmmss"));  // 交易时间	int	必须	时间戳，精确到秒，2015-03-06 12：24：59
            dic.Add("member_ip", "192.168.1.1");    // 用户IP	String(64)	必须	用户的IP地址
            dic.Add("terminal_info", "dsfsfsf");    // 终端信息	String	必须	手机IMEI地址、MAC地址、UUID 
            dic.Add("order_no", "1101" + DateTime.Now.ToString("yyyyMMddHHmmss"));  // 商户订单号	String	必须	商户生成的唯一订单号
            dic.Add("charset", this.charset);
            dic.Add("payment_type", "1");           // 支付类型	String	可选	支付方式为银行间连时：值为1支付方式为银行直连时：银行代码为B2B支付，值为1银行代码为B2C支付，1借记卡支付，2贷记卡支付
            dic.Add("sign_type", "MD5");            // 签名类型	String	可选	目前仅支持MD5

            dic.Add("member_id", this.member_id.Text);    // 用户ID	String	商户生成的用户ID
            dic.Add("title", this.title.Text);              // 商品名称	String(256)	必须	商品名称
            dic.Add("body", this.body.Text);                // 商品描述	String(400)	必须	商品的具体描述
            dic.Add("total_fee", Convert.ToString(Math.Ceiling(Convert.ToDouble(this.Rongmoney.Text) * 100)));  // 交易金额	int	必须	以“分”为单位的整数，必须大于零


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
            dic.Add("pay_method", pay_method);// 支付方式	String	可选	固定值 1.bankPay，银行间接支付，默认值；2.directPay ，银行直连

            //生成签名和加密数据
            Dictionary<string, string> dict = ReapalUtils.encryptData(dic, user_key, itrus001cer);
            String data = "";
            String encryptkey = "";
            dict.TryGetValue("encryptData", out data);      // 
            dict.TryGetValue("encryptKey", out encryptkey); // 密钥密文	string	必须	商户随机生成AESKey,用于AES加密（长度为16位，可以用26个字母和数字组成）


            Response.Redirect("payto.aspx?title=" + Server.UrlEncode(this.title.Text) + "&body=" + Server.UrlEncode(this.body.Text) + "&total_fee=" + Server.UrlEncode(this.Rongmoney.Text) + "&merchant_id=" + merchant_id + "&data=" + Server.UrlEncode(data) + "&encryptkey=" + Server.UrlEncode(encryptkey));
        }

    }
}