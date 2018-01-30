using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using DAL;
namespace Dormikktoryss
{
    public partial class WebInsertManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BinDrophy();
            }
        }

        protected void BinDrophy()
        {
            List<Model.Management> man = new BLL.ManagementBLL().GetManagementBLL();
            drtxtDorID.DataValueField = "dormitoryID";
            drtxtDorID.DataSource = man;
            drtxtDorID.DataBind();

            droHygiene.Items.Add("优秀");
            droHygiene.Items.Add("合格");
            droHygiene.Items.Add("不合格");

            
           
        }


        /// <summary>
        /// 确定添加宿舍日常信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            //检查时间
            DateTime dtManagementTime = new DateTime(1900, 1, 1);
            if (txtManagementTime.Text.Trim() != "")
            {
                if (!DateTime.TryParse(txtManagementTime.Text.Trim(), out dtManagementTime))
                {
                    CommonFuncs.ShowMsg(this.Page, "入住时间格式不正确，请改正");
                    txtManagementTime.Focus();
                    return;
                }
            }

            Management man = new Management();
            man.dormitoryID = int.Parse(drtxtDorID.SelectedItem.Value);
            man.Hygiene = droHygiene.SelectedItem.Value;
            man.Inspectors = ((Administrator)Session["Administrator"]).AdminID;
            man.ManagementTime = DateTime.Parse(txtManagementTime.Text.Trim());
            man.Explain = txtExplains.Text.Trim();

            if (new ManagementBLL().InsertManagementBLL(man) == 1)
            {
                CommonFuncs.ShowMsg(this.Page, "添加宿舍日常管理信息成功");
            }
            else
                CommonFuncs.ShowMsg(this.Page, "添加宿舍日常管理信息失败！\\n\\n请检查各个输入是否合法，\\n宿舍日常管理ID是否已经存在，\\n或者请管理员查看系统日志。");
            

        }

        protected void bntchongzhi_Click(object sender, EventArgs e)
        {

            Response.Redirect("WebInsertStudent.aspx");
        }
    }
}