using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data.SqlClient;
namespace DAL
{
    /// <summary>
    /// 对象操作类：管理员信息表
    /// </summary>
    public class AdministratorDAL
    {
        //管理员信息集合，根据条件查询管理员信息
        public List<Model.Administrator> GetAdministrator(string whereStr = null, int start = 1, int end = 10)
        {
            List<Model.Administrator> admin = new List<Model.Administrator>();
            if (DBHelper.OpenConnection  ())
            {
                SqlDataReader dr = DBHelper.ExecReader("select * from [Administrator] where [State]=0 " + whereStr);

                if (dr != null)
                {
                    Model.Administrator ad = null;

                    while (dr.Read())
                    {
                        ad = new Administrator();
                        ad.Account = dr["Account"].ToString();
                        ad.AdminID = dr["AdminID"].ToString();
                        ad.AdminName = dr["AdminName"].ToString();
                        ad.APassword = dr["APassword"].ToString();
                        ad.Explains = dr["Explains"].ToString();
                        ad.State = (int)dr["State"];
                        admin.Add(ad);
                    }
                    dr.Close();
                }

                DBHelper.CloseConnection();
            }
            return admin;
        }


        /// <summary>
        /// 获取管理员数量
        /// </summary>
        /// <returns></returns>
        public int GetAdministrator()
        {
            return (int)DBHelper.ExecScalar("select count(*) from [Administrator]");
        }
        //添加管理员信息
        public int InsertAdministrator(Model.Administrator admin)
        {
            return DBHelper.ExecQuery("Insert into [Administrator]([AdminName],[Account],[APassword]) values('" + admin.AdminName + "','" + admin.Account + "','" + admin.APassword + "')");
        }

        //更新管理员信息

        public int UpdateAdministrator(Model.Administrator admin)
        {
            string sql = "Update [Administrator] set [State]=0";
            if (!string.IsNullOrEmpty(admin.APassword))
                sql += ",[APassword]='" + admin.APassword + "'";

            if (!string.IsNullOrEmpty(admin.AdminName))
                sql += ",[AdminName]='" + admin.AdminName + "'";

            if (!string.IsNullOrEmpty(admin.Account))
                sql += ",[Account]='" + admin.Account + "'";

           
            if (!string.IsNullOrEmpty(admin.Explains))
                sql += ",[Explains]='" + admin.Explains + "'";

            sql += " where [AdminID]='" + admin.AdminID + "'";
            return DBHelper.ExecQuery(sql);
        }

        //删除管理员信息
        public int DeleteAdministrator(string id)
        {
            return DBHelper.ExecQuery("Update [Administrator] set [State]=1 where [AdminID] in (" + id + ")");
        }
    }
}
