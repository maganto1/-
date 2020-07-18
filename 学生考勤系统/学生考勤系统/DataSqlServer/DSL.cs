using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 学生考勤系统.DataSqlServer
{
    class DSL
    {
        private static string strConn = "server=.;database=学生考勤;uid=sa;pwd=root"; //SQL Server链接字符串
        /// <summary>
        /// 以Dataset读取数据库信息并返回datase类型值 
        /// </summary>
        /// <param name="sql">查询语句</param>
        /// <param name="come">查询的表名</param>
        /// <returns></returns>
        public static DataSet GetDataSet(string sql, string come)
        {
            if (strConn == null || strConn == "") return null;
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);   //创建DataAdapter数据适配器实例,DataAdapter对象在DataSet与数据之间起桥梁作用，dataadapt可以自己开启关闭连接
            DataSet ds = new DataSet();
            da.Fill(ds, come);                                    //fill()方法 在 DataSet 中添加或刷新行
            conn.Close();
            return ds;
        }

        /// <summary>
        /// ExecuteNonQuery方法重载，进行增删改
        /// </summary>
        /// <param name="sql">增删改的SQL语句</param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string sql)            //ExecuteNonQuery方法重载,sqlcomand中的ExecuteNonQuery一般用在增加,更新,查询状态判断
        {
            if (strConn == null || strConn == "")
                return 0;
            SqlConnection con = new SqlConnection(strConn);     //Sql链接类的实例化
            SqlCommand cmd = new SqlCommand(sql, con);          //建立对象通过SQLcommand进行增删改查
            con.Open();
            int n = cmd.ExecuteNonQuery();                      //ExecuteNonQuery返回受影响的行数，对于 Update,Insert,Delete  语句 执行成功是返回值为该命令所影响的行数，如果影响的行数为0时返回的值为0。对于所有其他类型的语句，返回值为 -1。
            con.Close();
            return n;
        }

        /// <summary>
        /// ExecuteScalar重载，进行查询
        /// </summary>
        /// <param name="sql">查询的SQL语句</param>
        /// <returns></returns>
        public static string ExecuteScalar(string sql)
        {
            if (strConn == null || strConn == "") return null;
            SqlConnection myConn = new SqlConnection(strConn);
            SqlCommand myCommand = new SqlCommand(sql, myConn);
            myConn.Open();
            /* ExecuteScalar执行命令对象的SQL语句，如果SQL语句是SELECT查询，则仅仅返回查询结果集中的第1行第1列
            而忽略其他的行和列。该方法所返回的结果为object类型，在使用之前必须强制转换为所需的类型。
            如果SQL语句不是SELECT查询，则返回结果没有任何作用。*/
            object ret = myCommand.ExecuteScalar();
            myConn.Close();
            if (ret == null) return null;
            return ret.ToString();                      //执行成功返回值为1,影响行数为0的话，则证明操作是不成功的，大于0则证明操作成功。
        }
    }
}
