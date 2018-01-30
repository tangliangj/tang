using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 模型类：宿舍信息表
    /// </summary>

    [Serializable]
    public class Dormitory
    {
        //构造函数 重构方法
        public Dormitory() { }
        /// <summary>
        /// 构造：根据给定的数据创建用户对象
        /// </summary>
        /// <param name="dormitoryid">宿舍编号</param>
        /// <param name="dormitorygrade">宿舍等级</param>
        /// <param name="dormitoryperso">宿舍人数</param>
        /// <param name="dormitoryprice">价格</param>
        /// <param name="bedss">床位</param>
        /// <param name="dormitoryboos">宿舍长</param>
        /// <param name="explain">宿舍说明</param>
        /// <param name="state">宿舍状态</param>
        /// <param name="isbn">图片名</param>


        public Dormitory(int dormitoryid, string dormitorygrade, int dormitoryperso, int dormitoryprice, string bedss, string dormitoryboos, string explain, int state, string isbn)
        {
            dormitoryID = dormitoryid;
            dormitoryGrade = dormitorygrade;
            dormitoryPerso = dormitoryperso;
            dormitoryPrice = dormitoryprice;
            beds = bedss;
            DormitoryBoos = dormitoryboos;
            Explain = explain;
            State = state;
            ISBN = isbn;
        }

        /// <summary>
        /// 宿舍编号
        /// </summary>
        public int dormitoryID { get; set; }

        /// <summary>
        /// 宿舍等级
        /// </summary>
        public string dormitoryGrade { get; set; }

        /// <summary>
        /// 宿舍人数
        /// </summary>
        public int dormitoryPerso { get; set; }

        /// <summary>
        /// 价格
        /// </summary>
        public int dormitoryPrice { get; set; }

        /// <summary>
        /// 床位
        /// </summary>
        public string beds { get; set; }

        /// <summary>
        /// 宿舍长
        /// </summary>
        public string DormitoryBoos { get; set; }

        /// <summary>
        /// 宿舍说明
        /// </summary>
        public string Explain { get; set; }

        /// <summary>
        /// 宿舍状态
        /// </summary>
        public int State { get; set; }

        /// <summary>
        /// 图片名
        /// </summary>
        public string ISBN { get; set; }

    }
}
