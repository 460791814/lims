using System;
using System.Configuration;
namespace DAL
{
    
    public class PubConstant
    {
        public static  string connection
        {
            get
            {
                return GetConnectionValue();
            }
        }

        /// <summary>
        /// 得到web.config里配置项的数据库连接字符串。
        /// </summary>
        /// <param name="configName"></param>
        /// <returns></returns>
        public static string GetConnectionString()
        {

            return GetConnectionValue();
        }
        /// <summary>
        /// 得到web.config里配置项的数据库连接字符串。
        /// </summary>
        /// <param name="configName"></param>
        /// <returns></returns>
        public static string GetConnectionString(string Connection)
        {


            return GetConnectionValue();
        }
        public static string GetConfigValue(string strkey)
        {
            string strValue = string.Empty;
            if (strkey != null)
            {
                //读取webconfig配置文件中AppSettings节点中strKey的值
                strValue = ConfigurationManager.AppSettings[strkey].ToString();
            }
            return strValue;
        }
        private static string GetConnectionValue()
        {
            string strValue = string.Empty;
             //读取webconfig配置文件中AppSettings节点中strKey的值
            strValue = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
              return strValue;
        }
    }
}
