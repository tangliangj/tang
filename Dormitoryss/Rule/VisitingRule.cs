using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;
namespace Rule
{
    /// <summary>
    /// 业务规则类： 来访信息对象
    /// </summary>

    public class VisitingRule
    {
        //查询指定的来访对象是否存在
        public bool TestInsert(string uid)
        {
            return (int)DAL.DBHelper.ExecScalar("select count(*) from [Visiting] where [VisitingName]='" + uid + "' and [State]=0") == 0;
        }

        //查询指定的来访人编号是否存在相关联的数据
        public bool TestDelete(string id)
        {
            return true;
        }
    }
}
