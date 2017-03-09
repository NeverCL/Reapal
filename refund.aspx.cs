﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ReapalDemo.utils;
using System.Text;

namespace ReapalFastApiDemo
{
    public partial class refund : System.Web.UI.Page
    {
       

        protected void btnOK_Click(object sender, EventArgs e)
        {

            //公钥
            string itrus001cer = HttpContext.Current.Server.MapPath("cert/itrus001.cer");
            //私钥
            string itrus001pfx = HttpContext.Current.Server.MapPath("cert/itrus001.pfx");

            //商户Key值
            string user_key = "g0be2385657fa355af68b74e9913a1320af82gb7ae5f580g79bffd04a402ba8f";
            string url = "http://testapi.reapal.com/fast/refund";

            //组装请求参数
            SortedDictionary<string, string> dic = new SortedDictionary<string, string>();
            dic.Add("merchant_id", this.merchant_id.Text);
            dic.Add("order_no", "16"+ DateTime.Now.ToString("yyyyMMddHHmmss"));
            dic.Add("orig_order_no", this.orig_order_no.Text);
            dic.Add("version", this.version.Text);
            dic.Add("note", this.note.Text);
            dic.Add("amount", Convert.ToString(Math.Ceiling(Convert.ToDouble(this.amount.Text) * 100)));

            //执行提交请求，得到返回结果
            this.result.Text = ReapalSubmit.Post(dic, this.merchant_id.Text, user_key, url, itrus001cer, itrus001pfx);
        }

    }
}