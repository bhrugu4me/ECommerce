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
    public class BLUserAddress
    {
        DBConnect dbc;
        SqlCommand cmd;
        public BLUserAddress()
        {
            dbc = new DBConnect();
        }

        public Int64 InsertUserAddress(UserAddress obj)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "SP_MANAGE_USERADDRESS";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "INSERT");
                cmd.Parameters.AddWithValue("@AddressId", obj.AddressId);
                cmd.Parameters.AddWithValue("@UserId", obj.UserId);
                cmd.Parameters.AddWithValue("@AddressType", obj.AddressType);
                cmd.Parameters.AddWithValue("@Address1", obj.Address1);
                cmd.Parameters.AddWithValue("@Address2", obj.Address2);
                cmd.Parameters.AddWithValue("@Landmark", obj.Landmark);
                cmd.Parameters.AddWithValue("@City", obj.City);
                cmd.Parameters.AddWithValue("@State", obj.State);
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

        public Int64 UpdateUserAddress(UserAddress obj)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "SP_MANAGE_USERADDRESS";
                cmd.Parameters.AddWithValue("@action", "UPDATE");
                cmd.Parameters.AddWithValue("@AddressId", obj.AddressId);
                cmd.Parameters.AddWithValue("@UserId", obj.UserId);
                cmd.Parameters.AddWithValue("@AddressType", obj.AddressType);
                cmd.Parameters.AddWithValue("@Address1", obj.Address1);
                cmd.Parameters.AddWithValue("@Address2", obj.Address2);
                cmd.Parameters.AddWithValue("@Landmark", obj.Landmark);
                cmd.Parameters.AddWithValue("@City", obj.City);
                cmd.Parameters.AddWithValue("@State", obj.State);
                cmd.Parameters.AddWithValue("@Country", obj.Country);
                cmd.Parameters.AddWithValue("@Pincode", obj.Pincode);
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

      public DataTable GetAllUSerAddress()
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "SP_MANAGE_USERADDRESS";
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
        
        public DataTable GetUserAddressByUserID(UserAddress obj)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "SP_MANAGE_USERADDRESS";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "GETBYID");
                cmd.Parameters.AddWithValue("UserId", obj.UserId);

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

        public Int64 DeleteUserAddressByUserId(UserAddress obj)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "SP_MANAGE_USERADDRESS";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "DELETE");
                cmd.Parameters.AddWithValue("@UserId", obj.UserId);

                return dbc.ExecuteQuery(cmd);

            }
            catch(Exception ex)
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
