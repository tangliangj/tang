using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace Rule
{
    /// <summary>
    /// 业务规则类：维修对象
    /// </summary>
    public class RepairRule
    {
        //查询指定的维修对象是否存在
        public bool TestInsert(string uid)
        {
            return (int)DAL.DBHelper.ExecScalar(" select count(*) from [Repair] where [RepairName]='" + uid + "' and [State]=0") == 0;
        }

        //查询指定的编号是否存在相关的数据
        public bool TestDelete(string id)
        {
            return true;
        }
    }
}
