using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ReapalDemo.utils
{
    public class MD5DE
    {
        public MD5DE()
        { }
        /// <summary>
        /// 拼接sign
        /// </summary>
        /// <param name="dic"></param>
        /// <param name="key"></param>
        /// <returns></returns>

        public static string GetSign(SortedDictionary<string, string> dic, string key)
        {
            string sign = "";

            foreach (var item in dic)
            {
                if (!item.Key.Equals("sign") && !item.Key.Equals("sign_type"))
                    sign += item.Key + "=" + item.Value + "&";
            }
        
            //加密Md5
            return MD5(sign.Trim('&') + key);
        }

        /// <summary>
        /// MD5
        /// </summary> 
        /// <returns></returns>
        public static string GetMD5( string myString )
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = System.Text.Encoding.Unicode.GetBytes( myString );
            byte[] targetData = md5.ComputeHash( fromData );
            string byte2String =  null;

            for (int   i=0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString( "x2" );
            }

            return byte2String;
        }

        public static string MD5Encrypt(string strText)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] result = md5.ComputeHash(System.Text.Encoding.Default.GetBytes(strText));
            return Encoding.UTF8.GetString(result);
        }

        public static string MD5(string strvalue)
        {
           string md5= System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(strvalue, "MD5").ToLower();

           return md5;
        }
    }
}