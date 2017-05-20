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
    public class BLStock
    {
        DBConnect dbc;
        SqlCommand cmd;
        public BLStock()
        {
            dbc = new DBConnect();
        }
        public int InsertStock(Stock obj)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "SP_MANAGE_STOCK";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "INSERT");
                cmd.Parameters.AddWithValue("@stockid", obj.StockId);
                cmd.Parameters.AddWithValue("@productid", obj.ProductId);
                cmd.Parameters.AddWithValue("@quantity", obj.Quantity);
                cmd.Parameters.AddWithValue("@price", obj.Price);

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
        public int UpdateStock(Stock obj)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "SP_MANAGE_STOCK";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "update");
                cmd.Parameters.AddWithValue("@stockid", obj.StockId);
                cmd.Parameters.AddWithValue("@productid", obj.ProductId);
                cmd.Parameters.AddWithValue("@quantity", obj.Quantity);
                cmd.Parameters.AddWithValue("@price", obj.Price);
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

        public DataTable GetAllStock()
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "SP_MANAGE_Stock";
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
        public DataTable GetStockByID(Stock obj)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "SP_MANAGE_Stock";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "GETBYID");
                

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
        public int getStock(Stock obj)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "SP_MANAGE_STOCK";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "GETSTOCK");
                cmd.Parameters.AddWithValue("@stokcid", obj.StockId);

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
