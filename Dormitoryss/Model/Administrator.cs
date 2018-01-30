using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 模型类：管理员信息表
    /// </summary>
    
    [Serializable]
   public  class Administrator
    {
        //构造函数 重构方法
        public Administrator() { }
        /// <summary>
        /// 构造：根据给定的数据创建用户对象
        /// </summary>
        /// <param name="adminid">管理员编号</param>
        /// <param name="adminname">管理员姓名</param>
        /// <param name="account">管理员账号</param>
        /// <param name="apassword">管理员密码</param>
        /// <param name="explains">说明</param>
        /// <param name="state">状态</param>

        public Administrator(string adminid, string adminname, string account, string apassword, string explains, int state)
        {
            AdminID = adminid;
            AdminName = adminname;
            Account = account;
            APassword = apassword;
            Explains = explains;
            State = state;
        }
        /// <summary>
        /// 管理员编号
        /// </summary>
        public string AdminID { get; set; }

        /// <summary>
        /// 管理员姓名
        /// </summary>
        public string AdminName { get; set; }

        /// <summary>
        /// 登录信息
        /// </summary>
        public string AdminInfo { get; set; }

        /// <summary>
        /// 管理员账号
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// 管理员密码
        /// </summary>
        public string APassword { get; set; }

        /// <summary>
        /// 说明
        /// </summary>
        public string Explains { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public int State { get; set; }
    }
}
