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
    public class BLProduct
    {
        DBConnect dbc;
        SqlCommand cmd;
        public BLProduct()
        {
            dbc = new DBConnect();
        }
        public int InsertProduct(Product obj)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "SP_MANAGE_PRODUCT";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "INSERT");
                cmd.Parameters.AddWithValue("@productid", obj.ProductId);
                cmd.Parameters.AddWithValue("@productname", obj.ProductName);
                cmd.Parameters.AddWithValue("@productimage", obj.ProductImage);
                cmd.Parameters.AddWithValue("@actualimage", obj.ActualImage);
                cmd.Parameters.AddWithValue("@categaryid", obj.CategaryId);
                cmd.Parameters.AddWithValue("@subcategaryid", obj.SubCategaryId);
                cmd.Parameters.AddWithValue("@description", obj.Description);
                cmd.Parameters.AddWithValue("@sellerid", obj.SellerId);
                cmd.Parameters.AddWithValue("@sellerdescr", obj.SellerDescr);
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
        public int UpdateProduct(Product obj)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "SP_MANAGE_PRODUCT";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "Update");
                cmd.Parameters.AddWithValue("@productid", obj.ProductId);
                cmd.Parameters.AddWithValue("@productname", obj.ProductName);
                cmd.Parameters.AddWithValue("@productimage", obj.ProductImage);
                cmd.Parameters.AddWithValue("@actualimage", obj.ActualImage);

                cmd.Parameters.AddWithValue("@categaryid", obj.CategaryId);
                cmd.Parameters.AddWithValue("@subcategaryid", obj.SubCategaryId);
                cmd.Parameters.AddWithValue("@description", obj.Description);
                cmd.Parameters.AddWithValue("@sellerid", obj.SellerId);
                cmd.Parameters.AddWithValue("@sellerdescr", obj.SellerDescr);
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
        public DataTable GetAllProduct()
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "SP_MANAGE_PRODUCT";
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
        public DataTable GetProductByID(Product obj)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "SP_MANAGE_PRODUCT";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "GETBYID");
                cmd.Parameters.AddWithValue("@productid", obj.ProductId);

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
        public DataTable GetProductsByCategory(int catid)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "SP_MANAGE_PRODUCT";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "GETBYCAT");
                cmd.Parameters.AddWithValue("@catgaryid", catid);

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

        public int DeleteProduct(Product obj)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "SP_MANAGE_PRODUCT";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "DELETE");
                cmd.Parameters.AddWithValue("@productid", obj.ProductId);

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
