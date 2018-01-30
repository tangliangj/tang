
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 模型类：维修信息表
    /// </summary>

    [Serializable]

    public class Repair
    {
        //构造函数 重构方法
        public Repair() { }
        /// <summary>
        /// 构造：根据给定的数据创建用户对象
        /// </summary>
        /// <param name="repairid">维修编号</param>
        /// <param name="repairperso">报修人</param>
        /// <param name="repairname">物品名</param>
        /// <param name="dormitoryid">宿舍号</param>
        /// <param name="repairtime">报修时间</param>
        /// <param name="handletime">处理时间</param>
        /// <param name="count">数量</param>
        /// <param name="handleperso">处理人</param>
        /// <param name="explain">说明</param>
        /// <param name="state">状态</param>

        public Repair(string repairid, string repairperso, string repairname, int dormitoryid, DateTime repairtime, DateTime handletime, int count, string handleperso, string explain, int state)
        {
            RepairID = repairid;
            RepairPerso = repairperso;
            RepairName = repairname;
            dormitoryID = dormitoryid;
            RepairTime = repairtime;
            HandleTime = handletime;
            Count = count;
            HandlePerso = handleperso;
            Explain = explain;
            State = state;
        }
        /// <summary>
        /// 维修编号
        /// </summary>
        public string RepairID { get; set; }

        /// <summary>
        /// 报修人
        /// </summary>
        public string RepairPerso { get; set; }

        /// <summary>
        /// 物品名
        /// </summary>
        public string RepairName { get; set; }

        /// <summary>
        /// 宿舍号
        /// </summary>
        public int dormitoryID { get; set; }

        /// <summary>
        /// 报修时间
        /// </summary>
        public DateTime RepairTime { get; set; }

        /// <summary>
        /// 处理时间
        /// </summary>
        public DateTime HandleTime { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// 处理人
        /// </summary>
        public string HandlePerso { get; set; }

        /// <summary>
        /// 说明
        /// </summary>
        public string Explain { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public int State { get; set; }
    }
}