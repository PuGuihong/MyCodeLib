using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Common
{
    public static class EnumHelper
    {
        #region Field

        private static ConcurrentDictionary<Type, Dictionary<int, string>> enumDisplayValueDict = new ConcurrentDictionary<Type, Dictionary<int, string>>();
        private static ConcurrentDictionary<Type, Dictionary<string, int>> enumValueDisplayDict = new ConcurrentDictionary<Type, Dictionary<string, int>>();
        private static ConcurrentDictionary<Type, Dictionary<int, string>> enumNameValueDict = new ConcurrentDictionary<Type, Dictionary<int, string>>();
        private static ConcurrentDictionary<Type, Dictionary<string, int>> enumValueNameDict = new ConcurrentDictionary<Type, Dictionary<string, int>>();

        private static ConcurrentDictionary<Type, Dictionary<int, Tuple<string, int>>> enumSeqDisplayValueDict = new ConcurrentDictionary<Type, Dictionary<int, Tuple<string, int>>>();
        private static ConcurrentDictionary<string, Type> enumTypeDict = null;

        #endregion

        #region Method
        /// <summary>
        /// 获取枚举对象Key与显示名称的字典
        /// </summary>
        /// <param name="enumType"></param>
        /// <returns></returns>
        public static Dictionary<int, string> GetEnumDictionary(Type enumType)
        {
            if (!enumType.IsEnum)
                throw new Exception("给定的类型不是枚举类型");

            Dictionary<int, string> names = enumNameValueDict.ContainsKey(enumType) ? enumNameValueDict[enumType] : new Dictionary<int, string>();

            if (names.Count == 0)
            {
                names = GetEnumDictionaryItems(enumType);
                enumNameValueDict[enumType] = names;
            }
            return names;
        }

        private static Dictionary<int, string> GetEnumDictionaryItems(Type enumType)
        {
            FieldInfo[] enumItems = enumType.GetFields(BindingFlags.Public | BindingFlags.Static);
            Dictionary<int, string> names = new Dictionary<int, string>(enumItems.Length);

            foreach (FieldInfo enumItem in enumItems)
            {
                int intValue = (int)enumItem.GetValue(enumType);
                names[intValue] = enumItem.Name;
            }
            return names;
        }

        /// <summary>
        /// 获取枚举对象显示名称与Key的字典
        /// </summary>
        /// <param name="enumType"></param>
        /// <returns></returns>
        public static Dictionary<string, int> GetEnumValueNameItems(Type enumType)
        {
            if (!enumType.IsEnum)
                throw new Exception("给定的类型不是枚举类型");

            Dictionary<string, int> values = enumValueNameDict.ContainsKey(enumType) ? enumValueNameDict[enumType] : new Dictionary<string, int>();

            if (values.Count == 0)
            {
                values = TryToGetEnumValueNameItems(enumType);
                enumValueNameDict[enumType] = values;
            }
            return values;
        }

        private static Dictionary<string, int> TryToGetEnumValueNameItems(Type enumType)
        {
            FieldInfo[] enumItems = enumType.GetFields(BindingFlags.Public | BindingFlags.Static);
            Dictionary<string, int> values = new Dictionary<string, int>(enumItems.Length);

            foreach (FieldInfo enumItem in enumItems)
            {
                int intValue = (int)enumItem.GetValue(enumType);
                values[enumItem.Name] = intValue;
            }
            return values;
        }


        /// <summary>
        /// 获取枚举对象的值内容
        /// </summary>
        /// <param name="enumType"></param>
        /// <param name="display"></param>
        /// <returns></returns>
        public static int TryToGetEnumValueByName(this Type enumType, string name)
        {
            if (!enumType.IsEnum)
                throw new Exception("给定的类型不是枚举类型");
            Dictionary<string, int> enumDict = GetEnumValueNameItems(enumType);
            return enumDict.ContainsKey(name) ? enumDict[name] : enumDict.Select(d => d.Value).FirstOrDefault();
        }

        /// <summary>
        /// 获取枚举类型
        /// </summary>
        /// <param name="assembly"></param>
        /// <param name="typeName"></param>
        /// <returns></returns>
        public static Type TrytoGetEnumType(Assembly assembly, string typeName)
        {
            enumTypeDict = enumTypeDict ?? LoadEnumTypeDict(assembly);
            if (enumTypeDict.ContainsKey(typeName))
            {
                return enumTypeDict[typeName];
            }
            return null;
        }

        private static ConcurrentDictionary<string, Type> LoadEnumTypeDict(Assembly assembly)
        {
            Type[] typeArray = assembly.GetTypes();
            Dictionary<string, Type> dict = typeArray.Where(o => o.IsEnum).ToDictionary(o => o.Name, o => o);
            ConcurrentDictionary<string, Type> enumTypeDict = new ConcurrentDictionary<string, Type>(dict);
            return enumTypeDict;
        }

        #endregion
        /// <summary>
        /// 枚举显示名(属性扩展)
        /// </summary>
        public class EnumDisplayNameAttribute : Attribute
        {
            private string _displayName;

            public EnumDisplayNameAttribute(string displayName)
            {
                this._displayName = displayName;
            }

            public string DisplayName
            {
                get { return _displayName; }
            }
        }

        public class EnumExt
        {
            /// <summary>
            /// 根据枚举成员获取自定义属性EnumDisplayNameAttribute的属性DisplayName
            /// </summary>
            /// <param name="o"></param>
            /// <returns></returns>
            public static string GetEnumDisplayName(object o)
            {
                //获取枚举的Type类型对象
                Type t = o.GetType();

                //获取枚举的所有字段
                FieldInfo[] ms = t.GetFields();

                //遍历所有枚举的所有字段
                foreach (FieldInfo f in ms)
                {
                    if (f.Name != o.ToString())
                    {
                        continue;
                    }

                    //第二个参数true表示查找EnumDisplayNameAttribute的继承链
                    if (f.IsDefined(typeof(EnumDisplayNameAttribute), true))
                    {
                        return
                            (f.GetCustomAttributes(typeof(EnumDisplayNameAttribute), true)[0] as EnumDisplayNameAttribute)
                                .DisplayName;
                    }
                }

                //如果没有找到自定义属性，直接返回属性项的名称
                return o.ToString();
            }

            /// <summary>
            /// 根据枚举转换成SelectList
            /// </summary>
            /// <param name="enumType">枚举</param>
            /// <returns></returns>
            public static List<SelectListItem> GetSelectList(Type enumType)
            {
                List<SelectListItem> selectList = new List<SelectListItem>();
                foreach (object e in Enum.GetValues(enumType))
                {
                    selectList.Add(new SelectListItem() { Text = GetDescription(e), Value = ((int)e).ToString() });
                }
                return selectList;
            }
        }

        /// <summary>
        /// 根据枚举转换成SelectList并且设置默认选中项
        /// </summary>
        /// <param name="enumType"></param>
        /// <param name="ObjDefaultValue">默认选中项</param>
        /// <returns></returns>
        public static List<SelectListItem> GetSelectList(Type enumType, object ObjDefaultValue)
        {
            int defaultValue = Int32.Parse(ObjDefaultValue.ToString());
            List<SelectListItem> selectList = new List<SelectListItem>();
            foreach (object e in Enum.GetValues(enumType))
            {
                try
                {
                    if ((int)e == defaultValue)
                    {
                        selectList.Add(new SelectListItem() { Text = GetDescription(e), Value = ((int)e).ToString(), Selected = true });
                    }
                    else
                    {
                        selectList.Add(new SelectListItem() { Text = GetDescription(e), Value = ((int)e).ToString() });
                    }
                }
                catch (Exception ex)
                {
                    string exs = ex.Message;
                }
            }
            return selectList;
        }

        /// <summary>
        /// 根据枚举转换成SelectList
        /// </summary>
        /// <param name="enumType">枚举</param>
        /// <returns></returns>
        public static List<SelectListItem> GetSelectList(Type enumType)
        {
            List<SelectListItem> selectList = new List<SelectListItem>();
            foreach (object e in Enum.GetValues(enumType))
            {
                selectList.Add(new SelectListItem() { Text = GetDescription(e), Value = ((int)e).ToString() });
            }
            return selectList;
        }
        /// <summary>
        /// 根据枚举成员获取自定义属性EnumDisplayNameAttribute的属性DisplayName
        /// </summary>
        /// <param name="objEnumType"></param>
        /// <returns></returns>
        public static Dictionary<string, int> GetDescriptionAndValue(Type enumType)
        {
            Dictionary<string, int> dicResult = new Dictionary<string, int>();

            foreach (object e in Enum.GetValues(enumType))
            {
                dicResult.Add(GetDescription(e), (int)e);
            }

            return dicResult;
        }

        /// <summary>
        /// 根据枚举成员获取DescriptionAttribute的属性Description
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static string GetDescription(object o)
        {
            //获取枚举的Type类型对象
            Type t = o.GetType();

            //获取枚举的所有字段
            FieldInfo[] ms = t.GetFields();

            //遍历所有枚举的所有字段
            foreach (FieldInfo f in ms)
            {
                if (f.Name != o.ToString())
                {
                    continue;
                }
                ////  Description
                //  //第二个参数true表示查找EnumDisplayNameAttribute的继承链
                //  if (f.IsDefined(typeof(EnumDisplayNameAttribute), true))
                //  {
                //      return
                //        (f.GetCustomAttributes(typeof(EnumDisplayNameAttribute), true)[0] as EnumDisplayNameAttribute)
                //          .DisplayName;
                //  } 
                FieldInfo fi = o.GetType().GetField(o.ToString());
                try
                {
                    var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
                    return (attributes != null && attributes.Length > 0) ? attributes[0].Description : o.ToString();
                }
                catch
                {
                    return "(Unknow)";
                }
            }

            //如果没有找到自定义属性，直接返回属性项的名称
            return o.ToString();
        }

        #region 新增扩展方法

        /// <summary>  
        /// 扩展方法：根据枚举值得到相应的枚举定义字符串  
        /// </summary>  
        /// <param name="value"></param>  
        /// <param name="enumType"></param>  
        /// <returns></returns>  
        public static String ToEnumString(this int value, Type enumType)
        {
            NameValueCollection nvc = GetEnumStringFromEnumValue(enumType);
            return nvc[value.ToString()];
        }

        /// <summary>  
        /// 根据枚举类型得到其所有的 值 与 枚举定义字符串 的集合  
        /// </summary>  
        /// <param name="enumType"></param>  
        /// <returns></returns>  
        public static NameValueCollection GetEnumStringFromEnumValue(Type enumType)
        {
            NameValueCollection nvc = new NameValueCollection();
            Type typeDescription = typeof(DescriptionAttribute);
            System.Reflection.FieldInfo[] fields = enumType.GetFields();
            string strText = string.Empty;
            string strValue = string.Empty;
            foreach (FieldInfo field in fields)
            {
                if (field.FieldType.IsEnum)
                {
                    strValue = ((int)enumType.InvokeMember(field.Name, BindingFlags.GetField, null, null, null)).ToString();
                    nvc.Add(strValue, field.Name);
                }
            }
            return nvc;
        }

        /// <summary>  
        /// 扩展方法：根据枚举值得到属性Description中的描述, 如果没有定义此属性则返回空串  
        /// </summary>  
        /// <param name="value"></param>  
        /// <param name="enumType"></param>  
        /// <returns></returns>  
        public static String ToEnumDescriptionString(this int value, Type enumType)
        {
            NameValueCollection nvc = GetNVCFromEnumValue(enumType);
            return nvc[value.ToString()];
        }

        /// <summary>  
        /// 根据枚举类型得到其所有的 值 与 枚举定义Description属性 的集合  
        /// </summary>  
        /// <param name="enumType"></param>  
        /// <returns></returns>  
        public static NameValueCollection GetNVCFromEnumValue(Type enumType)
        {
            NameValueCollection nvc = new NameValueCollection();
            Type typeDescription = typeof(DescriptionAttribute);
            System.Reflection.FieldInfo[] fields = enumType.GetFields();
            string strText = string.Empty;
            string strValue = string.Empty;
            foreach (FieldInfo field in fields)
            {
                if (field.FieldType.IsEnum)
                {
                    strValue = ((int)enumType.InvokeMember(field.Name, BindingFlags.GetField, null, null, null)).ToString();
                    object[] arr = field.GetCustomAttributes(typeDescription, true);
                    if (arr.Length > 0)
                    {
                        DescriptionAttribute aa = (DescriptionAttribute)arr[0];
                        strText = aa.Description;
                    }
                    else
                    {
                        strText = "";
                    }
                    nvc.Add(strValue, strText);
                }
            }
            return nvc;
        }

        #endregion

    }
}
