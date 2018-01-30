using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Drawing;
using System.Web.Security;
using System.Web.UI;
using System.Web;
namespace BLL
{
    public enum Target
    {
        _blank, _self, _parent, _top
    }
  public static   class CommonFuncs
    {
        /// <summary>
        /// 显示错误提示对话框
        /// </summary>
        /// <param name="msg">错误提示信息</param>
        public static void ShowMsg(Page page, string msg)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "error", "<script>alert('" + msg + "');</script>");
        }

        /// <summary>
        /// 显示一个消息，确定后跳转到指定页面
        /// </summary>
        /// <param name="pge">调用页</param>
        /// <param name="msg">要显示的消息</param>
        /// <param name="url">要跳转的URL页面</param>
        /// <param name="target">在哪里打开新窗口</param>
        public static void ShowMsgAndJump(Page pge, string msg, string url, Target target)
        {
            HttpContext.Current.Response.Write("<form name=yan action='" + url + "' target='" + target + "' method='post'><script>alert('" + msg + "');yan.submit();</script></form>");
            return;
        }

        /// <summary>
        /// 检查是否为数字构成的字符串的函数，参数是字符串
        /// </summary>
        /// <param name="str">待检查的字符串</param>
        /// <returns>返回true或false</returns>
        public static bool isNumeric(string str)
        {
            int n = str.Length;
            for (int i = 0; i < n; i++)
            {
                int ascValue = (int)(Convert.ToChar(str.Substring(i, 1)));
                if (ascValue > 57 || ascValue < 48)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 检查是否为ID（字母、数字、下划线）的函数，参数是字符串
        /// </summary>
        /// <param name="str">待检查的字符串</param>
        /// <returns>返回true或false</returns>
        public static bool isID(string str)
        {
            int n = str.Length;
            if (n == 0)
            {
                return false;
            }
            for (int i = 0; i < n; i++)
            {
                int asc = (int)(Convert.ToChar(str.Substring(i, 1)));
                //ASCII码：0--9(48--57)、A--Z(65--90)、_（95）、a--z(97--122)、、
                if (asc < 48 || (asc > 57 && asc < 65) || (asc > 90 && asc < 95) || (asc > 95 && asc < 97) || asc > 122)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 过滤危险字符
        /// </summary>
        /// <param name="str">待过滤的字符串</param>
        /// <returns>过滤后</returns>
        public static string filterChar(string str)
        {
            str = str.Replace("'", ""); //单引号
            str = str.Replace("-", "—");   //注释符号
            str = str.Replace("\"", "＂");
            //str = str.Replace("<%", "〈%");
            str = str.Replace("<", "〈");
            return str;
        }

    
    }
}
