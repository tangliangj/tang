using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;
namespace Dormikktoryss
{
    public partial class WebInsertStudent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDrop();
            }
        }
        protected void BindDrop()
        {
            List<Model.Dormitory> dormitoryList = new BLL.DormitoryBLL().GetDormitoryBLL(0);
            drtxtDorID.DataValueField = "dormitoryID";
            drtxtDorID.DataSource = dormitoryList;
            drtxtDorID.DataBind();
        }
        /// <summary>
        /// 确定增加学生
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAdd_Click(object sender, EventArgs e)
        {


            //if (!(new Rule.StudentRule().TestInsert(txtStudentID.Text.Trim())))
            //{
            //    CommonFuncs.ShowMsg(this.Page, "该学号已经存在，请重新输入新的学号");
            //    //设置焦点
            //    txtStudentID.Focus();
            //    return;
            //}

            //if (new StudentBLL().GetStudentBLL(txtdormitoryID.Text.Trim()) != null)
            //{
            //    CommonFuncs.ShowMsg(this.Page, "该宿舍号已经存在，请重新输入新的宿舍号");
            //    //设置焦点
            //    txtdormitoryID.Focus();
            //    return;
            //}

            

            DateTime dtAccommodationtime = new DateTime(1900, 1, 1);
            if (txtAccommodationtime.Text.Trim() != "")
            {
                if (!DateTime.TryParse(txtAccommodationtime.Text.Trim(), out dtAccommodationtime))
                {
                    CommonFuncs.ShowMsg(this.Page, "入住时间格式不正确，请改正");
                    txtAccommodationtime.Focus();
                    return;
                }
            }

            DateTime dtleavetime = new DateTime(1900, 1, 1);
            if (txtleavetime.Text.Trim() != "")
            {
                if (!DateTime.TryParse(txtleavetime.Text.Trim(), out dtleavetime))
                {
                    CommonFuncs.ShowMsg(this.Page, "离开时间格式不正确，请改正");
                    txtleavetime.Focus();
                    return;
                }
            }
            if(!(int.Parse(txtAge.Text)>=17||int.Parse(txtAge.Text)<=28))
            {
                CommonFuncs.ShowMsg(this.Page, "年龄不在范围内，请改正");
                txtAge.Focus();
                return;
            }


            Student stu = new Student();
          //  stu.StudentID = (txtStudentID.Text.Trim());
            stu.dormitoryID =int.Parse(drtxtDorID.SelectedItem.Value);
            stu.StudentName =txtName.Text.Trim();
            stu.Age = int.Parse(txtAge.Text.Trim());
            stu.Place =txtPlace.Text.Trim();
            stu.Accommodationtime=DateTime.Parse( txtAccommodationtime.Text.Trim());
            stu.leavetime=DateTime.Parse(txtleavetime.Text.Trim());
           stu.Gender=  (rblGender.SelectedIndex==0)?"男":"女";
            stu.Phone =txtPhone.Text.Trim();
            stu.Explains =txtExplains.Text.Trim();


            if (new StudentBLL().InsertStudentBLL(stu) == 1)
            {
                CommonFuncs.ShowMsg(this.Page, "添加学生信息成功");
            }
            else
                CommonFuncs.ShowMsg(this.Page, "添加学生信息失败！\\n\\n请检查各个输入是否合法，\\n学生ID是否已经存在，\\n或者请管理员查看系统日志。");
            
        }

        protected void bntchongzhi_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebInsertStudent.aspx");
        }
    }
}