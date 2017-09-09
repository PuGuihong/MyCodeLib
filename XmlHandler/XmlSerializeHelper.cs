using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XmlHandler
{
    /// <summary>
    /// XML 序列化帮助类
    /// </summary>
    public class XmlSerializeHelper
    {
        private XmlSerializeHelper()
        {
        }

        /// <summary>
        /// 静态变量，用于保存类的实例
        /// </summary>
        private static XmlSerializeHelper _instance;

        /// <summary>
        /// 线程标志，确保线程同步
        /// </summary>
        private static object _locker = new object();
        public static XmlSerializeHelper Instance
        {
            get
            {
                //实例不存在则创建
                if (_instance == null)
                {
                    //当线程来的时候进程先挂起
                    lock (_locker)
                    {
                        if (_instance == null)
                        {
                            _instance = new XmlSerializeHelper();
                        }
                    }
                }
                return _instance;
            }
        }

        /// <summary>
        /// 序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public string XmlSerialize<T>(T obj)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                serializer.Serialize(ms, obj);
                ms.Seek(0, SeekOrigin.Begin);
                using (StreamReader reader = new StreamReader(ms, Encoding.UTF8))
                {
                    return reader.ReadToEnd();
                }
            }
        }

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="xmlOfObject"></param>
        /// <returns></returns>

        public T XmlDeserialize<T>(string xmlOfObject) where T : class
        {
            using (MemoryStream ms = new MemoryStream())
            {
                using (StreamWriter sr = new StreamWriter(ms, Encoding.UTF8))
                {
                    sr.Write(xmlOfObject);
                    sr.Flush();
                    ms.Seek(0, SeekOrigin.Begin);
                    XmlSerializer serializer = new XmlSerializer(typeof(T));
                    return serializer.Deserialize(ms) as T;
                }
            }
        }
    }
}
