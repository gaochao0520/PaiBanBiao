﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace PaiBan.DBSQL
{
    public class ErrorHandle   //错误信息提醒
    {

        public static void showError(System.Exception e)
        {

            MessageBox.Show(e.Message);

        }


    }
}
