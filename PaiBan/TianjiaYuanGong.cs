using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaiBan
{
    public partial class TianjiaYuanGong : Form
    {
        DataRow userData = null;
        public TianjiaYuanGong()
        {
            InitializeComponent();
            this.skinButton1.Visible = true;
            this.skinButton2.Visible = false;
        }


        public TianjiaYuanGong(DataRow dr)
        {
            userData = dr;

            InitializeComponent();
            this.skinButton1.Visible = false;
            this.skinButton2.Visible = true;

            ShowUserData(userData);

        }

        public void ShowUserData(DataRow dr)
        {
            if (dr != null)
            {
                this.textBox1.Text = dr["UserName"].ToString();
                this.textBox2.Text = dr["UserRole"].ToString();
            }
        }

        private void skinButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void skinButton1_Click(object sender, EventArgs e)
        {
            int i = DBSQL.UserSQL.insertUser(this.textBox1.Text.Trim(),
                this.textBox2.Text.Trim());

            if (i > 0)
            {
                MessageBox.Show("保存成功！");
                this.DialogResult = DialogResult.OK;
            }
        }

        private void skinButton2_Click(object sender, EventArgs e)
        {
            int i = DBSQL.UserSQL.updataUser(userData["Id"].ToString(),
                this.textBox1.Text.Trim(),
                this.textBox2.Text.Trim());

            if(i>0)
            {
                MessageBox.Show("更新成功！");
                this.DialogResult = DialogResult.OK;
            }

        }
    }
}
