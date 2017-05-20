using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DAL
{
    public class DBConnect
    {
        SqlConnection cn;
        SqlDataAdapter da;
        public DBConnect()
        {
            cn = new SqlConnection();
            cn.ConnectionString = ConfigurationManager.ConnectionStrings["dbname"].ConnectionString;
        }

        public void OpenConnection()
        {
            try
            {
                if (cn.State == ConnectionState.Closed)
                    cn.Open();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }

        public void CloseConnection()
        {
            try
            {
                if (cn.State == ConnectionState.Open)
                    cn.Close();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }

        public int ExecuteQuery(SqlCommand cmd)
        {
            try
            {
                OpenConnection();
                cmd.Connection = cn;
                return Convert.ToInt32(cmd.ExecuteScalar().ToString());

            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return -1;
            }
            finally
            {
                CloseConnection();
            }
        }

        public string ExecuteStringQuery(SqlCommand cmd)
        {
            try
            {
                OpenConnection();
                cmd.Connection = cn;
                return cmd.ExecuteScalar().ToString();

            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return string.Empty;
            }
            finally
            {
                CloseConnection();
            }
        }


        public DataTable ExecuteQueryDataTable(SqlCommand cmd)
        {
            try
            {
                DataTable dt = new DataTable();
                da = new SqlDataAdapter();
                cmd.Connection = cn;
                OpenConnection();
                da.SelectCommand = cmd;
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return null;
            }

            finally
            {
                da.Dispose();
                CloseConnection();
            }
        }

        public bool ExecuteQueryBool(SqlCommand cmd)
        {
            try
            {
                DataTable dt = new DataTable();
                da = new SqlDataAdapter();
                cmd.Connection = cn;
                OpenConnection();
                da.SelectCommand = cmd;
                da.Fill(dt);
                return dt.Rows.Count > 0 ? true : false;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return false;
            }

            finally
            {
                da.Dispose();
                CloseConnection();
            }
        }
        public DataSet ExecuteQueryDataSet(SqlCommand cmd)
        {
            try
            {
                DataSet dt = new DataSet();
                da = new SqlDataAdapter();
                cmd.Connection = cn;
                OpenConnection();
                da.SelectCommand = cmd;
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return null;
            }

            finally
            {
                da.Dispose();
                CloseConnection();
            }
        }
    }
}
