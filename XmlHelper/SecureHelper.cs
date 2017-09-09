using StringHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace XmlHelper
{
    /// <summary>
    /// 创建人员：puguihong
    /// 创建时间：2017年04月17日
    /// 创建说明：安全加密帮助类
    /// </summary>
    public class SecureHelper
    {
        #region 字段

        //AES密钥向量
        private static readonly byte[] _aeskeys = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF, 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
        //验证Base64字符串的正则表达式
        private static Regex _base64regex = new Regex(@"[A-Za-z0-9\=\/\+]");
        //防SQL注入正则表达式
        private static Regex _sqlkeywordregex = new Regex(@"(select|insert|delete|from|count\(|drop|table|update|truncate|asc\(|mid\(|char\(|xp_cmdshell|exec|master|net|local|group|administrators|user|or|and|-|;|,|\(|\)|\[|\]|\{|\}|%|\*|!|\')", RegexOptions.IgnoreCase);

        #endregion

        #region 方法
        /// <summary>
        /// AES加密
        /// </summary>
        /// <param name="encryptStr">加密字符串</param>
        /// <param name="encryptKey">密钥</param>
        /// <returns></returns>
        public static string AESEncrypt(string encryptStr, string encryptKey)
        {
            if (string.IsNullOrWhiteSpace(encryptStr))
                return string.Empty;

            encryptKey = Strings.SubString(encryptKey, 32);
            encryptKey = encryptKey.PadRight(32, ' ');

            //分组加密算法
            SymmetricAlgorithm des = Rijndael.Create();
            byte[] inputByteArray = Encoding.UTF8.GetBytes(encryptStr);//得到需要加密的字节数组 
            //设置密钥及密钥向量
            des.Key = Encoding.UTF8.GetBytes(encryptKey);
            des.IV = _aeskeys;
            byte[] cipherBytes = null;
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(inputByteArray, 0, inputByteArray.Length);
                    cs.FlushFinalBlock();
                    cipherBytes = ms.ToArray();//得到加密后的字节数组
                    cs.Close();
                    ms.Close();
                }
            }
            return Convert.ToBase64String(cipherBytes);
        }

        /// <summary>
        /// AES解密
        /// </summary>
        /// <param name="decryptStr">解密字符串</param>
        /// <param name="decryptKey">密钥</param>
        /// <returns></returns>
        public static string AESDecrypt(string decryptStr, string decryptKey)
        {
            if (string.IsNullOrWhiteSpace(decryptStr))
                return string.Empty;

            decryptKey = Strings.SubString(decryptKey, 32);
            decryptKey = decryptKey.PadRight(32, ' ');

            byte[] cipherText = Convert.FromBase64String(decryptStr);

            SymmetricAlgorithm des = Rijndael.Create();
            des.Key = Encoding.UTF8.GetBytes(decryptKey);
            des.IV = _aeskeys;
            byte[] decryptBytes = new byte[cipherText.Length];
            using (MemoryStream ms = new MemoryStream(cipherText))
            {
                using (CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Read))
                {
                    cs.Read(decryptBytes, 0, decryptBytes.Length);
                    cs.Close();
                    ms.Close();
                }
            }
            return Encoding.UTF8.GetString(decryptBytes).Replace("\0", "");//将字符串后尾的'\0'去掉
        }

        /// <summary>
        /// MD5散列
        /// </summary>
        public static string MD5(string inputStr)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] hashByte = md5.ComputeHash(Encoding.UTF8.GetBytes(inputStr));
            StringBuilder sb = new StringBuilder();
            foreach (byte item in hashByte)
                sb.Append(item.ToString("x").PadLeft(2, '0'));
            return sb.ToString();
        }

        /// <summary>
        /// 判断是否是Base64字符串
        /// </summary>
        /// <returns></returns>
        public static bool IsBase64String(string str)
        {
            if (str != null)
                return _base64regex.IsMatch(str);
            return true;
        }

        /// <summary>
        /// 加密算法
        /// </summary>
        /// <param name="pwdEncrypt">要加密的字符串</param>
        /// <param name="key">密钥</param>
        /// <returns></returns>
        public static string DesEncrypt(string decryptStr, string decryptKey)
        {
            if (string.IsNullOrEmpty(decryptStr)) return decryptStr;
            try
            {
                decryptKey = MD5(decryptKey).Substring(0, 8);
                byte[] data = Encoding.UTF8.GetBytes(decryptStr);
                DESCryptoServiceProvider DES = new DESCryptoServiceProvider();
                DES.Key = ASCIIEncoding.ASCII.GetBytes(decryptKey);
                DES.IV = ASCIIEncoding.ASCII.GetBytes(decryptKey);
                ICryptoTransform desencrypt = DES.CreateEncryptor();
                byte[] result = desencrypt.TransformFinalBlock(data, 0, data.Length);
                return BitConverter.ToString(result).Replace("-", "");
            }
            catch
            {
                return decryptStr;
            }
        }

        /// <summary>
        /// 解密算法
        /// </summary>
        /// <param name="pwdDecrypt">要解密的字符串</param>
        /// <param name="key">密钥 必须8位</param>
        /// <returns></returns>
        public static string DesDecrypt(string decryptStr, string decryptKey)
        {
            if (string.IsNullOrEmpty(decryptStr)) return decryptStr;
            try
            {
                decryptKey = MD5(decryptKey).Substring(0, 8);
                int len = decryptStr.Length / 2;
                byte[] data = new byte[len];
                for (int i = 0; i < len; i++)
                {
                    data[i] = byte.Parse(decryptStr.Substring(i * 2, 2), NumberStyles.HexNumber);
                }
                DESCryptoServiceProvider DES = new DESCryptoServiceProvider();
                DES.Key = ASCIIEncoding.ASCII.GetBytes(decryptKey);
                DES.IV = ASCIIEncoding.ASCII.GetBytes(decryptKey);
                ICryptoTransform desencrypt = DES.CreateDecryptor();
                byte[] result = desencrypt.TransformFinalBlock(data, 0, data.Length);
                return Encoding.UTF8.GetString(result);
            }
            catch
            {
                return string.Format("传入数据不是有效的Desm加密，传入:{0}", decryptStr);
            }
        }

        #endregion
    }
}
