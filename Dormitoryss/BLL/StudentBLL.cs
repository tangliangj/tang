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
    /// 业务逻辑类：学员对象
    /// </summary>
    public class StudentBLL
    {
        //获取所有学员信息
        public List<Model.Student> GetStudentBLL(string pagNumber = null)
        {
            return new DAL.StudentDAL().GetStudentDAL(pagNumber);
        }

        //获取学员的数量
        public int GetStudentBLL()
        {
            return new DAL.StudentDAL().GetStudentDAL();
        }

        //根据学员编号获取学员信息
        //public Model.Student GetStudentBLL(string id)
        //{
        //    return new DAL.StudentDAL().GetStudentDAL(" and [StudentID]='" + id + "'")[0];
        //}

        //添加新学员

        public int InsertStudentBLL(Model.Student stu)
        {
            if (!new Rule.StudentRule().TestInsert(stu.StudentID))
                return -3;
            return new DAL.StudentDAL().InsertStudentDAL(stu);
        }

        //更新学员信息

        public string UpdateStudentBLL(Model.Student stu)
        {
            return Option(new DAL.StudentDAL().UpdateStudentDAL(stu), "更新");
        }

        //删除学员信息
        public string DeleteStudentBLL(string id)
        {

            if (!new Rule.StudentRule().TestDelete(id))
                return "该学员还有未处理的任务！暂时不能删除！";

            return Option(new DAL.StudentDAL().DeleteStudentDAL(id), "删除");

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
