using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Yang.Management.Base
{
    public class CutString
    {
        /// <summary>
        /// 截取字符串，保留其HTML格式
        /// </summary>
        /// <param name="strText"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        public static string CutWithSubstring(string strText, int len)
        {
            if (strText.Length > len)
            {
                return strText.Substring(0, len) + "…";
            }
            else
            {
                return strText;
            }
        }


        public static string ReplaceHtmlTag(string html, int length = 0)
        {
            string strText = System.Text.RegularExpressions.Regex.Replace(html, "<[^>]+>", "");
            strText = System.Text.RegularExpressions.Regex.Replace(strText, "&[^;]+;", "");

            if (length > 0 && strText.Length > length)
                return strText.Substring(0, length);

            return strText;
        }

        public static string LoseHtml(string ContentStr)
        {
            string ClsTempLoseStr = "";
            System.Text.RegularExpressions.Regex regEx = new System.Text.RegularExpressions.Regex("<\\/*[^<>]*>");
            ClsTempLoseStr = regEx.Replace(ContentStr, "");
            return ClsTempLoseStr;
        }

        /// <summary>
        /// 截取字符串去掉其HTML字符
        /// </summary>
        /// <param name="inputString"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        public static string CutWithOutHtml(string inputString, int len)
        {
            int tempLen = 0;
            string tempString = "";
            inputString = LoseHtml(inputString);
            ASCIIEncoding ascii = new ASCIIEncoding();

            byte[] s = ascii.GetBytes(inputString);
            for (int i = 0; i < s.Length; i++)
            {
                if ((int)s[i] == 63)
                {
                    tempLen += 2;
                }
                else
                {
                    tempLen += 1;
                }

                try
                {
                    tempString += inputString.Substring(i, 1);
                }
                catch
                {
                    break;
                }

                if (tempLen > len)
                    break;
            }
            //如果截过则加上半个省略号
            byte[] mybyte = System.Text.Encoding.Default.GetBytes(inputString);
            if (mybyte.Length > len)
            {
                tempString = tempString.Substring(0, tempString.Length - 3 == 0 ? 1 : tempString.Length - 3) + "…";
            }
            return tempString;
        }
    }
}