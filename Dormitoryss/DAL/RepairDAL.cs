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
    /// 对象操作类：维修信息表
    /// </summary>
    public class RepairDAL
    {
        //根据给定条件查询维修信息
        public List<Model.Repair> GetRepairDAL(string whereStr = null, int start = 1, int end = 10)
        {
            List<Model.Repair> re = new List<Model.Repair>();

            if (DBHelper.OpenConnection())
            {
                SqlDataReader dr = DBHelper.ExecReader(whereStr);

                if (dr != null)
                {
                    while (dr.Read())
                        re.Add(new Model.Repair(dr["RepairID"].ToString(), dr["RepairPerso"] as string, dr["RepairName"] as string, (int)dr["dormitoryID"], (DateTime)dr["RepairTime"], (DateTime)dr["HandleTime"], (int)dr["Count"], dr["HandlePerso"] as string, dr["Explain"] as string, (int)dr["State"]));
                }
                DBHelper.CloseConnection();
            }
            return re;
        }

        //添加物品名信息
        public int InsertRepairDAL(Model.Repair rep)
        {
            return DBHelper.ExecQuery("Insert into [Repair]([RepairPerso],[RepairName],[dormitoryID],[RepairTime],[HandleTime],[Count],[HandlePerso],[Explain],[State]) values('" + rep.RepairPerso + "','" + rep.RepairName + "','" + rep.dormitoryID + "','" + rep.RepairTime + "','" + rep.HandleTime + "','" + rep.Count + "','" + rep.HandlePerso + "','" + rep.Explain + "',0)");
        }
        //更新学员信息

        public int UpdateRepairDAL(Model.Repair rep)
        {
            string sql = "Update [Repair] set [State]=0";

            if (!string.IsNullOrEmpty(rep.RepairPerso))
                sql += ",[RepairPerso]='" + rep.RepairPerso + "'";

            if (!string.IsNullOrEmpty(rep.RepairName))
                sql += ",[RepairName]='" + rep.RepairName + "'";

            if (!string.IsNullOrEmpty(rep.dormitoryID.ToString()))
                sql += ",[dormitoryID]='" + rep.dormitoryID + "'";

            if (!string.IsNullOrEmpty(rep.RepairTime.ToString()))
                sql += ",[RepairTime]='" + rep.RepairTime + "'";

            if (!string.IsNullOrEmpty(rep.HandleTime.ToString()))
                sql += ",[HandleTime]='" + rep.HandleTime + "'";

            if (!string.IsNullOrEmpty(rep.Count.ToString()))
                sql += ",[Count]='" + rep.Count + "'";

            if (!string.IsNullOrEmpty(rep.HandlePerso))
                sql += ",[HandlePerso]='" + rep.HandlePerso + "'";

            if (!string.IsNullOrEmpty(rep.Explain))
                sql += ",[Explain]='" + rep.Explain + "'";

            sql += " where [RepairID]='" + rep.RepairID + "'";
            return DBHelper.ExecQuery(sql);
        }

        //删除维修信息
        public int DeleteRepairDAL(string id)
        {
            return DBHelper.ExecQuery("Update [Repair] set [State]=1 where [RepairID] in (" + id + ")");
        }
    }
}
