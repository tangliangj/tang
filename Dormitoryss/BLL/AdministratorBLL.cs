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
    /// 业务逻辑类：管理员对象
    /// </summary>
    /// <summary>
    /// 业务逻辑类：管理员对象
    /// </summary>
    public class AdministratorBLL
    {
        
        //获取所有的管理员信息
        public List<Model.Administrator> GetAdministratorBLL(int pageNumber = 0)
        {
            return new DAL.AdministratorDAL().GetAdministrator("", (pageNumber * 10 + 1), (pageNumber * 10 + 10));
        }

        //获取管理员的数量

        public int GetAdministratorBLL()
        {
            return new DAL.AdministratorDAL().GetAdministrator();
        }

        //根据编号获取管理员信息
        public Model.Administrator GetAdministratorBLL(string id)
        {
            return new DAL.AdministratorDAL().GetAdministrator(" and [AdminID]='" + id + "'")[0];
        }


        //找回登录密码
        /// </summary>
        /// <param name="account">名字</param>
        /// <param name="question">保密问题</param>
        /// <returns>操作结果</returns>
        public Model.Administrator FindPassword(string account)
        {
            Administrator admin = new Administrator();
            List<Administrator> adm = new DAL.AdministratorDAL().GetAdministrator(" and Account ='" + account + "'");

            if (adm.Count == 0)
            {
                admin.AdminInfo = "账号不存在";
                return admin;
            }
            if (new DAL.AdministratorDAL().UpdateAdministrator(new Administrator() { AdminID = adm[0].AdminID, APassword = Encryption("12345") }) > 0)
            {
                admin.AdminInfo = "密码重置成功";
                admin.State = 1;
            }
            else
                admin.AdminInfo = "密码重置失败！请重新输入";
            return adm[0];
        }


        //管理员登录

        public Administrator Login(string uid, string pwd)
        {
            //加密密码
            pwd = Encryption(pwd);

            if (new Rule.AdministratorRule().TestInsert(uid))
            {
                return new Administrator() { AdminID = "", AdminName = "管理员名错误！" };

            }
            List<Administrator> admin = new List<Administrator>();
            admin = new DAL.AdministratorDAL().GetAdministrator(" and [Account]='" + uid + "' and [APassword]='" + pwd + "'");

            if (admin.Count != 1)
            {
                return new Administrator() { AdminID = "", AdminName = "密码错误！" };
            }
            else
                return admin[0];
        }

        //添加新用户
        public int InsertAdminBLL(Model.Administrator admin)
        {
            if (!new Rule.AdministratorRule().TestInsert(admin.Account))
                return -3;

            admin.APassword = Encryption(admin.APassword);
            return new DAL.AdministratorDAL().InsertAdministrator(admin);
        }

        //更新管理员信息
        public string UpdateAdministratorBLL(Administrator admin)
        {
            if (!string.IsNullOrEmpty(admin.APassword))
                admin.APassword = Encryption(admin.APassword);

            return Option(new DAL.AdministratorDAL().UpdateAdministrator(admin), "更新");
        }

        //删除管理员信息
        public string DeleteAdministratorBLL(string id)
        {
            if (!new Rule.AdministratorRule().TestDelete(id))
                return "还有未处理的任务！不能删除";
            return Option(new DAL.AdministratorDAL().DeleteAdministrator(id), "删除");
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


        /// <summary>
        /// 方法：对密码进行MD5加密
        /// </summary>
        /// <param name="pwd">原始密码</param>
        /// <returns>加密后的密码</returns>
        private string Encryption(string pwd)
        {
            System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(pwd);
            bytes = md5.ComputeHash(bytes);
            return BitConverter.ToString(bytes);
        }
    }
}
