using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dormikktoryss
{
    public partial class Webregistered : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Administrator admin = new Administrator();

            //admin.AdminID = Guid.NewGuid().ToString();
            admin.AdminName = txtName.Text.Trim();
            admin.Account = txtID.Text.Trim();
            admin.APassword = txtpwd1.Text;

            int count = new BLL.AdministratorBLL().InsertAdminBLL(admin);
            switch (count)
            {
                case -3:
                    lblMsg.Text = "您输入的账号已经存在！<br/>请重新选择！";
                    break;
                case -2:
                    lblMsg.Text = "数据库连接失败！<br/>请检查您的数据库或联系管理员！";
                    break;
                case -1:
                    lblMsg.Text = "数据操作失败！<br/>请检查您输入的数据或联系管理员！";
                    break;
                case 0:
                    lblMsg.Text = "注册失败！<br/>请检查您输入的数据！";
                    break;
                default:
                    Session["Administrator"] = admin;
                    //Session[""]
                    lblMsg.Text = "注册成功！";
                    break;
            }
        }
    }
}