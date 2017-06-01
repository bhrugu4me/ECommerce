using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using BusinessLayer;
using System.Data;

namespace ServiceLayer
{
    public class ClsProduct
    {
        BLProduct objblproduct = new BLProduct();
        public int InsertProduct(Product obj)
        {
            return objblproduct.InsertProduct(obj);
        }

        public int UpdateProduct(Product obj)
        {
            return objblproduct.UpdateProduct(obj);
        }

        public int DeleteProduct(int id)
        {
            Product obj = new Product();
            obj.ProductId = id;
            return objblproduct.DeleteProduct(obj);
        }

        public List<Product> ProductList()
        {
            DataTable dt = new DataTable();
            dt = objblproduct.GetAllProduct();
            List<Product> lstcat = new List<Product>();
            Product retobj;
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        retobj = new Product();
                        retobj.ProductId = Convert.ToInt32(dt.Rows[i]["ProductId"].ToString());
                        retobj.ProductName = dt.Rows[i]["ProductName"].ToString();
                        retobj.ProductImage = dt.Rows[i]["ProductImage"].ToString();
                        retobj.ActualImage = dt.Rows[i]["ActualImage"].ToString();
                        retobj.Description = dt.Rows[i]["Description"].ToString();
                        retobj.InsertedBy = dt.Rows[i]["InsertedBy"].ToString();
                        retobj.InsertedOn = Convert.ToDateTime(dt.Rows[i]["InsertedOn"].ToString());
                       retobj.CategaryName = dt.Rows[0]["CategaryName"].ToString();
                        retobj.SubCategaryName = dt.Rows[0]["SubCategaryName"].ToString();
                        retobj.SubCategaryId= dt.Rows[0]["SubCategaryId"].ToString();
                        retobj.CategaryId = dt.Rows[i]["CategaryId"].ToString();
                        retobj.UpdatedBy = dt.Rows[i]["UpdatedBy"].ToString();
                        retobj.UpdatedOn = Convert.ToDateTime(dt.Rows[i]["UpdatedOn"].ToString());
                        lstcat.Add(retobj);
                    }

                }
            }
            return lstcat;

        }

        public List<Product> ProductListByCategory(int catid)
        {
            DataTable dt = new DataTable();
            dt = objblproduct.GetProductsByCategory(catid);
            List<Product> lstcat = new List<Product>();
            Product retobj;
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        retobj = new Product();
                        retobj.ProductId = Convert.ToInt32(dt.Rows[i]["ProductId"].ToString());
                        retobj.ProductName = dt.Rows[i]["ProductName"].ToString();
                        retobj.ProductImage = dt.Rows[i]["ProductImage"].ToString();
                        retobj.ActualImage = dt.Rows[i]["ActualImage"].ToString();
                        retobj.Description = dt.Rows[i]["Description"].ToString();
                        retobj.InsertedBy = dt.Rows[i]["InsertedBy"].ToString();
                        retobj.InsertedOn = Convert.ToDateTime(dt.Rows[i]["InsertedOn"].ToString());
                        retobj.CategaryName = dt.Rows[0]["CategaryName"].ToString();
                        retobj.SubCategaryName = dt.Rows[0]["SubCategaryName"].ToString();
                        retobj.SubCategaryId = dt.Rows[0]["SubCategaryId"].ToString();
                        retobj.CategaryId = dt.Rows[i]["CategaryId"].ToString();
                        retobj.UpdatedBy = dt.Rows[i]["UpdatedBy"].ToString();
                        retobj.UpdatedOn = Convert.ToDateTime(dt.Rows[i]["UpdatedOn"].ToString());
                        lstcat.Add(retobj);
                    }

                }
            }
            return lstcat;

        }

        public Product ProductById(int id)
        {
           Product obj = new Product();
            obj.ProductId = id;
            DataTable dt = new DataTable();
            dt = objblproduct.GetProductByID(obj);
            Product retobj = new Product();
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    retobj.ProductId = Convert.ToInt32(dt.Rows[0]["ProductId"].ToString());
                    retobj.ProductName = dt.Rows[0]["ProductName"].ToString();
                    retobj.ProductImage = dt.Rows[0]["ProductImage"].ToString();
                    retobj.ActualImage = dt.Rows[0]["ActualImage"].ToString();
                    retobj.Description = dt.Rows[0]["Description"].ToString();
                    retobj.InsertedBy = dt.Rows[0]["InsertedBy"].ToString();
                    retobj.InsertedOn = Convert.ToDateTime(dt.Rows[0]["InsertedOn"].ToString());
                    retobj.CategaryId = dt.Rows[0]["CategaryId"].ToString();
                    retobj.SubCategaryId = dt.Rows[0]["SubCategaryId"].ToString();
                    retobj.CategaryName= dt.Rows[0]["CategaryName"].ToString();
                    retobj.SubCategaryName = dt.Rows[0]["SubCategaryName"].ToString();
                    retobj.UpdatedBy = dt.Rows[0]["UpdatedBy"].ToString();
                    retobj.UpdatedOn = Convert.ToDateTime(dt.Rows[0]["UpdatedOn"].ToString());

                }
            }
            return retobj;

        }
    }


}



