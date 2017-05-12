using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.IO;

namespace Common.PDFViewer
{

    /// <summary>
    /// TripleDES加密算法
    /// </summary>
    public class TripleDES
    {
        /// <summary>
        /// 加密(根据密匙使用TripleDES对密码进行加密)
        /// </summary>
        /// <param name="pass">密码</param>
        /// <param name="p_key">密匙</param>
        /// <returns></returns>
        public static string Encrypt(string pass, string p_key)
        {
            try
            {
                byte[] bt = (new System.Text.UnicodeEncoding()).GetBytes(pass);
                PasswordDeriveBytes pdb = new PasswordDeriveBytes(p_key, null);
                byte[] key = pdb.GetBytes(24);
                byte[] iv = pdb.GetBytes(8);
                MemoryStream ms = new MemoryStream();
                TripleDESCryptoServiceProvider tdesc = new TripleDESCryptoServiceProvider();
                CryptoStream cs = new CryptoStream(ms, tdesc.CreateEncryptor(key, iv),
CryptoStreamMode.Write);
                cs.Write(bt, 0, bt.Length);
                cs.FlushFinalBlock();
                return Convert.ToBase64String(ms.ToArray());
            }
            catch
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// 解密(根据密匙使用TripleDES对加密数据进行解密)
        /// </summary>
        /// <param name="str">加密数据</param>
        /// <param name="p_key">密匙</param>
        /// <returns></returns>
        public static string Decrypt(string str, string p_key)
        {
            try
            {
                byte[] bt = Convert.FromBase64String(str);
                PasswordDeriveBytes pdb = new PasswordDeriveBytes(p_key, null);
                byte[] key = pdb.GetBytes(24);
                byte[] iv = pdb.GetBytes(8);
                MemoryStream ms = new MemoryStream();
                TripleDESCryptoServiceProvider tdesc = new TripleDESCryptoServiceProvider();
                CryptoStream cs = new CryptoStream(ms, tdesc.CreateDecryptor(key, iv),
CryptoStreamMode.Write);
                cs.Write(bt, 0, bt.Length);
                cs.FlushFinalBlock();
                return (new System.Text.UnicodeEncoding()).GetString(ms.ToArray());
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}