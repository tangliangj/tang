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
    /// 对象操作类：宿舍信息
    /// </summary>
    public class DormitoryDAL
    {
        //查询宿舍信息
        public List<Model.Dormitory> GetDormitoryDAL(string where = null, int start = 1, int end = 10)
        {
            List<Model.Dormitory> dor = new List<Model.Dormitory>();

            if (DBHelper.OpenConnection())
            {
                SqlDataReader dr = DBHelper.ExecReader("select * from [Dormitory] where [State]=0 " + where + " ORDER BY dormitoryID");

                if (dr != null)
                {
                    while (dr.Read())
                        dor.Add(new Model.Dormitory((int)dr["DormitoryID"], dr["dormitoryGrade"] as string, (int)dr["dormitoryPerso"], (int)dr["dormitoryPrice"], dr["beds"] as string, dr["DormitoryBoos"] as string, dr["Explain"] as string, (int)dr["State"],dr["ISBN"] as string));
                }
                dr.Close();
                DBHelper.CloseConnection();
            }
            return dor;
        }

        //获取宿舍的人数
        public int GetDormitoryDAL()
        {
            return (int)DBHelper.ExecScalar("select count(*) from [Dormitory]");
        }

        //添加宿舍信息
        public int InsertDormitoryDAL(Model.Dormitory dor)
        {
            return DBHelper.ExecQuery("insert into [Dormitory] ([dormitoryGrade],[dormitoryPerso],[dormitoryPrice],[beds],[DormitoryBoos],[Explain],[State],[ISBN]) values('" + dor.dormitoryGrade + "','" + dor.dormitoryPerso + "','" + dor.dormitoryPrice + "','" + dor.beds + "','" + dor.DormitoryBoos + "','" + dor.Explain +"','"+0 + "','"+dor.ISBN + "')");
        }

        //更新宿舍信息

        public int UpdateDormitoryDAL(Model.Dormitory dor)
        {
            string sql = "update [Dormitory] set [State]=0";

            if (!string.IsNullOrEmpty(dor.dormitoryGrade))
                sql += ",[dormitoryGrade]='" + dor.dormitoryGrade + "'";

            if (!string.IsNullOrEmpty(dor.dormitoryPerso.ToString()))
                sql += ",[dormitoryPerso]='" + dor.dormitoryPerso + "'";

            if (!string.IsNullOrEmpty(dor.dormitoryPrice.ToString()))
                sql += ",[dormitoryPrice]='" + dor.dormitoryPrice + "'";

            if (!string.IsNullOrEmpty(dor.beds))
                sql += ",[beds]='" + dor.beds + "'";

            if (!string.IsNullOrEmpty(dor.DormitoryBoos))
                sql += ",[DormitoryBoos]='" + dor.DormitoryBoos + "'";

            if (!string.IsNullOrEmpty(dor.Explain))
                sql += ",[Explain]='" + dor.Explain + "'";

            sql += " where [dormitoryID]=" + dor.dormitoryID;
            return DBHelper.ExecQuery(sql);
        }


        //删除宿舍信息

        public int DeleteDormitoryDAL(string id)
        {
            return DBHelper.ExecQuery("update [Dormitory] set [State]=1 where [ID] in (" + id + ")");
        }
    }
}
