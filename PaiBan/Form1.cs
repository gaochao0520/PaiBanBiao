using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PaiBan.DBSQL;

namespace PaiBan
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataTable dt = UserSQL.getAllUser();
            if(dt!=null)
            {
                this.dataGridView1.Rows.Clear();
                for(int i=0;i<dt.Rows.Count;i++)
                {
                    this.dataGridView1.Rows.Add(i+1,
                        dt.Rows[i]["UserName"],
                        dt.Rows[i]["UserRole"],
                        "删除");
                    this.dataGridView1.Rows[i].Tag = dt.Rows[i];
                }
            }
            this.dataGridView1.ClearSelection();
        }

        private void skinButton1_Click(object sender, EventArgs e)
        {
            TianjiaYuanGong tianJiaYuanGong = new TianjiaYuanGong();
            tianJiaYuanGong.ShowDialog();
            if(tianJiaYuanGong.DialogResult==DialogResult.OK)
            {
                this.ReFresh();
            }
        }


        private void ReFresh()
        {
            this.dataGridView1.Rows.Clear();
            DataTable dt = UserSQL.getAllUser();
            if (dt != null)
            {
                this.dataGridView1.Rows.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    this.dataGridView1.Rows.Add(i + 1,
                        dt.Rows[i]["UserName"],
                        dt.Rows[i]["UserRole"],
                        "删除");
                    this.dataGridView1.Rows[i].Tag = dt.Rows[i];
                }
            }
            this.dataGridView1.ClearSelection();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex!=-1)
            {
                if(e.ColumnIndex==1)
                {
                    DataRow dr = (DataRow)this.dataGridView1.Rows[e.RowIndex].Tag;
                    TianjiaYuanGong add = new TianjiaYuanGong(dr);
                    add.Text="查看用户信息";

                    add.ShowDialog();
                    if(add.DialogResult==DialogResult.OK)
                    {
                        ReFresh();
                    }
                }
                if(e.ColumnIndex==3)
                {
                    if(MessageBox.Show("确定删除吗？","提示信息",MessageBoxButtons.OKCancel,MessageBoxIcon.Question)==DialogResult.OK)
                    {
                        DataRow dr = (DataRow)this.dataGridView1.Rows[e.RowIndex].Tag;
                        //删除
                        int i = DBSQL.UserSQL.deleteUser(dr["Id"].ToString());
                        if (i > 0)
                        {
                            MessageBox.Show("删除成功！");
                            ReFresh();
                        }
                    }
                }
            }
        }

        private void skinButton2_Click(object sender, EventArgs e)
        {
            PaiBanGuanLi paiBanGuanLi = new PaiBanGuanLi();
            paiBanGuanLi.ShowDialog();
            if (paiBanGuanLi.DialogResult == DialogResult.OK)
            {
                this.ReFresh();
            }
        }

    }
}
