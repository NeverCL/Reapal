using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ReapalDemo.utils;
using System.Text;

namespace ReapalFastHtml5Demo
{
    public partial class notifyUrl : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string merchant_id = Request["merchant_id"];
            string data = Request["data"];
            string encryptkey = Request["encryptkey"];

            //私钥
            string itrus001pfx = HttpContext.Current.Server.MapPath("cert/itrus001.pfx");
            //商户Key值
            string user_key = "e977ade964836408243b5g2444848f7b39d09fb41c77ae2e327ffb16f905e117";

            //解析密文数据
            SortedDictionary<string, string> dict = ReapalUtils.decryptData(data, encryptkey, user_key, itrus001pfx);


            //生成签名和加密数据
            string sign = "";
            string mySign = "";
            string status = "";
            dict.TryGetValue("sign",out sign);
            dict.TryGetValue("mySign", out mySign);
            dict.TryGetValue("status", out status);

            String verifyStatus = "";
            //建议校验签名，判读该返回结果是否由融宝发出
            if (mySign.Equals(sign))
            {
                //——请根据您的业务逻辑来编写程序（以下代码仅作参考）——	
                if (status.Equals("TRADE_FINISHED"))
                {
                    //支付成功，如果没有做过处理，根据订单号（out_trade_no）及金额（total_fee）在商户网站的订单系统中查到该笔订单的详细，并执行商户的业务程序
                    //一定要做金额判断，防止恶意窜改金额，只支付了小金额的订单。
                    //如果已做过处理，不执行商户的业务程序
                }
                else
                {
                    //支付失败处理相关订单
                }

                verifyStatus = "success";
                //——请根据您的业务逻辑来编写程序（以上代码仅作参考）——
            }
            else
            {
                verifyStatus = "fail";
            }

            Response.Write(verifyStatus);
        }

    }
}