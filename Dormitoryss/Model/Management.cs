using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 模型类：宿舍日常管理信息表
    /// </summary>
    [Serializable]
    public class Management
    {
        //构造函数 重构方法
        public Management() { }
        /// <summary>
        /// 构造：根据给定的数据创建用户对象
        /// </summary>
        /// <param name="managementid">编号</param>
        /// <param name="dormitoryid">宿舍号</param>
        /// <param name="hygiene">卫生情况</param>
        /// <param name="inspectors">检查人员</param>
        /// <param name="managementtime">检查时间</param>
        /// <param name="explain">说明</param>
        /// <param name="state">状态</param>
        /// 

        public Management(string managementid, int dormitoryid, string hygiene, string inspectors, DateTime managementtime, string explain, int state)
        {
            ManagementID = managementid;
            dormitoryID = dormitoryid;
            Hygiene = hygiene;
            Inspectors = inspectors;
            ManagementTime = managementtime;
            Explain = explain;
            State = state;
        }

        /// <summary>
        /// 编号
        /// </summary>
        public string ManagementID { get; set; }

        /// <summary>
        /// 宿舍号
        /// </summary>
        public int dormitoryID { get; set; }

        /// <summary>
        /// 卫生情况
        /// </summary>
        public string Hygiene { get; set; }

        /// <summary>
        /// 检查人员
        /// </summary>
        public string Inspectors { get; set; }

        /// <summary>
        /// 检查时间
        /// </summary>
        public DateTime ManagementTime { get; set; }

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