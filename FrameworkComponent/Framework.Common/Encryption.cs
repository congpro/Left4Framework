/***********************************************************************
 *  Copyright (C) 2011 Framework Corporation
 *  All rights reserved.
 * 
 *  Author:  Peter.Li
 *  Date:    2011-10-18 09:43:57
 *  Purpose: 
 * 
 * ***********************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;
using System.Security.Cryptography;
using System.IO;

namespace Framework.Common
{
    public static class Encryption
    {
        private static byte[] a = new byte[]
		{
			181, 
			44, 
			181, 
			40, 
			46, 
			168, 
			244, 
			49
		};

        private static byte[] b = new byte[]
		{
			107, 
			93, 
			249, 
			77, 
			56, 
			159, 
			62, 
			251
		};

        private static byte[] c = new byte[]
		{
			241, 
			209, 
			75, 
			4, 
			138, 
			97, 
			142, 
			47, 
			78, 
			169, 
			86, 
			189, 
			65, 
			250, 
			87, 
			72, 
			173, 
			14, 
			72, 
			20, 
			155, 
			215, 
			36, 
			139
		};

        private static byte[] d = new byte[]
        {
            128, 
            19, 
            107, 
            127, 
            217, 
            148, 
            105, 
            0
        };

        private static byte[] e = new byte[]
		{
			241, 
			209, 
			75, 
			4, 
			138, 
			97, 
			143, 
			56, 
			78, 
			169, 
			86, 
			189, 
			65, 
			250, 
			87, 
			72, 
			173, 
			14, 
			72, 
			20, 
			155, 
			215, 
			36, 
			139
		};

        private static byte[] f = new byte[]
		{
			128, 
			19, 
			107, 
			127, 
			213, 
			141, 
			105, 
			0
		};
        /// <summary>
        /// Hash算法，提供MD5、SHA1算法
        /// </summary>
        /// <param name="encryptingString">被Hash的字符串</param>
        /// <param name="encryptFormat">Hash算法，有"md5"、"sha1"、"clear"（明文，即不加密）等</param>
        /// <returns>Hash结果字符串</returns>
        /// <remarks>
        /// 当参数<paramref name="encryptFormat" />不为"md5"、"sha1"、"clear"时，直接返回参数<paramref name="encryptingString" />
        /// </remarks>
        public static string Encrypt(string encryptingString, string encryptFormat)
        {
            if (string.Compare(encryptFormat, "md5", true) == 0 || string.Compare(encryptFormat, "sha1", true) == 0)
            {
                return FormsAuthentication.HashPasswordForStoringInConfigFile(encryptingString, encryptFormat);
            }
            return encryptingString;
        }


        /// <summary>
        /// 按特定的方法加密字符串
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Encrypt(string str)
        {
            DESCryptoServiceProvider dESCryptoServiceProvider = new DESCryptoServiceProvider();
            byte[] bytes = Encoding.Unicode.GetBytes(str);
            dESCryptoServiceProvider.Key = Encryption.a;
            dESCryptoServiceProvider.IV = Encryption.b;
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, dESCryptoServiceProvider.CreateEncryptor(), CryptoStreamMode.Write);
            cryptoStream.Write(bytes, 0, bytes.Length);
            cryptoStream.FlushFinalBlock();
            StringBuilder stringBuilder = new StringBuilder();
            byte[] array = memoryStream.ToArray();
            for (int i = 0; i < array.Length; i++)
            {
                byte b = array[i];
                stringBuilder.AppendFormat("{0:X2}", b);
            }
            return stringBuilder.ToString();
        }

        /// <summary>
        /// 解密对应的字符串
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Decrypt(string str)
        {
            DESCryptoServiceProvider dESCryptoServiceProvider = new DESCryptoServiceProvider();
            byte[] array = new byte[str.Length / 2];
            for (int i = 0; i < str.Length / 2; i++)
            {
                int num = Convert.ToInt32(str.Substring(i * 2, 2), 16);
                array[i] = (byte)num;
            }
            dESCryptoServiceProvider.Key = Encryption.a;
            dESCryptoServiceProvider.IV = Encryption.b;
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, dESCryptoServiceProvider.CreateDecryptor(), CryptoStreamMode.Write);
            cryptoStream.Write(array, 0, array.Length);
            cryptoStream.FlushFinalBlock();
            return Encoding.Unicode.GetString(memoryStream.ToArray());
        }

        /// <summary>
        /// des加密字符串 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string EncryptTripleDES(string str)
        {
            TripleDESCryptoServiceProvider tripleDESCryptoServiceProvider = new TripleDESCryptoServiceProvider();
            byte[] bytes = Encoding.Unicode.GetBytes(str);
            tripleDESCryptoServiceProvider.Key = Encryption.c;
            tripleDESCryptoServiceProvider.IV = Encryption.d;
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, tripleDESCryptoServiceProvider.CreateEncryptor(), CryptoStreamMode.Write);
            cryptoStream.Write(bytes, 0, bytes.Length);
            cryptoStream.FlushFinalBlock();
            StringBuilder stringBuilder = new StringBuilder();
            byte[] array = memoryStream.ToArray();
            for (int i = 0; i < array.Length; i++)
            {
                byte b = array[i];
                stringBuilder.AppendFormat("{0:X2}", b);
            }
            return stringBuilder.ToString();
        }

        /// <summary>
        /// des解密字符串
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string DecryptTripleDES(string str)
        {
            TripleDESCryptoServiceProvider tripleDESCryptoServiceProvider = new TripleDESCryptoServiceProvider();
            byte[] array = new byte[str.Length / 2];
            for (int i = 0; i < str.Length / 2; i++)
            {
                int num = Convert.ToInt32(str.Substring(i * 2, 2), 16);
                array[i] = (byte)num;
            }
            tripleDESCryptoServiceProvider.Key = Encryption.c;
            tripleDESCryptoServiceProvider.IV = Encryption.d;
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, tripleDESCryptoServiceProvider.CreateDecryptor(), CryptoStreamMode.Write);
            cryptoStream.Write(array, 0, array.Length);
            cryptoStream.FlushFinalBlock();
            return Encoding.Unicode.GetString(memoryStream.ToArray());
        }

    }
}
