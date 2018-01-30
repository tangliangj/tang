using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dormikktoryss
{
    public partial class WebLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //读取管理员Cookie信息
                if ((Request.Cookies.Count > 0) && (Request.Cookies["Account"] != null))
                    txtID.Text = Request.Cookies["Account"].Value as string;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //验证账号和密码：返回一个对象或字符串
            Model.Administrator admin = new BLL.AdministratorBLL().Login(txtID.Text.Trim().ToLower(), txtPwd.Text);

            if (string.IsNullOrEmpty(admin.Account))
            {
                //登录失败，显示提示信息
                lblMsg.Text = admin.AdminName;
            }
            else
            {
                string s = new BLL.AdministratorBLL().UpdateAdministratorBLL(new Model.Administrator() { AdminID = admin.AdminID });
                Session["Administrator"] = admin;
                Session["Repair"] = new List<Model.Repair>();
                Response.Redirect("WebDefault.aspx");
            }
        }
    }
}