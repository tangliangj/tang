using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dormikktoryss
{
    public partial class WebInsertVisiting : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindVisiting();
            }
        }

        protected void BindVisiting()
        {
            List<Model.Dormitory > vis = new BLL.DormitoryBLL ().GetDormitoryBLL (0);
            drtxtVist.DataValueField = "dormitoryID";
            drtxtVist.DataSource = vis;
            drtxtVist.DataBind();
        }

        /// <summary>
        /// 确定增加来访信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            //来访时间
            DateTime dtAccommodationtime = new DateTime(1900, 1, 1);
            if (txtVisitingTime.Text.Trim() != "")
            {
                if (!DateTime.TryParse(txtVisitingTime.Text.Trim(), out dtAccommodationtime))
                {
                    CommonFuncs.ShowMsg(this.Page, "来访时间格式不正确，请改正");
                    txtVisitingTime.Focus();
                    return;
                }
            }

            //离开时间
            DateTime dtleavetime = new DateTime(1900, 1, 1);
            if (txtLikaiTime.Text.Trim() != "")
            {
                if (!DateTime.TryParse(txtLikaiTime.Text.Trim(), out dtleavetime))
                {
                    CommonFuncs.ShowMsg(this.Page, "离开时间格式不正确，请改正");
                    txtLikaiTime.Focus();
                    return;
                }
            }

            Visiting vi = new Visiting();
            vi.dormitoryID = int.Parse(drtxtVist.SelectedItem.Value);
            vi.VisitingName = txtVisitingName.Text.Trim();
            vi.VisitingTime = DateTime.Parse(txtVisitingTime.Text.Trim());
            vi.LikaiTime = DateTime.Parse(txtLikaiTime.Text.Trim());

            if (new VisitingBLL().InsertVisitingBLL(vi) == 1)
            {
                CommonFuncs.ShowMsg(this.Page, "添加来访信息成功");
            }
            else
                CommonFuncs.ShowMsg(this.Page, "添加来访信息失败！\\n\\n请检查各个输入是否合法，\\n来访信息ID是否已经存在，\\n或者请管理员查看系统日志。");
        }

        protected void bntchongzhi_Click(object sender, EventArgs e)
        {

            Response.Redirect("WebInsertVisiting.aspx");
        }
    }
}