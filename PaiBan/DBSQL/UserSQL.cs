using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PaiBan.DBSQL;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace PaiBan.DBSQL
{
    public class UserSQL
    {
        public static DataTable getAllUser()
        {
            try
            {
                string sqlStr = "select * from dbo.Admin";

                DataSet dt = SqlHelper.ExecuteDataset(SqlHelper.GetConnection(), CommandType.Text, sqlStr);

                if(dt.Tables[0].Rows.Count>0)
                {
                    return dt.Tables[0];
                }
                return null;
            }
            catch(SyntaxErrorException e)
            {
                ErrorHandle.showError(e);
                return null;
            }
        }


        public static int insertUser(string userName,string userRole)
        {
            try
            {
                int i = -1;
                string sqlStr = "insert into dbo.Admin values('" + userName + "','" + userRole + "')";

                i = SqlHelper.ExecuteNonQuery(SqlHelper.GetConnSting(), CommandType.Text, sqlStr);

                return i;
            }
            catch(SyntaxErrorException e)
            {
                ErrorHandle.showError(e);
                return -1;
            }
        }


        public static int updataUser(string id,string userName,string userRole)
        {
            try
            {
                int i = -1;
                string sqlStr = "update dbo.Admin set UserName='" + userName + "',UserRole='" + userRole + "'where Id="+id;
                i = SqlHelper.ExecuteNonQuery(SqlHelper.GetConnSting(), CommandType.Text, sqlStr);

                return i;
            }
            catch(SyntaxErrorException e)
            {
                ErrorHandle.showError(e);
                return -1;
            }
        }


        public static int deleteUser(string id)
        {
            try
            {
                int i = -1;
                string sqlStr = "delete from dbo.Admin where Id=" + id;
                i = SqlHelper.ExecuteNonQuery(SqlHelper.GetConnSting(), CommandType.Text, sqlStr);
                return i;
            }
            catch (SyntaxErrorException e)
            {
                ErrorHandle.showError(e);
                return -1;
            }
        }


        public static DataTable getSomeUser()
        {
            try
            {
                string sqlStr = "select top 8 * from dbo.Admin where dbo.Admin.UserRole='主任'order by newid()";

                DataSet dt = SqlHelper.ExecuteDataset(SqlHelper.GetConnection(), CommandType.Text, sqlStr);

                if (dt.Tables[0].Rows.Count > 0)
                {
                    return dt.Tables[0];
                }
                return null;
            }
            catch (SyntaxErrorException e)
            {
                ErrorHandle.showError(e);
                return null;
            }
        }

    }
}
