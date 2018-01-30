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
    /// 对象操作类：学员信息
    /// </summary>
    public class StudentDAL
    {
        //根据给定条件查询学员信息
        public List<Model.Student> GetStudentDAL(string whereStr = null, int start = 1, int end = 10)
        {
            List<Model.Student> stu = new List<Model.Student>();

            if (DBHelper.OpenConnection())
            {
                SqlDataReader dr = DBHelper.ExecReader(whereStr);

                if (dr != null)
                {
                    while (dr.Read())
                        stu.Add(new Model.Student(dr["StudentID"].ToString(), dr["StudentName"] as string, (int)dr["Age"], dr["Gender"] as string, (int)dr["dormitoryID"], dr["Place"] as string, (DateTime)dr["Accommodationtime"], (DateTime)dr["leavetime"], dr["Phone"] as string, dr["Explains"] as string, (int)dr["State"]));

                }
                DBHelper.CloseConnection();
            }
            return stu;
        }
        //获取学员的数量
        public int GetStudentDAL()
        {
            return (int)DBHelper.ExecScalar("select count(*) from [Student]");
        }

        //添加新学员
        public int InsertStudentDAL(Model.Student stu)
        {
            return DBHelper.ExecQuery("Insert into [Student] ([StudentName],[Age],[Gender],[dormitoryID],[Place],[Accommodationtime],[leavetime],[Phone],[Explains]) values('" + stu.StudentName + "','" + stu.Age + "','" + stu.Gender + "','" + stu.dormitoryID + "','" + stu.Place + "','" + stu.Accommodationtime + "','" + stu.leavetime + "','" + stu.Phone + "','" + stu.Explains + "')");
        }

        //更新学员信息

        public int UpdateStudentDAL(Model.Student stu)
        {
            string sql = "Update [Student] set [State]=0";

            if (!string.IsNullOrEmpty(stu.StudentName))
                sql += ",[StudentName]='" + stu.StudentName + "'";

            if (!string.IsNullOrEmpty(stu.Age.ToString()))
                sql += ",[Age]='" + stu.Age + "'";

            if (!string.IsNullOrEmpty(stu.Gender))
                sql += ",[Gender]='" + stu.Gender + "'";

            if (!string.IsNullOrEmpty(stu.dormitoryID.ToString()))
                sql += ",[dormitoryID]='" + stu.dormitoryID + "'";

            if (!string.IsNullOrEmpty(stu.Place))
                sql += ",[Place]='" + stu.Place + "'";

            if (!string.IsNullOrEmpty(stu.Accommodationtime.ToString()))
                sql += ",[Accommodationtime]='" + stu.Accommodationtime + "'";

            if (!string.IsNullOrEmpty(stu.leavetime.ToString()))
                sql += ",[leavetime]='" + stu.leavetime + "'";

            if (!string.IsNullOrEmpty(stu.Phone))
                sql += ",[Phone]='" + stu.Phone + "'";

            if (!string.IsNullOrEmpty(stu.Explains))
                sql += ",[Explains]='" + stu.Explains + "'";

            sql += " where [StudentID]='" + stu.StudentID + "'";
            return DBHelper.ExecQuery(sql);
        }

        //删除学员信息
        public int DeleteStudentDAL(string id)
        {
            return DBHelper.ExecQuery("Update [Student] set [State]=1 where [StudentID] in (" + id + ")");
        }
    }
}
