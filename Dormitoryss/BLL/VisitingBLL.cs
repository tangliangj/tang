using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;
using Rule;
using System.Data.SqlClient;
namespace BLL
{
    /// <summary>
    /// 业务逻辑类：来访信息
    /// </summary>
    public class VisitingBLL
    {
        /// <summary>
        /// 获取所有来访信息
        /// </summary>
        /// <param name="pagNumber"></param>
        /// <returns></returns>
        public List<Model.Visiting> GetVisitingBLL(string  pagNumber=null)
        {
            return new DAL.VisitingDAL().GetVisitingDAL(pagNumber);
        }
        //添加来访信息
        public int InsertVisitingBLL(Model.Visiting vis)
        {
            if (!new VisitingRule().TestInsert(vis.VisitingID))
                return -3;

            return new DAL.VisitingDAL().InsertVisitingDAL(vis);
        }

        //更新来访信息
        public string UpdateVisitingBLL(Model.Visiting vis)
        {
            return Option(new DAL.VisitingDAL().UpdateVisitingDAL(vis), "更新");
        }

        //删除来访信息
        public string DeleteVisitingBLL(string id)
        {
            if (!new Rule.VisitingRule().TestDelete(id))
                return "该来访人员还有未处理的任务！暂时不能删除";

            return Option(new DAL.VisitingDAL().DeleteVisitingDAL(id), "删除");
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
