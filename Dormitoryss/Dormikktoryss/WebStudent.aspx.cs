using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using DAL;
using Model;
namespace Dormikktoryss
{
    public partial class WebStudent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["PageIndex"] = 1;
                GetStudentWeb();
            }
        }

        protected void GetStudentWeb()
        {
            string stu = "select *  from Student where State=0  ";
            if (!string.IsNullOrEmpty(txtStuID.Text))
            {
                stu += " and [StudentID]='" + txtStuID.Text + "'";
            }
            if (!string.IsNullOrEmpty(txtStuName.Text))
            {
                stu += " and [StudentName]='" + txtStuName.Text + "'";

            }

           
            if (!string.IsNullOrEmpty(txtPhone.Text))
            {
                stu += " and [Phone]='" + txtPhone.Text + "'";

            }
            if (!string.IsNullOrEmpty(txtAccommodationtime.Text))
            {
                stu += " and [Accommodationtime]='" + txtAccommodationtime.Text + "'";

            }
            if (!string.IsNullOrEmpty(txtleavetime.Text))
            {
                stu += " and [leavetime]='" + txtleavetime.Text + "'";

            }
            PagedDataSource pd = new PagedDataSource();
            pd.AllowPaging = true;
            pd.PageSize = 8;
            BLL.StudentBLL studentBll = new BLL.StudentBLL();
            pd.DataSource = studentBll.GetStudentBLL(stu);
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

        //验证--查询功能
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string cond = "";
            //关于入住离开时间的条件组合
            string Accommodation = txtAccommodationtime.Text.Trim();
            string leave = txtleavetime.Text.Trim();
            DateTime tmp;

            if (Accommodation != "")
            {
                if (DateTime.TryParse(leave, out tmp) == false)
                {
                    CommonFuncs.ShowMsg(this.Page, "入离时间格式不对！");
                    txtAccommodationtime.Focus();
                    return;
                }
                cond = "Accommodationtime>='" + Accommodation + "'";
               
            }
            if (leave != "")
            {
                if (DateTime.TryParse(leave, out tmp) == false)
                {
                    CommonFuncs.ShowMsg(this.Page, "入离时间格式不对！");
                    txtleavetime.Focus();
                    return;
                }
                if (cond == "")
                    cond = "leavetime>='" + leave + "'";
                else
                    cond = cond + "and  Accommodationtime<='" + leave + "'";
            }
            
            //关于学号的条件组合
            if (txtStuID.Text.Trim() != "")
            {
                if (cond == "")
                    cond = "StudentID like '" + txtStuID.Text.Trim() + "%'";
                else
                    cond = cond + " and StudentID like '" + txtStuID.Text.Trim() + "%'";
            }
            
            //关于姓名的条件组合
            if (txtStuName.Text.Trim() != "")
            {
                if (cond == "")
                    cond = "StudentName like '" + txtStuName.Text.Trim() + "%'";
                else
                    cond = cond + " and StudentName like '" + txtStuName.Text.Trim() + "%'";
            }

            //关于性别的条件组合
            string gender = "";
            switch (rblGender.SelectedValue)
            {
                case "male":
                    gender = "Gender=男";
                    break;
                case "female":
                    gender = "Gender=女";
                    break;
                default:
                    break;
            }
            if (gender != "")
            {
                if (cond == "")
                    cond = gender;
                else
                    cond = cond + " and " + gender;
            }
            
            //关于手机号的条件组合
            if (txtPhone.Text.Trim() != "")
            {
                if (cond == "")
                    cond = "Phone like '" + txtPhone.Text.Trim() + "%'";
                else
                    cond = cond + " and Phone like '" + txtPhone.Text.Trim() + "%'";
            }
           //刷新 
            GetStudentWeb();

        }
        //显示全部
        protected void btnListAll_Click(object sender, EventArgs e)
        {
            string stu = "select *  from Student where State=0  ";
            ListView1.DataSource = new BLL.StudentBLL().GetStudentBLL(stu);
            ListView1.DataBind();
        }

        protected void bntProc_Click(object sender, EventArgs e)
        {
            ViewState["PageIndex"] = (int)ViewState["PageIndex"] - 1;
            GetStudentWeb();
        }

        protected void bntNext_Click(object sender, EventArgs e)
        {
            ViewState["PageIndex"] = (int)ViewState["PageIndex"] + 1;
            GetStudentWeb();
        }

    }
}