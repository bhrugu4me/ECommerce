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
   public class BLUserType
    {
        DBConnect dbc;
        SqlCommand cmd;

        public BLUserType()
        {
            dbc = new DBConnect();

        }

        public Int64 InsertUserType(UserType obj)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "SP_MANAGE_USERTYPE";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "INSERT");
                cmd.Parameters.AddWithValue("@UserTypeId", obj.UserTypeId);
                cmd.Parameters.AddWithValue("@UserTypeName", obj.UserTypeName);
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

        public Int64 UpdateUserType(UserType obj)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "SP_MANAGE_USERTYPE";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "UPDATE");
                cmd.Parameters.AddWithValue("@UserTypeId", obj.UserTypeId);
                cmd.Parameters.AddWithValue("@UserTypeName", obj.UserTypeName);
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
        public Int64 DeleteUserType(UserType obj)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "SP_MANAGE_USERTYPE";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "DELETE");
                cmd.Parameters.AddWithValue("@UserTypeId", obj.UserTypeId);
          
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
        public DataTable GetAllUSerType()
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "SP_MANAGE_USERTYPE";
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
        public DataTable GetAllUSerTypeById(UserType obj)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "SP_MANAGE_USERTYPE";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "GETALL");
                cmd.Parameters.AddWithValue("@UserTypeId", obj.UserTypeId);
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
