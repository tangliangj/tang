using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dormikktoryss
{
    public partial class WebDormitory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DateTime time1 = DateTime.Now;
            if (!IsPostBack)
            {
                ViewState["PageIndex"] = 1;
                BindGrid();
                Staiont();
                lblRead.Text = "页面中的时间：" + DateTime.Now.ToLongTimeString();
            }
            DateTime time2 = DateTime.Now;//页面缓存
            TimeSpan ts = time2.Subtract(time1);
            lblTime.Text = "页面加载耗时：" + ts.TotalMilliseconds.ToString() + "毫秒";
        }

        //数据缓存
        protected void BindGera()
        {
            BLL.DormitoryBLL mater = new BLL.DormitoryBLL();
            List<Model.Dormitory> dor = new List<Model.Dormitory>();
            if (Cache["Dormitory"] == null)
            {
                lblTime.Text = "数据来自缓存";
            }
            dor = (List<Model.Dormitory>)Cache["Dormitory"];
            dgdShowData.DataSource = dor;
            dgdShowData.DataBind();
        }

        //分页
        protected void Staiont()
        {
           
            PagedDataSource pd = new PagedDataSource();
            pd.AllowPaging = true;
            pd.PageSize = 4;
            BLL.DormitoryBLL dormitoryBll = new BLL.DormitoryBLL();
            pd.DataSource = dormitoryBll.GetDormitoryBLL(0);
            int index = (int)ViewState["PageIndex"];
            if (index < 1)
                index = pd.PageCount;
            if (index > pd.PageCount)
                index = 1;

            pd.CurrentPageIndex = index-1;
            lblPage.Text = "第" + (index) + "页/共" + pd.PageCount + "页";
            dgdShowDormitory.DataSource = pd;
            dgdShowDormitory.DataBind();


        }
        protected void BindGrid()
        {
            if (!radList.Checked)
            {
                dgdShowData.Visible = false;
                dgdShowDormitory.Visible = true;
                dgdShowDormitory.DataSource = new BLL.DormitoryBLL().GetDormitoryBLL(0);
                dgdShowDormitory.DataBind();
            }
            else
            {
                dgdShowData.Visible = true;
                dgdShowDormitory.Visible = false;
                dgdShowData.DataSource = new BLL.DormitoryBLL().GetDormitoryBLL(0);
                dgdShowData.DataBind();
            }
        }



        protected void radRect_CheckedChanged(object sender, EventArgs e)
        {

            BindGrid();
        }

        protected void radList_CheckedChanged(object sender, EventArgs e)
        {

            BindGrid();
        }

        protected void dgdShowData_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void dgdShowDormitory_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
           
        }

        protected void bntProc_Click(object sender, EventArgs e)
        {
            ViewState["PageIndex"] = (int)ViewState["PageIndex"] - 1;
            Staiont();
        }

        protected void bntNext_Click(object sender, EventArgs e)
        {
            ViewState["PageIndex"] = (int)ViewState["PageIndex"] + 1;
            Staiont();
        }

        protected void bntFileUpload_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                try
                {
                    //将文件保存在服务器上
                    FileUpload1.SaveAs("G:\\" + FileUpload1.FileName);
                    //显示文件相关的信息
                    lblage.Text = "文件名：" + FileUpload1.PostedFile.FileName + "<br/>" +
                        "文件大小：" + FileUpload1.PostedFile.ContentLength + "<br/>" +
                        "文件类型：" + FileUpload1.PostedFile.ContentType;
                }
                catch (Exception ex)
                {
                    lblage.Text = "异常：" + ex.Message;
                }
            }
            else
                lblage.Text = "请选择一个文件";
        }

    }
}