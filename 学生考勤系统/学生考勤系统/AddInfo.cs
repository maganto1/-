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
    public partial class AddInfo : Form
    {
        public AddInfo()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || comboBox1.Text.Trim() == "")
                {
                    MessageBox.Show("添加信息不能空！");
                }
                else if (user.use.Add(Convert.ToInt32(textBox1.Text.Trim()), textBox2.Text.Trim(), comboBox1.Text.Trim(), dateTimePicker1.Text.Trim()))
                {
                    MessageBox.Show("添加成功！");
                }
                else
                {
                    MessageBox.Show("学号，课程不存在或课程结束", "信息提示");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误提示");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Menu fm = new Menu();
            fm.Show();
        }
    }
}
