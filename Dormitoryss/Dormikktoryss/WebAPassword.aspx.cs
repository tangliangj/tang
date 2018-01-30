using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dormikktoryss
{
    public partial class WebAPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Model.Administrator admin = Session["Administrator"] as Model.Administrator;

            if (admin == null)
                Response.Redirect("~/WebDefault.aspx");
        }
        /// <summary>
        /// 方法：对密码进行MD5加密
        /// </summary>
        /// <param name="pwd">原始密码</param>
        /// <returns>加密后的密码</returns>
        private string Encryption(string pwd)
        {
            System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(pwd);
            bytes = md5.ComputeHash(bytes);
            return BitConverter.ToString(bytes);
        }
        protected void btnSavePwd_Click(object sender, EventArgs e)
        {
            Model.Administrator admin = new Model.Administrator();
            string oldpwd=((Model.Administrator)Session["Administrator"]).APassword;
            string  oldpwd2=Encryption(txtOldPwd.Text);
            if (oldpwd !=oldpwd2 )
            {
                Response.Write("<script>alert('原密码输入错误！')</script>");
                return;
            }

            admin.AdminID = ((Model.Administrator)Session["Administrator"]).AdminID;
            admin.APassword = txtNewPwd.Text;

            string str = new BLL.AdministratorBLL().UpdateAdministratorBLL(admin);

            if (str.Contains("成功"))
            {
                Session["Customer"] = null;
                Response.Redirect("~/WebLogin.aspx");
            }
            else
                lblMsg.Text = str;
        }
    }
}