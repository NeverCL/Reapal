using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace ReapalDemo.utils
{
    public class ReapalUtils
    {
        public static Dictionary<string, string> encryptData(SortedDictionary<string, string> dict, string userKey, string itrus001cer)
        {
            //排序，生成签名
            string signStr = MD5DE.GetSign(dict, userKey);
            dict.Add("sign", signStr);

            //序列化json
            string json = JsonHelper.JsonSerialize(dict, true);

            //加密业务数据--用AES对称加密算法
            string aesKey = AESDE.GenerateAESKey();
            string encryptData = AESDE.Encrypt(json, aesKey);

            //加密AESKey--用RSA非对称加密算法
            string encryptKey = RSADE.encryptData(aesKey, itrus001cer, "UTF-8");

            //组装post数据
            Dictionary<string, string> dicpost = new Dictionary<string, string>();
            dicpost.Add("encryptData", encryptData);
            dicpost.Add("encryptKey", encryptKey);

            return dicpost;
        }

        public static SortedDictionary<string, string> decryptData(string encryptData, string encryptKey, string userKey, string itrus001pfx)
        {
            //用非对称算法解密，得到key值的明文
            string decryKey = RSADE.decryptData(encryptKey, itrus001pfx, "UTF-8");
            //用对称算法解密，得到业务数据明文
            string decryData = AESDE.Decrypt(encryptData, decryKey);

            //JSON反序列化
            SortedDictionary<string, string> dict = JsonHelper.JsonDeserialize<SortedDictionary<string, string>>(decryData);
            
            //排序，生成签名
            string signStr = MD5DE.GetSign(dict, userKey);
            dict.Add("mySign", signStr);

            return dict;
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