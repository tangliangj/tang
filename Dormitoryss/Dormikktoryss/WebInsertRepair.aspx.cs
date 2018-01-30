using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using Model;
using BLL;
namespace Dormikktoryss
{
    public partial class WebInsertRepair : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindRerop();
            }
        }

        protected void BindRerop()
        {
            List<Model.Dormitory> dormitoryList = new BLL.DormitoryBLL().GetDormitoryBLL(0);
            drtxtDorID.DataValueField = "dormitoryID";
            drtxtDorID.DataSource = dormitoryList;
            drtxtDorID.DataBind();
        }


        /// <summary>
        /// 确定增加维修信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            DateTime dtRepairtime = new DateTime(1900, 1, 1);
            if (txtRepairtime.Text.Trim() != "")
            {
                if (!DateTime.TryParse(txtRepairtime.Text.Trim(), out dtRepairtime))
                {
                    CommonFuncs.ShowMsg(this.Page, "报修时间格式不正确，请改正");
                    txtRepairtime.Focus();
                    return;
                }
            }

            DateTime dtHandletime = new DateTime(1900, 1, 1);
            if (txtHandletime.Text.Trim() != "")
            {
                if (!DateTime.TryParse(txtHandletime.Text.Trim(), out dtHandletime))
                {
                    CommonFuncs.ShowMsg(this.Page, "处理时间格式不正确，请改正");
                    txtHandletime.Focus();
                    return;
                }
            }

            Repair rep = new Repair();
            rep.dormitoryID = int.Parse(drtxtDorID.SelectedItem.Value);
            rep.RepairPerso = txtRepairPerso.Text.Trim();
            rep.RepairName = txtRepairName.Text.Trim();
            rep.RepairTime = DateTime.Parse(txtRepairtime.Text.Trim());
            rep.HandleTime = DateTime.Parse(txtHandletime.Text.Trim());
            rep.Count = int.Parse(txtCount.Text.Trim());
            rep.HandlePerso = txtHandlePerso.Text.Trim();
            rep.Explain = txtExplains.Text.Trim();

            if (new RepairBLL().InsertRepairBLL(rep) == 1)
            {
                CommonFuncs.ShowMsg(this.Page, "添加维修信息成功");
            }
            else
                CommonFuncs.ShowMsg(this.Page, "添加维修信息失败！\\n\\n请检查各个输入是否合法，\\n维修信息ID是否已经存在，\\n或者请管理员查看系统日志。");

        }

        protected void bntchongzhi_Click(object sender, EventArgs e)
        {

            Response.Redirect("WebInsertStudent.aspx");
        }
    }
}