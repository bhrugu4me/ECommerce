using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data.SqlClient;
using System.Data;

namespace BusinessLayer
{
    public class BLUtility
    {
        DBConnect objdb;

        //tablename = user, columnname=userid, where= username=bhrugu4me
        public string GetSingleVal(string tablename,string columnname,string where="")
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                objdb = new DBConnect();
                cmd.CommandText = "select " + columnname + " from " + tablename + where == "" ? ";" : " where = " + where + ";";
                cmd.CommandType = CommandType.Text;
                return objdb.ExecuteStringQuery(cmd);
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
