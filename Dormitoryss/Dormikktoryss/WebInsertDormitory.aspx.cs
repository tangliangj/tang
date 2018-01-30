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
    public partial class WebInsertDormitory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          
        }

       
      
    

        protected void bntchongzhi_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebInsertDormitory.aspx");
        }
        /// <summary>
        /// 确定添加宿舍
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Model.Dormitory dor = new Model.Dormitory();
          //  dor.dormitoryID = int.Parse(txtdormitoryID.Text.Trim());
            dor.DormitoryBoos = txtBossName.Text.Trim();
            dor.beds = txtbeds.Text.Trim();
            dor.ISBN = txtISBN.Text.Trim();
            dor.dormitoryPrice = int.Parse(txtPrice.Text.Trim());
            dor.dormitoryGrade = txtdormitoryGrade.Text.Trim();
            dor.dormitoryPerso = int.Parse(txtPerso.Text.Trim());
            dor.Explain = txtExplains.Text.Trim();

            if (new DormitoryBLL().InsertDormitoryBLL(dor) == 1)
            {
                CommonFuncs.ShowMsg(this.Page, "添加宿舍信息成功");
            }
            else
                CommonFuncs.ShowMsg(this.Page, "添加宿舍信息失败！\\n\\n请检查各个输入是否合法，\\n学生ID是否已经存在，\\n或者请管理员查看系统日志。 ");
        }

     

        protected void drtxtGrade_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

      
    }
}