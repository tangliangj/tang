using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace Rule
{
    /// <summary>
    /// 业务规则类：学员对象
    /// </summary>
    public class StudentRule
    {
        //查询指定的学员是否存在

        public bool TestInsert(string uid)
        {
            return (int)DAL.DBHelper.ExecScalar("select count(*) from [Student] where [StudentName]='" + uid + "' and [State]=0") == 0;
        }

        //查询指定的宿舍编号是否存在相关联的数据
        public bool TestDelete(string id)
        {
            return true;
        }
    }
}
