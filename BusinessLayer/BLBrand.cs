using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DAL;
using BusinessObjects;

namespace BusinessLayer
{
   public class BLBrand
    {
        DBConnect dbc;
        SqlCommand cmd;

        public BLBrand()
        {
            dbc = new DBConnect();
        }
        public Int64 InsertBrand(Brand obj)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "SP_MANAGE_BRAND";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "INSERT");
                cmd.Parameters.AddWithValue("@BrandName", obj.BrandName);
                cmd.Parameters.AddWithValue("@Description", obj.Description);
                cmd.Parameters.AddWithValue("@requestedby", obj.requestedBy);

                return dbc.ExecuteQuery(cmd);

            }
            catch (Exception ex)
            {
                return -1;
            }
            finally
            {
                cmd.Dispose();
            }
        }

        public Int64 UpdateBrand(Brand obj)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "SP_MANAGE_BRAND";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "UPDATE");
                cmd.Parameters.AddWithValue("@BrandId", obj.BrandId);
                cmd.Parameters.AddWithValue("@BrandName", obj.BrandName);
                cmd.Parameters.AddWithValue("@Description", obj.Description);
                cmd.Parameters.AddWithValue("@requestedby", obj.requestedBy);

                return dbc.ExecuteQuery(cmd);

            }
            catch (Exception ex)
            {
                return -1;
            }
            finally
            {
                cmd.Dispose();
            }
        }
        public int DeleteBrand(Brand obj)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "SP_MANAGE_BRAND";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "DELETE");
                cmd.Parameters.AddWithValue("@BrandId", obj.BrandId);

                return dbc.ExecuteQuery(cmd);

            }
            catch (Exception ex)
            {
                return -1;
            }
            finally
            {
                cmd.Dispose();
            }
        }
        public DataTable GetAllBrand()
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "SP_MANAGE_BRAND";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "GETALL");

                return dbc.ExecuteQueryDataTable(cmd);
            }
            catch
            {
                return null;
            }
            finally
            {
                cmd.Dispose();
            }

        }
        public DataTable GetAllBrandById(int id)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "SP_MANAGE_BRAND";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "GETALL");
                cmd.Parameters.AddWithValue("@BrandId", id);
                return dbc.ExecuteQueryDataTable(cmd);
            }
            catch
            {
                return null;
            }
            finally
            {
                cmd.Dispose();
            }

        }
    }
}
