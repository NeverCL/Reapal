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
    public partial class debit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.merchant_id.Text = "100000000000147";
                this.total_fee.Text = "1.00"; //订单金额
                this.order_no.Text = "order_" + DateTime.Now.ToString("yyyyMMddHHmmss");	//商家订单号
            }
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            //公钥
            string itrus001cer = HttpContext.Current.Server.MapPath("cert/itrus001.cer");
            //私钥
            string itrus001pfx = HttpContext.Current.Server.MapPath("cert/itrus001.pfx");
            //地址
            string url = "http://testapi.reapal.com/fast/same/debit/portal";
            //商户Key值
            string user_key = "g0be2385657fa355af68b74e9913a1320af82gb7ae5f580g79bffd04a402ba8f";

            //请求参数
            SortedDictionary<string, string> dic = new SortedDictionary<string, string>();
            dic.Add("merchant_id", this.merchant_id.Text);      
            dic.Add("card_no", this.card_no.Text);
            dic.Add("owner", this.owner.Text);
            dic.Add("cert_type", "01");                         //证件类型  01 身份证
            dic.Add("cert_no", this.cert_no.Text);
            dic.Add("phone", this.phone.Text);
            dic.Add("order_no", this.order_no.Text);
            dic.Add("transtime", DateTime.Now.ToString("yyyyMMddHHmmss"));
            dic.Add("currency", "156");                         //币种  156人民币
            dic.Add("total_fee", Convert.ToString(Math.Ceiling(Convert.ToDouble(this.total_fee.Text) * 100)));  //金额转换为分
            dic.Add("title", "yyyyy");
            dic.Add("body", "yyyy");
            dic.Add("member_id", this.member_id.Text);
            dic.Add("terminal_type", "mobile");
            dic.Add("terminal_info", "dddsfffddd");
            dic.Add("member_ip", ReapalSubmit.getIp());
            dic.Add("seller_email", "820061154@qq.com");

            //执行提交请求，得到返回结果
            this.result.Text = ReapalSubmit.Post(dic, this.merchant_id.Text, user_key, url, itrus001cer, itrus001pfx);
        }

    }
}