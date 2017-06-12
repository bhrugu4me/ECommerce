
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
    public class BLUser
    {

        DBConnect dbc;
        SqlCommand cmd;
        public BLUser()
        {
            dbc = new DBConnect();
        }
        public Int64 InsertUser(User obj)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "SP_MANAGE_USER";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "INSERT");
                cmd.Parameters.AddWithValue("@userid", obj.UserId);
                cmd.Parameters.AddWithValue("@usertypeid", obj.UserTypeId);
                cmd.Parameters.AddWithValue("@firstname", obj.FirstName);
                cmd.Parameters.AddWithValue("@lastname", obj.LastName);
                cmd.Parameters.AddWithValue("@password", obj.Password);
                cmd.Parameters.AddWithValue("@emailid", obj.EmailId);
                cmd.Parameters.AddWithValue("@mobileno", obj.MobileNo);
                cmd.Parameters.AddWithValue("@gender", obj.Gender);
                cmd.Parameters.AddWithValue("@birthdate", obj.Birthdate);
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


        public Int64 UpdateUser(User obj)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "SP_MANAGE_USER";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "UPDATE");
                cmd.Parameters.AddWithValue("@userid", obj.UserId);
                cmd.Parameters.AddWithValue("@usertypeid", obj.UserTypeId);
                cmd.Parameters.AddWithValue("@firstname", obj.FirstName);
                cmd.Parameters.AddWithValue("@lastname", obj.LastName);
              //  cmd.Parameters.AddWithValue("@password", obj.Password);
                cmd.Parameters.AddWithValue("@emailid", obj.EmailId);
                cmd.Parameters.AddWithValue("@ContactNo", obj.MobileNo);
                cmd.Parameters.AddWithValue("@gender", obj.Gender);
                cmd.Parameters.AddWithValue("@birthdate", obj.Birthdate);
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

        public DataTable CheckLogin(User obj)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "SP_MANAGE_USER";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "LOGIN");
                cmd.Parameters.AddWithValue("@password", obj.Password);
                cmd.Parameters.AddWithValue("@emailid", obj.EmailId);


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
        public Int64 ChangePwd(User obj)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "SP_MANAGE_USER";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "CHANGEPWD");
                cmd.Parameters.AddWithValue("@password", obj.Password);
                cmd.Parameters.AddWithValue("@UserId", obj.UserId);

                return dbc.ExecuteQuery(cmd);

            }
            catch (Exception ex)
            {
                return 0;
            }
            finally
            {
                cmd.Dispose();
            }
        }

        public DataTable GetAllUsers()
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "SP_MANAGE_USER";
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

        public DataTable GetUserDetailByUserID(User obj)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "SP_MANAGE_USER";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "GETBYID");
                cmd.Parameters.AddWithValue("@userid", obj.UserId);

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

        public Int64 DeleteUserByUserID(User obj)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "SP_MANAGE_USER";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "DELETE");
                cmd.Parameters.AddWithValue("@userid", obj.UserId);

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
