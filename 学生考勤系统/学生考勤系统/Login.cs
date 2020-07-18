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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (radioButton1.Checked)
                {
                    if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "")
                    {
                        MessageBox.Show("输入账号或密码为空！");
                    }
                    else if (学生考勤系统.user.use.CheckUserPassword(textBox1.Text.Trim(), textBox2.Text.Trim(), "Student_Login_info"))
                    {
                        MessageBox.Show("登入成功！");
                        this.Visible = false;
                        SearchInfo fm = new SearchInfo();
                        fm.Show();
                    }
                    else
                    {
                        MessageBox.Show("登入失败！");
                    }
                }
                else if (radioButton2.Checked == false)
                {
                    MessageBox.Show("选择登入方式");
                }
                if (radioButton2.Checked)
                {
                    if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "")
                    {
                        MessageBox.Show("输入账号或密码为空！");
                    }
                    else if (学生考勤系统.user.use.CheckUserPassword(textBox1.Text.Trim(), textBox2.Text.Trim(), "Teacher_Login_Info"))
                    {
                        MessageBox.Show("登入成功！");
                        this.Visible = false;
                        Menu fm = new Menu();
                        fm.Show();
                    }
                    else
                    {
                        MessageBox.Show("登入失败！", "错误提示");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误提示");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }
    }
}

