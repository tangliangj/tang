using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;
using Rule;
namespace BLL
{
    /// <summary>
    /// 业务逻辑类：维修对象
    /// </summary>
    public class RepairBLL
    {
        //获取所有维修信息
        public List<Model.Repair> GetRepairBLL(string pagNumber = null)
        {
            return new DAL.RepairDAL().GetRepairDAL(pagNumber);
        }

        //根据维修编号获取维修信息
        //public Model.Repair GetRepairBLL(string id)
        //{
        //    return new DAL.RepairDAL().GetRepairDAL(" and [RepairID]='" + id + "'")[0];
        //}

        //添加物品名维修信息

        public int InsertRepairBLL(Model.Repair rep)
        {
            if (!new Rule.RepairRule().TestInsert(rep.RepairName))
                return -3;
            return new DAL.RepairDAL().InsertRepairDAL(rep);
        }

        //更新维修信息
        public string UpdateRepairBLL(Model.Repair rep)
        {
            return Option(new DAL.RepairDAL().UpdateRepairDAL(rep), "更新");
        }

        //删除维修信息
        public string DeleteRepairBLL(string id)
        {
            if (!new Rule.RepairRule().TestDelete(id))
                return "该物品名还有未处理的任务！暂时不能删除";

            return Option(new DAL.RepairDAL().DeleteRepairDAL(id), "删除");
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
