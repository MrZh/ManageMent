using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Yang.Management.Entity
{
    public class CommonEncrypt
    {
        /// <summary>
        /// 密钥
        /// </summary>
        private static readonly string pkey = "smkldospdosldaaa";//key，可自行修改

        /// <summary>
        /// 偏移量
        /// </summary>
        private static readonly string piv = "0392039203920300"; //偏移量,可自行修改

        /// <summary>
        /// 根据默认密钥和偏移量加密
        /// </summary>
        /// <param name="toEncrypt">源字符串</param>
        /// <returns>密码</returns>
        public static string Encrypt(string toEncrypt)
        {
            var key = pkey;
            var iv = piv;
            var keyArray = Encoding.UTF8.GetBytes(key);
            var ivArray = Encoding.UTF8.GetBytes(iv);
            var toEncryptArray = Encoding.UTF8.GetBytes(toEncrypt);
            var rDel = new RijndaelManaged
            {
                BlockSize = 128,
                KeySize = 256,
                FeedbackSize = 128,
                Padding = PaddingMode.PKCS7,
                Key = keyArray,
                IV = ivArray,
                Mode = CipherMode.CBC
            };

            var cTransform = rDel.CreateEncryptor();
            var resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }

        /// <summary>
        /// 根据密钥和偏移量加密
        /// </summary>
        /// <param name="toEncrypt">源字符串</param>
        /// <param name="key">密钥</param>
        /// <param name="iv">偏移量</param>
        /// <returns>密码</returns>
        public static string Encrypt(string toEncrypt, string key, string iv)
        {
            var keyArray = Encoding.UTF8.GetBytes(key);
            var ivArray = Encoding.UTF8.GetBytes(iv);
            var toEncryptArray = Encoding.UTF8.GetBytes(toEncrypt);
            var rDel = new RijndaelManaged
            {
                BlockSize = 128,
                KeySize = 256,
                FeedbackSize = 128,
                Padding = PaddingMode.PKCS7,
                Key = keyArray,
                IV = ivArray,
                Mode = CipherMode.CBC
            };

            var cTransform = rDel.CreateEncryptor();
            var resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }

        /// <summary>
        /// 根据默认密钥和偏移量解密
        /// </summary>
        /// <param name="toDecrypt">密码</param>
        /// <returns>源字符串</returns>
        public static string Decrypt(string toDecrypt)
        {
            var key = pkey;
            var iv = piv;
            var keyArray = Encoding.UTF8.GetBytes(key);
            var ivArray = Encoding.UTF8.GetBytes(iv);
            var toEncryptArray = Convert.FromBase64String(toDecrypt);
            var rDel = new RijndaelManaged
            {
                BlockSize = 128,
                KeySize = 256,
                FeedbackSize = 128,
                Padding = PaddingMode.PKCS7,
                Key = keyArray,
                IV = ivArray,
                Mode = CipherMode.CBC
            };

            var cTransform = rDel.CreateDecryptor();
            var resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            return Encoding.UTF8.GetString(resultArray);
        }

        /// <summary>
        /// 根据密钥和偏移量解密
        /// </summary>
        /// <param name="toDecrypt">密码</param>
        /// <param name="key">密钥</param>
        /// <param name="iv">偏移量</param>
        /// <returns>源字符串</returns>
        public static string Decrypt(string toDecrypt, string key, string iv)
        {
            var keyArray = Encoding.UTF8.GetBytes(key);
            var ivArray = Encoding.UTF8.GetBytes(iv);
            var toEncryptArray = Convert.FromBase64String(toDecrypt);
            var rDel = new RijndaelManaged
            {
                BlockSize = 128,
                KeySize = 256,
                FeedbackSize = 128,
                Padding = PaddingMode.PKCS7,
                Key = keyArray,
                IV = ivArray,
                Mode = CipherMode.CBC
            };

            var cTransform = rDel.CreateDecryptor();
            var resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            return Encoding.UTF8.GetString(resultArray);
        }
    }
}
