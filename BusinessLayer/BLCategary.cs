using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using BusinessObjects;
using DAL;

namespace BusinessLayer
{
    public class BLCategary
    {
        DBConnect dbc;
        SqlCommand cmd;
        public BLCategary()
        {
            dbc = new DBConnect();
        }
        public int InsertCategory(Categary obj)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "SP_MANAGE_CATEGORY";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "INSERT");
                cmd.Parameters.AddWithValue("@categoryid", obj.CategaryId);
                cmd.Parameters.AddWithValue("@categoryname", obj.CategaryName);
                cmd.Parameters.AddWithValue("@description", obj.Description);
                cmd.Parameters.AddWithValue("@parentid", obj.ParentId);
                cmd.Parameters.AddWithValue("@requestedby", obj.requestedby);

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
        public int UpdateCategory(Categary obj)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "SP_MANAGE_CATEGORY";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "UPDATE");
                cmd.Parameters.AddWithValue("@categoryid", obj.CategaryId);
                cmd.Parameters.AddWithValue("@categoryname", obj.CategaryName);
                cmd.Parameters.AddWithValue("@description", obj.Description);
                cmd.Parameters.AddWithValue("@parentid", obj.ParentId);
                cmd.Parameters.AddWithValue("@requestedby", obj.requestedby);

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
        public DataTable GetAllCategory()
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "SP_MANAGE_CATEGORY";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "GETALL");

                return dbc.ExecuteQueryDataTable(cmd);
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                cmd.Dispose();
            }


        }

        public DataTable GetSubCategoryList(Categary obj)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "SP_MANAGE_CATEGORY";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "SubList");
                cmd.Parameters.AddWithValue("@categoryid", obj.CategaryId);

                return dbc.ExecuteQueryDataTable(cmd);
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                cmd.Dispose();
            }


        }

        public DataTable GetCategoryDetailByID(Categary obj)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "SP_MANAGE_CATEGORY";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "GETBYID");
                cmd.Parameters.AddWithValue("@categoryid", obj.CategaryId);

                return dbc.ExecuteQueryDataTable(cmd);
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                cmd.Dispose();
            }

        }
        public int DeleteCategory(Categary obj)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "SP_MANAGE_CATEGORY";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "DELETE");
                cmd.Parameters.AddWithValue("@categoryid", obj.CategaryId);

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


    }

}
