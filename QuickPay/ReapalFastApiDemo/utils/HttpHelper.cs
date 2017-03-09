using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ReapalDemo.utils
{
    public class HttpHelper
    {
        public HttpHelper() { }


        public static string PostData(string url, NameValueCollection data, Encoding encoding, Encoding responseEncoding)
        {
            WebClient client = new WebClient();
            client.Encoding = encoding ?? Encoding.UTF8;
            byte[] response = client.UploadValues(url, "POST", data ?? new NameValueCollection());
            string html = string.Empty;

            if (responseEncoding == null)
            {
                html = client.Encoding.GetString(response);
            }
            else
            {
                html = responseEncoding.GetString(response);
            }
            return html;
        }

        public static string PostData(string url, Dictionary<string, string> data, Encoding encoding, Encoding responseEncoding)
        {
            NameValueCollection postData = new NameValueCollection();
            if (data != null)
            {
                foreach (var item in data)
                {
                    postData.Add(item.Key, item.Value);
                }
            }
            return PostData(url, postData, encoding, responseEncoding);
        }

        public static string PostData(string url, Dictionary<string, string> data, Encoding encoding)
        {
            return PostData(url, data, encoding, null);
        }
    }
}