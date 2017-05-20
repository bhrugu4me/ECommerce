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
   public class ClsStock
    {
        BLStock objblstock = new BLStock();
        public int InsertStock(Stock obj)
        {
            return objblstock.InsertStock(obj);
        }

        public int UpdateStock(Stock obj)
        {
            return objblstock.UpdateStock(obj);
        }

        public int getStock(int id)
        {
            Stock obj = new Stock();
            obj.StockId = id;
            return objblstock.getStock(obj);
        }

        public List<Stock> StockList()
        {
            DataTable dt = new DataTable();
            dt = objblstock.GetAllStock();
            List<Stock> lstcat = new List<Stock>();
            Stock retobj;
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        retobj = new Stock();
                        retobj.StockId = Convert.ToInt32(dt.Rows[i]["StockId"].ToString());
                        retobj.ProductId = dt.Rows[i]["ProductId"].ToString();
                        retobj.Quantity = dt.Rows[i]["Quantity"].ToString();
                        retobj.Price = Convert.ToInt32(dt.Rows[i]["Price"].ToString());
                        retobj.InsertedBy = dt.Rows[i]["InsertedBy"].ToString();
                        retobj.InsertedOn = Convert.ToDateTime(dt.Rows[i]["InsertedOn"].ToString());
                        retobj.UpdatedBy = dt.Rows[i]["UpdatedBy"].ToString();
                        retobj.UpdatedOn = Convert.ToDateTime(dt.Rows[i]["UpdatedOn"].ToString());
                        lstcat.Add(retobj);
                    }

                }
            }
            return lstcat;

        }
        public Stock StockById(int id)
        {
            Stock obj = new Stock();
            obj.StockId = id;
            DataTable dt = new DataTable();
            dt = objblstock.GetStockByID(obj);
            Stock retobj = new Stock();
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    retobj.StockId = Convert.ToInt32(dt.Rows[0]["StockId"].ToString());
                    retobj.ProductId = dt.Rows[0]["ProductId"].ToString();
                    retobj.Quantity = dt.Rows[0]["Quantity"].ToString();
                    retobj.Price = Convert.ToInt32(dt.Rows[0]["Price"].ToString());
                    retobj.InsertedBy = dt.Rows[0]["InsertedBy"].ToString();
                    retobj.InsertedOn = Convert.ToDateTime(dt.Rows[0]["InsertedOn"].ToString());
                    retobj.UpdatedBy = dt.Rows[0]["UpdatedBy"].ToString();
                    retobj.UpdatedOn = Convert.ToDateTime(dt.Rows[0]["UpdatedOn"].ToString());

                }
            }
            return retobj;

        }
    }
}

