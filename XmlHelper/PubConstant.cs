using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlHelper
{
    /// <summary>
    /// 创建人员：puguihong
    /// 创建时间：2017年04月17日
    /// 功能概要：数据连接控制器
    /// </summary>
    public class PubConstant
    {
        /// <summary>
        /// Xml 数据库连接字符串
        /// </summary>
        public static string ConnectionString
        {
            get
            {
                string _connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                string ConStringEncrypt = ConfigurationManager.ConnectionStrings["ConStringEncrypt"].ConnectionString;
                if (ConStringEncrypt == "true")
                {
                    _connectionString = SecureHelper.DesDecrypt(_connectionString, SecretKey.CommonKey);
                }
                return _connectionString;
            }
        }

        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        public static string CyConnectionString
        {
            get
            {
                string _cyConnectionString = ConfigurationManager.ConnectionStrings["CyConnectionString"].ConnectionString;
                string CyConStringEncrypt = ConfigurationManager.ConnectionStrings["CyConStringEncrypt"].ConnectionString;
                if (CyConStringEncrypt == "true")
                {
                    _cyConnectionString = SecureHelper.DesDecrypt(_cyConnectionString, SecretKey.CommonKey);
                }
                return _cyConnectionString;
            }
        }
    }
}
