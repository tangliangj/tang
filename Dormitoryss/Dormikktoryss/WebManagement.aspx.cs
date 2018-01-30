using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dormikktoryss
{
    public partial class WebManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["PageIndex"] = 1;
                GetManagementWeb();

            }
        }

       


        protected void GetManagementWeb()
        {
            string stu = "select *  from Management where State=0  ";
            if (!string.IsNullOrEmpty(txtHygiene.Text))
            {
                stu += " and [Hygiene]='" + txtHygiene.Text + "'";
            }
            if (!string.IsNullOrEmpty(txtdormitoryID.Text))
            {
                stu += " and [dormitoryID]='" + txtdormitoryID.Text + "'";

            }

            if (!string.IsNullOrEmpty(txtName.Text))
            {
                stu += " and [Inspectors]='" + txtName.Text + "'";

            }
            if (!string.IsNullOrEmpty(txtManagementTime.Text))
            {
                stu += " and [ManagementTime]='" + txtManagementTime.Text + "'";

            }

            PagedDataSource pd = new PagedDataSource();
            pd.AllowPaging = true;
            pd.PageSize = 8;
            pd.DataSource = new ManagementBLL().GetManagementBLL(stu);
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
            //关于查询时间的条件组合
            string ManagementTime = txtManagementTime.Text.Trim();
            DateTime tmp;

            if (ManagementTime != "")
            {
                if (DateTime.TryParse(ManagementTime, out tmp) == false)
                {
                    CommonFuncs.ShowMsg(this.Page, "入离时间格式不对！");
                    txtManagementTime.Focus();
                    return;
                }
                cond = "ManagementTime>='" + txtManagementTime + "'";

            }
            

            //关于宿舍号的条件组合
            if (txtdormitoryID.Text.Trim() != "")
            {
                if (cond == "")
                    cond = "dormitoryID like '" + txtdormitoryID.Text.Trim() + "%'";
                else
                    cond = cond + " and dormitoryID like '" + txtdormitoryID.Text.Trim() + "%'";
            }

            //关于检查人员的条件组合
            if (txtName.Text.Trim() != "")
            {
                if (cond == "")
                    cond = "Inspectors like '" + txtName.Text.Trim() + "%'";
                else
                    cond = cond + " and Inspectors like '" + txtName.Text.Trim() + "%'";
            }


            //关于卫生情况的条件组合
            if (txtHygiene.Text.Trim() != "")
            {
                if (cond == "")
                    cond = "Hygiene like '" + txtHygiene.Text.Trim() + "%'";
                else
                    cond = cond + " and Hygiene like '" + txtHygiene.Text.Trim() + "%'";
            }
            //刷新 
            GetManagementWeb();
        }

        //显示全部
        protected void btnListAll_Click(object sender, EventArgs e)
        {
            string stu = " select * from Management where State=0 ";
            ListView1.DataSource = new BLL.ManagementBLL().GetManagementBLL(stu);
            ListView1.DataBind();
        }

        protected void bntNext_Click(object sender, EventArgs e)
        {
            ViewState["PageIndex"] = (int)ViewState["PageIndex"] - 1;
            GetManagementWeb();
        }

        protected void bntProc_Click(object sender, EventArgs e)
        {
            ViewState["PageIndex"] = (int)ViewState["PageIndex"] + 1;
            GetManagementWeb();
        }

       
    }
}