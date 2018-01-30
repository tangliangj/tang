using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dormikktoryss
{
    public partial class WebRepair : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["PageIndex"] = 1;
                GetRepairWeb();
            }
        }
     
        protected void GetRepairWeb()
        {
            string stu = "select *  from Repair where State=0  ";
            if (!string.IsNullOrEmpty(txtRepairPerso.Text))
            {
                stu += " and [RepairPerso]='" + txtRepairPerso.Text + "'";
            }
            if (!string.IsNullOrEmpty(txtdormitoryID.Text))
            {
                stu += " and [dormitoryID]='" + txtdormitoryID.Text + "'";

            }

            if (!string.IsNullOrEmpty(txtRepairName.Text))
            {
                stu += " and [RepairName]='" + txtRepairName.Text + "'";

            }
            if (!string.IsNullOrEmpty(txtHandlePerso.Text))
            {
                stu += " and [HandlePerso]='" + txtHandlePerso.Text + "'";

            }
            if (!string.IsNullOrEmpty(txtManagementTime.Text))
            {
                stu += " and [ManagementTime]='" + txtManagementTime.Text + "'";

            }
            if (!string.IsNullOrEmpty(txtHandleTime.Text))
            {
                stu += " and [HandleTime]='" + txtHandleTime.Text + "'";

            }
            PagedDataSource pd = new PagedDataSource();
            pd.AllowPaging = true;
            pd.PageSize = 8;
            BLL.RepairBLL repairBll = new BLL.RepairBLL();
            pd.DataSource = repairBll.GetRepairBLL(stu);
            int index = (int)ViewState["PageIndex"];
            if (index < 1)
                index = pd.PageCount;
            if (index > pd.PageCount)
                index = 1;

            pd.CurrentPageIndex = index - 1;
            lblPage.Text = "第" + (index) + "页/共" + pd.PageCount + "页";
            ListView1.DataSource = pd;
            ListView1.DataBind();
        }


        protected void btnSaveBasic_Click(object sender, EventArgs e)
        {

        }

        protected void bntchongzhi_Click(object sender, EventArgs e)
        {

        }

        //验证--查询功能
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string cond = "";

            //关于报修维修的条件组合
            string ManagementTime = txtManagementTime.Text.Trim();
            string HandleTime = txtHandleTime.Text.Trim();
            DateTime tmp;

            if (ManagementTime != "")
            {
                if (DateTime.TryParse(ManagementTime, out tmp) == false)
                {
                    CommonFuncs.ShowMsg(this.Page, "报修维修日期格式不合法");
                    txtManagementTime.Focus();
                    return;
                }
                cond = "ManagementTime>='" + ManagementTime + "'";
            }
            if (HandleTime != "")
            {
                if (DateTime.TryParse(HandleTime, out tmp) == false)
                {
                    CommonFuncs.ShowMsg(this.Page, "报修维修日期格式不合法");
                    txtHandleTime.Focus();
                    return;
                }
                if (cond == "")
                    cond = "HandleTime>='" + HandleTime + "'";
                else cond = cond + " and HandleTime<='" + ManagementTime + "'";
            }

            //关于宿舍号的条件组合
            if (txtdormitoryID.Text.Trim() != "")
            {
                if (cond == "")
                    cond = "dormitoryID like '" + txtdormitoryID.Text.Trim() + "%'";
                else
                    cond = cond + " and dormitoryID like '" + txtdormitoryID.Text.Trim() + "%'";
            }

            //关于物品名的条件组合
            if (txtRepairName.Text.Trim() != "")
            {
                if (cond == "")
                    cond = "RepairName like '" + txtRepairName.Text.Trim() + "%'";
                else
                    cond = cond + " and RepairName like '" + txtRepairName.Text.Trim() + "%'";
            }

            //关于报修人员的条件组合
            if (txtRepairPerso.Text.Trim() != "")
            {
                if (cond == "")
                    cond = "RepairPerso like '" + txtRepairPerso.Text.Trim() + "%'";
                else
                    cond = cond + " and RepairPerso like '" + txtRepairPerso.Text.Trim() + "%'";
            }

            //关于处理人员的条件组合
            if (txtHandlePerso.Text.Trim() != "")
            {
                if (cond == "")
                    cond = "HandlePerso like '" + txtHandlePerso.Text.Trim() + "%'";
                else
                    cond = cond + " and HandlePerso like '" + txtHandlePerso.Text.Trim() + "%'";
            }

            //刷新
            GetRepairWeb();
        }
        //显示全部
        protected void btnListAll_Click(object sender, EventArgs e)
        {
            string stu = "select *  from Repair where State=0  ";
            ListView1.DataSource = new BLL.RepairBLL().GetRepairBLL(stu);
            ListView1.DataBind();
        }

        protected void bntNext_Click(object sender, EventArgs e)
        {
            ViewState["PageIndex"] = (int)ViewState["PageIndex"] - 1;
            GetRepairWeb();
        }

        protected void bntProc_Click(object sender, EventArgs e)
        {
            ViewState["PageIndex"] = (int)ViewState["PageIndex"] + 1;
            GetRepairWeb();
        }
    }
}