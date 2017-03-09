using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReapalDemo.utils
{
    public class JsonHelper
    {
        public JsonHelper() { }

        /// <summary>
        /// 序列化json
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="blnIsThrowError"></param>
        /// <returns></returns>
        public static string JsonSerialize(object obj, bool blnIsThrowError)
        {

            try
            {
                string strRt = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
                return strRt;
            }
            catch (Exception ex)
            {
                if (blnIsThrowError)
                {
                    throw ex;
                }
                string strErrorMsg = string.Format("序列化对象时发生异常，对象类型：{0}\n异常信息：{1}\n堆栈信息：{2}", obj.GetType(), ex.Message, ex.StackTrace);
                return strErrorMsg;
            }

        }

        /// <summary>
        /// JSON反序列化
        /// </summary>
        /// <typeparam name="T">需要反序列化的类型</typeparam>
        /// <param name="str">JSON字符串</param>
        /// <returns>反序列化后的对象</returns>
        public static T JsonDeserialize<T>(string strJSON)
        {
            T t = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(strJSON);
            return t;
        }

    }
}