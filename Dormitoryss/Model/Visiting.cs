using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 模型类：来访信息
    /// </summary>
    
    [Serializable]
   public  class Visiting
    {
        //构造函数 重构方法
        public Visiting() { }
        /// <summary>
        /// 构造：根据给定的数据创建用户对象
        /// </summary>
        /// <param name="visitingid">来访编号</param>
        /// <param name="dormitoryid">宿舍号</param>
        /// <param name="visitingname">来访姓名</param>
        /// <param name="visitingtime">来访时间</param>
        /// <param name="state">来访状态</param>

        public Visiting(string visitingid, int dormitoryid, string visitingname, DateTime visitingtime, DateTime likaitime, int state)
        {
            VisitingID = visitingid;
            dormitoryID = dormitoryid;
            VisitingName = visitingname;
            VisitingTime = visitingtime;
            LikaiTime = likaitime;
            State = state;
        }

        /// <summary>
        /// 来访编号
        /// </summary>
        public string VisitingID { get; set; }

        /// <summary>
        /// 宿舍号
        /// </summary>
        public int dormitoryID { get; set; }

        /// <summary>
        /// 来访姓名
        /// </summary>
        public string VisitingName { get; set; }

        /// <summary>
        /// 来访时间
        /// </summary>
        public DateTime VisitingTime { get; set; }


        /// <summary>
        /// 离开时间
        /// </summary>
        public DateTime LikaiTime { get; set; }

        /// <summary>
        /// 来访状态
        /// </summary>
        public int State { get; set; }
    }
}
