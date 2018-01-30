using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data;
namespace DAL
{
    /// <summary>
    /// 对象操作类：来访信息表
    /// </summary>
    public class VisitingDAL
    {
       
        //查询来访信息
         public List<Model.Visiting > GetVisitingDAL(string where = null, int start = 1, int end = 10)
        {
            List<Model.Visiting> vis = new List<Model.Visiting>();

            if (DBHelper.OpenConnection())
            {
                SqlDataReader dr = DBHelper.ExecReader( where );

                if (dr != null)
                {
                    while (dr.Read())
                        vis.Add(new Model.Visiting(dr["VisitingID"].ToString(), (int)dr["dormitoryID"], dr["VisitingName"] as string, (DateTime)dr["VisitingTime"], (DateTime)dr["LikaiTime"], (int)dr["State"]));
                }

                DBHelper.CloseConnection();
            }
            return vis;
        }


       
        //添加来访信息

        public int InsertVisitingDAL(Model.Visiting vis)
        {
            return DBHelper.ExecQuery("insert into [Visiting] ([dormitoryID],[VisitingName],[VisitingTime],[LikaiTime],[State]) values('" + vis.dormitoryID + "','" + vis.VisitingName + "','" + vis.VisitingTime + "','" + vis.LikaiTime + "',0)");
        }

        //更新来访信息
        public int UpdateVisitingDAL(Model.Visiting vis)
        {
            string sql = "update [Visiting] set [State]=0";

            if (!string.IsNullOrEmpty(vis.dormitoryID.ToString()))
                sql += ",[dormitoryID]='" + vis.dormitoryID + "'";

            if (!string.IsNullOrEmpty(vis.VisitingName))
                sql += ",[VisitingName]='" + vis.VisitingName + "'";

            if (!string.IsNullOrEmpty(vis.VisitingTime.ToString()))
                sql += ",[VisitingTime]='" + vis.VisitingTime + "'";

            if (!string.IsNullOrEmpty(vis.LikaiTime.ToString()))
                sql += ",[LikaiTime]='" + vis.LikaiTime + "'";

            sql += " where [VisitingID]=" + vis.VisitingID;
            return DBHelper.ExecQuery(sql);
        }

        //删除来访信息
        public int DeleteVisitingDAL(string id)
        {
            return DBHelper.ExecQuery("delete  from  [Visiting] where VisitingID= " + id);
        }

    }
}
