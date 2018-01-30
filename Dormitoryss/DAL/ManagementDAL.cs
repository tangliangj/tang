using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace DAL
{
    /// <summary>
    /// 对象操作类：宿舍日常管理信息
    /// </summary>
    public class ManagementDAL
    {
        //查询宿舍日常管理信息
        public List<Model.Management> GetManagementDAL(string where = null, int start = 1, int end = 10)
        {
            List<Model.Management> ma = new List<Model.Management>();

            if (DBHelper.OpenConnection())
            {
                SqlDataReader dr = DBHelper.ExecReader( where);

                if (dr != null)
                {
                    while (dr.Read())
                        ma.Add(new Model.Management(dr["ManagementID"].ToString(), (int)dr["dormitoryID"], dr["Hygiene"] as string, dr["Inspectors"] as string, (DateTime)dr["ManagementTime"], dr["Explain"] as string, (int)dr["State"]));
                }
                DBHelper.CloseConnection();
            }
            return ma;
        }

        //添加宿舍日常管理信息
        public int InsertManagementDAL(Model.Management ma)
        {
            return DBHelper.ExecQuery("insert into [Management] ([dormitoryID],[Hygiene],[Inspectors],[ManagementTime],[Explain],[State]) values('" + ma.dormitoryID + "','" + ma.Hygiene + "','" + ma.Inspectors + "','" + ma.ManagementTime + "','" + ma.Explain + "',0)");
        }

        //更新宿舍日常管理信息
        public int UpdateManagementDAL(Model.Management ma)
        {
            string sql = "update [Management] set [State]=0";

            if (!string.IsNullOrEmpty(ma.dormitoryID.ToString()))
                sql += ",[dormitoryID]='" + ma.dormitoryID + "'";

            if (!string.IsNullOrEmpty(ma.Hygiene))
                sql += ",[Hygiene]='" + ma.Hygiene + "'";

            if (!string.IsNullOrEmpty(ma.Inspectors))
                sql += ",[Inspectors]='" + ma.Inspectors + "'";

            if (!string.IsNullOrEmpty(ma.ManagementTime.ToString()))
                sql += ",[ManagementTime]='" + ma.ManagementTime + "'";

            if (!string.IsNullOrEmpty(ma.Explain))
                sql += ",[Explain]='" + ma.Explain + "'";

            sql += " where [ManagementID]=" + ma.ManagementID;
            return DBHelper.ExecQuery(sql);
        }

        //删除宿舍日常管理信息
        public int DeleteManagementDAL(string id)
        {
            return DBHelper.ExecQuery("update [Management] set [State]=1 where [ManagementID] in (" + id + ")");
        }
    }
}
