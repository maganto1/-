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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddInfo fm = new AddInfo();
            fm.Show();
        }


        private void ToolStripMenuItem4_Click_1(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void ToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            this.Hide();
            AlterInfo fm = new AlterInfo();
            fm.Show();
        }

        private void ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            SearchInfo fm = new SearchInfo();
            fm.Show();
        }
    }
}
