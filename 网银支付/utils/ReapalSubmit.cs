using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace ReapalDemo.utils
{
    public class ReapalSubmit
    {
        public static string Post(SortedDictionary<string, string> dic, string merchant_id, string user_key, string url, string itrus001cer, string itrus001pfx)
        {
            //排序，生成签名
            string signStr = MD5DE.GetSign(dic, user_key);
            dic.Add("sign", signStr);

            //序列化json
            string json = JsonHelper.JsonSerialize(dic, true);

            //加密业务数据--用AES对称加密算法
            string AESKey = AESDE.GenerateAESKey();
            string strData = AESDE.Encrypt(json, AESKey);

            //加密AESKey--用RSA非对称加密算法
            string strKey = RSADE.encryptData(AESKey, itrus001cer, "UTF-8");

            //组装post数据
            Dictionary<string, string> dicpost = new Dictionary<string, string>();
            dicpost.Add("data", strData);
            dicpost.Add("encryptkey", strKey);
            dicpost.Add("merchant_id", merchant_id);
            //dicpost.Add("version", "1.0");

            //执行Post请求，得到返回参数密文
            string data = HttpHelper.PostData(url, dicpost, Encoding.UTF8);

            Dictionary<string, string> _dictionary = JsonHelper.JsonDeserialize<Dictionary<string, string>>(data);

            string encryptkey = "";
            string encryptData = "";

           Boolean mm = _dictionary.TryGetValue("encryptkey", out encryptkey);

            //用非对称算法解密，得到key值的明文
            if (_dictionary.TryGetValue("encryptkey", out encryptkey))
            {
                encryptkey = RSADE.decryptData(encryptkey, itrus001pfx, "UTF-8");
            }
            //用对称算法解密，得到业务数据明文
            if (_dictionary.TryGetValue("data", out encryptData))
            {
                encryptData = AESDE.Decrypt(encryptData, encryptkey);
            }

            return encryptData;
        }

        public static string getIp()
        {
            if (System.Web.HttpContext.Current.Request.ServerVariables["HTTP_VIA"] != null)
                return System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].Split(new char[] { ',' })[0];
            else
                return System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
        }
    }
}