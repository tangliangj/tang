using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dormikktoryss
{
    public partial class WebSushejianjie : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                ShowDormitoryss();
        }

        protected void ShowDormitoryss()
        {
            Model.Dormitory dormitory = new BLL.DormitoryBLL().GetDormitoryBLL(Request.QueryString["ID"]);

            if (dormitory != null)
            {
                lbldormitoryID.Text = dormitory.dormitoryID.ToString();
                imgCover.ImageUrl = "~/Image/" + dormitory.ISBN;
                lbldormitoryGrade.Text = dormitory.dormitoryGrade;
                lbldormitoryPrice.Text = string.Format("{0:C}",dormitory.dormitoryPrice);
                lbldormitoryPerso.Text = dormitory.dormitoryPerso.ToString() + "人";
                lblbeds.Text = dormitory.beds;
                lblDormitoryBoos.Text = dormitory.DormitoryBoos;
            }

        }
    }
}