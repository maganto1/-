using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 学生考勤系统
{
    public partial class AlterInfo : Form
    {
        string change;
        int reasult = 1, reasult2;
        int Num;
        string time, course, situation;
        public AlterInfo()
        {
            InitializeComponent();
        }

        private void AlterInfo_Load(object sender, EventArgs e)
        {
            string sql = "select Student_Info.学号,姓名,性别,班级编号,课程编号,考勤记录,convert(char,考勤日期,111) as 考勤日期 from Student_Info,Check_Info where Student_Info.学号=Check_Info.学号";
            DataSet ds = 学生考勤系统.DataSqlServer.DSL.GetDataSet(sql, "Student_Info");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Student_Info";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            dateTimePicker1.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            change = textBox1.Text.Trim();
            Num = Convert.ToInt32(textBox1.Text.Trim());
            time = dateTimePicker1.Text.Trim();
            situation = textBox6.Text.Trim();
            course = textBox4.Text.Trim();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "" || textBox4.Text == "" || textBox6.Text == "")
                {
                    MessageBox.Show("修改内容不能为空!");
                }
                else
                {
                    string sql3 = string.Format("select count(*) from Course_Info where 课程编号='{0}'", textBox4.Text.Trim());
                    int r2 = Convert.ToInt32(DataSqlServer.DSL.ExecuteScalar(sql3));
                    reasult2 = Convert.ToInt32(r2);
                    string sql4 = string.Format("select count(*) from Course_Info where 课程编号 ={0} and 结束时间 > '{1}'",textBox4.Text.Trim(),dateTimePicker1.Text.Trim());
                    int reasult3 = Convert.ToInt32(DataSqlServer.DSL.ExecuteScalar(sql3));
                    if (change != textBox1.Text.Trim())
                    {
                        string sql = string.Format("select count(*) from Student_Info where 学号='{0}'", textBox1.Text.Trim());
                        int r = Convert.ToInt32(DataSqlServer.DSL.ExecuteScalar(sql));
                        reasult = Convert.ToInt32(r);
                    }
                    if (reasult == 1 && reasult2 == 1 && reasult3 ==1)
                    {
                        string sql = string.Format("update Check_Info set 学号={0},课程编号='{1}',考勤记录='{2}',考勤日期='{3}' where 学号={4}and 课程编号='{5}' and 考勤记录='{6}' and 考勤日期 = '{7}'", textBox1.Text.Trim(), textBox4.Text.Trim(), textBox6.Text.Trim(), dateTimePicker1.Text.Trim(), Num, course, situation, time);
                        int rt = DataSqlServer.DSL.ExecuteNonQuery(sql);
                        int num = Convert.ToInt32(rt);
                        if (num == 1)
                        {
                            MessageBox.Show("修改成功！");
                        }
                    }
                    else
                    {
                        MessageBox.Show("修改失败！请检查学号是否重复及课程存在或结束！", "错误提示");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误提示");
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Close();
            Menu fm = new Menu();
            fm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox4.Text = "";
            textBox6.Text = "";
            dateTimePicker1.Text = "";
        }
    }
}
