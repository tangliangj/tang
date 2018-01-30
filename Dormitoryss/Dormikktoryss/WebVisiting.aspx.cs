using BLL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dormikktoryss
{
    public partial class WebVisiting : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["PageIndex"] = 1;
                GetVisitingWeb();
            }
        }

        protected void GetVisitingWeb()
        {
            string vis = "select *  from Visiting where State=0  ";
            if (!string.IsNullOrEmpty(txtdormitoryID.Text))
            {
                vis += " and [dormitoryID]='" + txtdormitoryID.Text+"'";
            }
            if (!string.IsNullOrEmpty(txtVisitingName.Text))
            {
                vis += " and [VisitingName]='" + txtVisitingName.Text+"'";

            }

            if (!string.IsNullOrEmpty(txtVisitingTime.Text))
            {
                vis += " and [VisitingTime]='" + txtVisitingTime.Text+"'";

            }
            if (!string.IsNullOrEmpty(txtLikaiTime.Text))
            {
                vis += " and [LikaiTime]='" + txtLikaiTime.Text+"'";

            }
            PagedDataSource pd = new PagedDataSource();
            pd.AllowPaging = true;
            pd.PageSize = 8;
            pd.DataSource = new VisitingBLL  ().GetVisitingBLL(vis);
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

        //显示全部
        protected void btnListAll_Click(object sender, EventArgs e)
        {
            string vis = "select *  from Visiting where State=0  ";
            ListView1.DataSource = new BLL.VisitingBLL().GetVisitingBLL(vis);
            ListView1.DataBind();
        }

        //验证查询功能
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string cond = "";
            //关于报修维修的条件组合
            string VisitingTime = txtVisitingTime.Text.Trim();
            string LikaiTime = txtLikaiTime.Text.Trim();
            DateTime tmp;

            if (VisitingTime != "")
            {
                if (DateTime.TryParse(VisitingTime, out tmp) == false)
                {
                    CommonFuncs.ShowMsg(this.Page, "来访日期格式不合法");
                    txtVisitingTime.Focus();
                    return;
                }
                cond = "VisitingTime>='" + VisitingTime + "'";
            }
            if (LikaiTime != "")
            {
                if (DateTime.TryParse(LikaiTime, out tmp) == false)
                {
                    CommonFuncs.ShowMsg(this.Page, "来访日期格式不合法");
                    txtLikaiTime.Focus();
                    return;
                }
                if (cond == "")
                    cond = "LikaiTime>='" + LikaiTime + "'";
                else cond = cond + " and LikaiTime<='" + VisitingTime + "'";
            }

            //关于宿舍号的条件组合
            if (txtdormitoryID.Text.Trim() != "")
            {
                if (cond == "")
                    cond = "dormitoryID like '" + txtdormitoryID.Text.Trim() + "%'";
                else
                    cond = cond + " and dormitoryID like '" + txtdormitoryID.Text.Trim() + "%'";
            }

            //关于报修人员的条件组合
            if (txtVisitingName.Text.Trim() != "")
            {
                if (cond == "")
                    cond = "VisitingName like '" + txtVisitingName.Text.Trim() + "%'";
                else
                    cond = cond + " and VisitingName like '" + txtVisitingName.Text.Trim() + "%'";
            }
            //刷新
            GetVisitingWeb();


        }

        protected void bntProc_Click(object sender, EventArgs e)
        {
            ViewState["PageIndex"] = (int)ViewState["PageIndex"] - 1;
            GetVisitingWeb();
        }

        protected void bntNext_Click(object sender, EventArgs e)
        {
            ViewState["PageIndex"] = (int)ViewState["PageIndex"] + 1;
            GetVisitingWeb();
        }

       
       
    }
}