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
    public partial class PaiBanGuanLi : Form
    {
        DataTable dt1;
        DataTable dt2;
        DataTable dt3;

        DataTable dt4;
        public PaiBanGuanLi()
        {
            InitializeComponent();
        }

        private void skinButton1_Click(object sender, EventArgs e)
        {

        }

        private void skinButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PaiBanGuanLi_Load(object sender, EventArgs e)
        {
            dt1 = DBSQL.UserSQL.getSomeUser();

            dt2 = DBSQL.UserSQL.getAllUser();

            DataTable newDataTable = dt1.Clone();

            object[] obj = new object[newDataTable.Columns.Count];
            //添加DataTable1的数据
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                dt1.Rows[i].ItemArray.CopyTo(obj, 0);
                newDataTable.Rows.Add(obj);
            }
            //添加DataTable2的数据
            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                dt2.Rows[i].ItemArray.CopyTo(obj, 0);
                newDataTable.Rows.Add(obj);
            }



            Random r = new Random();
            int MAX = newDataTable.Rows.Count - 1;
            while (MAX > 0)
            {
                int newPos = r.Next(0, MAX);
                DataRow dr = newDataTable.NewRow();
                dr.ItemArray = newDataTable.Rows[newPos].ItemArray;
                newDataTable.Rows[newPos].ItemArray = newDataTable.Rows[MAX].ItemArray;
                newDataTable.Rows[MAX].ItemArray = dr.ItemArray;
                MAX--;
            }


            dt3 = newDataTable;

            ReDataBind(dt3);

        }


        private void ReDataBind(DataTable dt)
        {
            string a = dt.Rows[0][1].ToString();
            string b = dt.Rows[1][1].ToString();

            if(a==b)
            {
                ReDataBind(dt3);
            }

            for(int i=1;i<dt.Rows.Count-1;i++)
            {
                string c = dt.Rows[i][1].ToString();
                string d = dt.Rows[i + 1][1].ToString();

                if(c==d)
                {
                    string e = dt.Rows[i - 1][1].ToString() ;
                    string f = e;
                    e = c;
                    c = f;

                    dt.Rows[i - 1][1] = e;
                    dt.Rows[i][1] = c;
                }
            }

            dt4 = dt;



            DataBind(dt4);
        }

        private void DataBind(DataTable d)
        {
            this.label21.Text = d.Rows[0][1].ToString();
            this.label22.Text = d.Rows[1][1].ToString();
            this.label23.Text = d.Rows[2][1].ToString();
            this.label24.Text = d.Rows[3][1].ToString();
            this.label25.Text = d.Rows[4][1].ToString();
            this.label26.Text = d.Rows[5][1].ToString();
            this.label27.Text = d.Rows[6][1].ToString();
            this.label28.Text = d.Rows[7][1].ToString();
            this.label29.Text = d.Rows[8][1].ToString();
            this.label30.Text = d.Rows[9][1].ToString();
            this.label31.Text = d.Rows[10][1].ToString();
            this.label32.Text = d.Rows[11][1].ToString();
            this.label33.Text = d.Rows[12][1].ToString();
            this.label34.Text = d.Rows[13][1].ToString();
            this.label35.Text = d.Rows[14][1].ToString();
            this.label36.Text = d.Rows[15][1].ToString();
            this.label37.Text = d.Rows[16][1].ToString();
            this.label38.Text = d.Rows[17][1].ToString();
            this.label39.Text = d.Rows[18][1].ToString();
            this.label40.Text = d.Rows[19][1].ToString();


            this.label41.Text = d.Rows[20][1].ToString();
            this.label42.Text = d.Rows[21][1].ToString();
            this.label43.Text = d.Rows[22][1].ToString();
            this.label44.Text = d.Rows[23][1].ToString();
            this.label45.Text = d.Rows[24][1].ToString();
            this.label46.Text = d.Rows[25][1].ToString();
            this.label47.Text = d.Rows[26][1].ToString();
            this.label48.Text = d.Rows[27][1].ToString();
            this.label49.Text = d.Rows[28][1].ToString();
            this.label50.Text = d.Rows[29][1].ToString();
            this.label51.Text = d.Rows[30][1].ToString();
            this.label52.Text = d.Rows[31][1].ToString();
            this.label53.Text = d.Rows[32][1].ToString();
            this.label54.Text = d.Rows[33][1].ToString();
            this.label55.Text = d.Rows[34][1].ToString();
            this.label56.Text = d.Rows[35][1].ToString();
            this.label57.Text = d.Rows[36][1].ToString();
            this.label58.Text = d.Rows[37][1].ToString();
            this.label59.Text = d.Rows[38][1].ToString();
            this.label60.Text = d.Rows[39][1].ToString();

        }
    }
}
