using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dormikktoryss
{
    public partial class WebAdministrator : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Model.Administrator admin = Session["Administrator"] as Model.Administrator;

            if (admin == null)
                Response.Redirect("~/WebDefault.aspx");

            if (!IsPostBack)
            {
                txtName.Text = admin.AdminName;
                txtExplains.Text = admin.Explains;
            }


        }

        protected void btnSaveBasic_Click(object sender, EventArgs e)
        {
            Model.Administrator admin = new Model.Administrator();
            admin.AdminID = ((Model.Administrator)Session["Administrator"]).AdminID;
            admin.AdminName = txtName.Text;
            admin.Explains = txtExplains.Text;
            lblMsg.Text = new BLL.AdministratorBLL().UpdateAdministratorBLL(admin);
        }
    }
}