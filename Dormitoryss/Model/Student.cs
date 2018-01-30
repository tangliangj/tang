using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 模型类：学生信息表
    /// </summary>
    
    [Serializable]
    public class Student
    {
        //构造函数 重构方法
        public Student() { }
        /// <summary>
        /// 构造：根据给定的数据创建用户对象
        /// </summary>
        /// <param name="studentid">学生编号</param>
        /// <param name="studentname">姓名</param>
        /// <param name="age">年龄</param>
        /// <param name="gender">性别</param>
        /// <param name="dormitoryid">宿舍号</param>
        /// <param name="place">籍贯</param>
        /// <param name="accommodationtime">入住时间</param>
        /// <param name="leavetimess">离开时间</param>
        /// <param name="phone">手机号</param>
        /// <param name="explains">说明</param>
        /// <param name="state">状态</param>

      public Student(string studentid, string studentname, int age, string gender, int dormitoryid, string place, DateTime accommodationtime, DateTime leavetimess, string phone,string explains,int state )
        {
            StudentID = studentid;
            StudentName = studentname;
            Age = age;
            Gender = gender;
            dormitoryID = dormitoryid;
            Place = place;
            Accommodationtime = accommodationtime;
            leavetime = leavetimess;
            Phone = phone;
            Explains = explains;
            State = state;
        }

        /// <summary>
      /// 学生编号
        /// </summary>
        public string StudentID { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string StudentName { get; set; }

        /// <summary>
        /// 年龄
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public string Gender { get; set; }

        /// <summary>
        /// 宿舍号
        /// </summary>
        public int dormitoryID { get; set; }

        /// <summary>
        /// 籍贯
        /// </summary>
        public string Place { get; set; }

        /// <summary>
        /// 入住时间
        /// </summary>
        public DateTime Accommodationtime { get; set; }

        /// <summary>
        /// 离开时间
        /// </summary>
        public DateTime leavetime { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        public string Phone { get; set; }

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
