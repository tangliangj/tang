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
    /// 业务逻辑类：宿舍信息
    /// </summary>
    public class DormitoryBLL
    {
        /// <summary>
        /// 获取所有宿舍信息
        /// </summary>
        /// <param name="pagNumber"></param>
        /// <returns></returns>
        public List<Model.Dormitory> GetDormitoryBLL(int pagNumber = 0)
        {
            return new DAL.DormitoryDAL().GetDormitoryDAL("", (pagNumber * 10 + 1), (pagNumber * 10 + 10));
        }
        //public List<Model.Dormitory> GetPriceBll(int id)
        //{
        //    return new DAL.DormitoryDAL().GetDormitoryDAL("");
        //}
        //获取宿舍人数量

        public int GetDormitoryBLL()
        {
            return new DAL.DormitoryDAL().GetDormitoryDAL();
        }

        //根据宿舍编号获取宿舍信息
        public Model.Dormitory GetDormitoryBLL(string id)
        {
            return new DAL.DormitoryDAL().GetDormitoryDAL(" and [DormitoryID]='" + id + "'")[0];
        }

        //添加新宿舍信息
        public int InsertDormitoryBLL(Model.Dormitory dor)
        {
            if (!new DormitoryRule().TestInsert(dor.dormitoryGrade))
                return -3;

            return new DAL.DormitoryDAL().InsertDormitoryDAL(dor);
        }

        //更新宿舍信息
        public string UpdateDormitoryBLL(Model.Dormitory dor)
        {

            return Option(new DAL.DormitoryDAL().UpdateDormitoryDAL(dor), "更新");
        }

        //删除宿舍信息

        public string DeleteDormitoryBLL(string id)
        {
            if (!new Rule.DormitoryRule().TestDelete(id))
                return "该用户还有未处理的任务！暂时不能删除！";

            return Option(new DAL.DormitoryDAL().DeleteDormitoryDAL(id), "删除");
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
