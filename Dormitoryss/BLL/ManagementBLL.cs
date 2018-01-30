using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;
using Rule;
namespace BLL
{
    /// <summary>
    /// 业务逻辑类：宿舍日常管理信息
    /// </summary>
    public class ManagementBLL
    {
        //获取宿舍日常管理信息
        public List<Model.Management> GetManagementBLL(string pagNumber = null)
        {
            return new DAL.ManagementDAL().GetManagementDAL(pagNumber);
        }

        //添加宿舍日常管理信息
        public int InsertManagementBLL(Model.Management ma)
        {
            if (!new ManagementRule().TestInsert(ma.ManagementID))
                return -3;

            return new DAL.ManagementDAL().InsertManagementDAL(ma);
        }

        //更新宿舍日常管理信息
        public string UpdateManagementBLL(Model.Management ma)
        {
            return Option(new DAL.ManagementDAL().UpdateManagementDAL(ma), "更新");
        }

        //删除宿舍信息

        public string DeleteManagementBLL(string id)
        {
            if (!new Rule.ManagementRule().TestDelete(id))
                return "该人员还有未处理的任务！暂时不能删除！";

            return Option(new DAL.ManagementDAL().DeleteManagementDAL(id), "删除");
        }

        /// <summary>
        /// 方法：完成操作
        /// </summary>
        /// <param name="count">受影响的行数</param>
        /// <param name="type">操作类型</param>
        /// <returns>操作结果</returns>
        private string Option(int count, string type)
        {
            switch (count)
            {
                case -2:
                    return "数据库连接异常！请检查您的数据库或联系管理员！";
                case -1:
                    return "数据操作异常！请检查您的数据或联系管理员！";
                case 0:
                    return "没有" + type + "任何数据！";
                default:
                    return "成功" + type + count.ToString() + "条数据！";
            }
        }
    }
}
